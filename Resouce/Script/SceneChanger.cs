using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static SceneChanger Instance;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(string _scene)
    {
        SceneManager.LoadScene(_scene);
    }

    public void OnClickEndButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

    public void OnClickTryAgain()
    {
        SceneChange("Stage"+StageManager.nowStageNum);
    }

    public void OnClickNextStage()
    {
        SceneChange("Stage" + StageCalc(StageManager.nowStageNum));
    }

    private string StageCalc(string _stageNum)
    {
        int num;
        num = int.Parse(_stageNum);
        num += 1;
        return num.ToString();
    }
}
