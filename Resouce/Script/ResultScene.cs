using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    GameObject stageNum;
    GameObject scoreItemSmall;
    GameObject scoreItemBig;
    GameObject gameResult;
    GameObject nextStgaeButton;
    GameObject scoreTime;
    public AudioClip sound_win;
    public AudioClip sound_lose;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        stageNum = GameObject.Find("StageNum");
        SetStageNum();

        gameResult = GameObject.Find("GameResult");
        SetGameResult();

        scoreTime = GameObject.Find("ScoreTime");
        SetScoreTime();

        /*
        scoreItemSmall = GameObject.Find("ScoreItemSmall");
        SetScoreItemSmall();

        scoreItemBig = GameObject.Find("ScoreItemBig");
        SetScoreItemBig();
        */

        nextStgaeButton = GameObject.Find("NextStage");
        SetNextStageButton();

        audioSource = GetComponent<AudioSource>();

        if (StageManager.gameResult == true)
        {
            audioSource.PlayOneShot(sound_lose);
            //audioSource.PlayOneShot(sound_win);
        }
        else
        {
            audioSource.PlayOneShot(sound_lose);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStageNum()
    {
        if (StageManager.nowStageNum != null)
        {
            stageNum.GetComponent<Text>().text = "Stage " + StageManager.nowStageNum;
        }
        else
        {
            stageNum.GetComponent<Text>().text = "Read error.";
        }
    }

    private void SetGameResult()
    {
        if (StageManager.gameResult == true)
        {
            gameResult.GetComponent<Text>().text = "STAGE CLEAR";
        }
        else
        {
            gameResult.GetComponent<Text>().text = "STAGE FAILED";
        }
    }
    /*
    private void SetScoreItemSmall()
    {
        scoreItemSmall.GetComponent<Text>().text = "x" + StageManager.scoreItemSmall.ToString();
    }

    private void SetScoreItemBig()
    {
        switch (StageManager.scoreItemBig)
        {
            case 0:
                scoreItemBig.GetComponent<Text>().text = "☆　☆　☆";
                break;
            case 1:
                scoreItemBig.GetComponent<Text>().text = "★　☆　☆";
                break;
            case 2:
                scoreItemBig.GetComponent<Text>().text = "★　★　☆";
                break;
            case 3:
                scoreItemBig.GetComponent<Text>().text = "★　★　★";
                break;
            default:
                scoreItemBig.GetComponent<Text>().text = "★　★　★";
                break;
        }
    }
    */

    private void SetNextStageButton()
    {
        if (StageManager.nowStageNum == "9" || StageManager.gameResult == false)
        {
            nextStgaeButton.SetActive(false);
        }
        else
        {
            nextStgaeButton.SetActive(true);
        }
    }

    private void SetScoreTime()
    {
        scoreTime.GetComponent<Text>().text = TimeATK.timer.ToString("F2");
    }
}
