using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;
    public AudioClip sound_decision;
    public AudioClip sound_cancel;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            InGameEsc();
        }
    }

    public void SceneChange(string _scene)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        //se再生
        audioSource.PlayOneShot(sound_decision);

        //se終了後にシーン変更
        StartCoroutine(Checking(audioSource,()=> { SceneManager.LoadScene(_scene); }));
        //SceneManager.LoadScene(_scene);
    }

    public void OnClickEndButton()
    {
#if UNITY_EDITOR
        //se再生
        audioSource.PlayOneShot(sound_cancel);

        //se終了後にシーン変更
        StartCoroutine(Checking(audioSource, () => { UnityEditor.EditorApplication.isPlaying = false; }));

#else
        //se再生
        audioSource.PlayOneShot(sound_cancel);

        //se終了後にシーン変更
        StartCoroutine(Checking(audioSource, () => 
        { Application.Quit(); }
        ));
        
#endif
    }

    public void OnClickTryAgain()
    {
        SceneChange("stage"+StageManager.nowStageNum);
        //SceneChange("stage1");
    }

    public void OnClickNextStage()
    {
        SceneChange("stage" + StageCalc(StageManager.nowStageNum));
        //SceneChange("stage2");
    }

    private string StageCalc(string _stageNum)
    {
        int num;
        num = int.Parse(_stageNum);
        num += 1;
        return num.ToString();
    }

    private void InGameEsc()
    {
        StageManager.nowStageNum = "1";
        SceneChange("Result");
    }

    //サウンドが終了しているか確認する
    //https://qiita.com/TakashiHamada/items/a5ff15ca7e63c06bfb23
    private IEnumerator Checking(AudioSource audio, UnityAction callback)
    {
        while (true)
        {
            yield return new WaitForFixedUpdate();
            if (!audio.isPlaying)
            {
                callback();
                break;
            }
        }
    }
}
