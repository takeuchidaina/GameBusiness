using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmick3 : MonoBehaviour   //プレイヤーが近づくと一定時間後爆発するギミック
{
    [SerializeField]
    float timer = 2;

    Vector3 FirstPosition;      //初期位置


    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("DereyStart");
            Invoke("PlayerDestroy", timer);
           
        }
    }

    void PlayerDestroy()
    {
        //二点間の距離とって、あたり判定の円の半径の内側まだいるならPlayer破壊
        Destroy(GameObject.Find("Player"));

        //自身の破壊

    }

}
