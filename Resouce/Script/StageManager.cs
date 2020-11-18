using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public static string nowStageNum;
    public static int scoreItemSmall;
    public static int scoreItemBig;
    public static bool gameResult;

    // Start is called before the first frame update
    void Start()
    {
        //nowStageNum = "0";
        scoreItemSmall = 0;
        scoreItemBig = 0;
        gameResult = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageChange(string _num)
    {
        //ステージ番号保存
        nowStageNum = _num;

        //シーン遷移
        SceneChanger.Instance.SceneChange("stage" + _num);
        //SceneChanger.Instance.SceneChange("Result");
    }

    public void AcquisitionScoreBig()
    {
        if (scoreItemBig < 3)
        {
            scoreItemBig++;
        }
    }

    public void AcquisitionScoreSmall()
    {
        scoreItemSmall++;
    }

    //true クリア　false 失敗
    public void StageEnd(bool _result)
    {
        gameResult = _result;
        SceneChanger.Instance.SceneChange("Result");
    }
}
