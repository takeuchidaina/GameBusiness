using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScene : MonoBehaviour
{
    GameObject stageNum;

    // Start is called before the first frame update
    void Start()
    {
        stageNum = GameObject.Find("StageNum");
        SetStageNum();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetStageNum()
    {
        //stageNum.GetComponent<Text>().text = "";
        stageNum.GetComponent<Text>().text = "Stgae " + StageManager.nowStageNum;
    }
}
