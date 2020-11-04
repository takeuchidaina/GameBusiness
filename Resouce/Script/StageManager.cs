using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance;
    public static string nowStageNum;

    // Start is called before the first frame update
    void Start()
    {
        //nowStageNum = "0";
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
        //SceneChanger.Instance.SceneChange("Stage" + _num);
        SceneChanger.Instance.SceneChange("Result");
    }
}
