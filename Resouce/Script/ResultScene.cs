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

    // Start is called before the first frame update
    void Start()
    {
        stageNum = GameObject.Find("StageNum");
        SetStageNum();

        gameResult = GameObject.Find("GameResult");
        SetGameResult();

        scoreItemSmall = GameObject.Find("ScoreItemSmall");
        SetScoreItemSmall();

        scoreItemBig = GameObject.Find("ScoreItemBig");
        SetScoreItemBig();

        nextStgaeButton = GameObject.Find("NextStage");
        SetNextStageButton();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStageNum()
    {
        if (StageManager.nowStageNum != null)
        {
            stageNum.GetComponent<Text>().text = "Stgae " + StageManager.nowStageNum;
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

    private void SetNextStageButton()
    {
        if (StageManager.nowStageNum == "9")
        {
            nextStgaeButton.SetActive(false);
        }
        else
        {
            nextStgaeButton.SetActive(true);
        }
    }
}
