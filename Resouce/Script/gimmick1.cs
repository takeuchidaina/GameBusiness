using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmick1 : MonoBehaviour   //反復移動するギミック
{

    Vector3 FirstPosition;  //初期位置(反復する線上の中心点になる)
    [SerializeField]
    Vector3 MovePosition;   //移動先の座標
    float Distance;         //2点間の距離、移動フラグの切り替えに使用

    [SerializeField]
    float speed;     //移動速度

    int MoveFlg = 1;        //移動フラグ、移動先の座標に向かっていれば1、移動先座標から戻ってくる場合は-1

    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = transform.position;
        Distance = Vector3.Distance(FirstPosition, MovePosition);
    }

    // Update is called once per frame
    void Update()
    {
        //移動処理
        if(MoveFlg == 1)
        {
            transform.position += MovePosition * speed;
        }
        else if(MoveFlg == -1)
        {
            transform.position -= MovePosition * speed;
        }

        //もし現在の2点間の距離が、初期の2点間の距離より大きければフラグの切り替え
        if (Distance < Vector3.Distance(FirstPosition, transform.position))
        {
            MoveFlg *= -1;
        }

    }
}
