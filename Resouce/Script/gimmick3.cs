using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmick3 : MonoBehaviour   //プレイヤーが近づくと一定時間後爆発するギミック
{
    [SerializeField]
    float timer;

    [SerializeField]
    float destroyField;            //circleColliderと同数がいいかも？  

    Vector3 FirstPosition;      //初期位置
    int effectFlg = 0;              //エフェクトフラグ
    float alpha_Sin;


    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        alpha_Sin = Mathf.Sin(Time.time*50) / 2 + 0.5f;
        Color _color = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color;

        if (effectFlg == 1)
        {
            _color.a = alpha_Sin;
        }

        transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = _color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("DereyStart");
            effectFlg = 1;
            Invoke("PlayerDestroy", timer);
           
        }
    }

    void PlayerDestroy()
    {
        Debug.Log("PlayerDestroyCheck");
        //二点間の距離とって、あたり判定の円の半径の内側まだいるならPlayer破壊
        //Vector3 playerVec3 = GameObject.Find("Player").transform.position);
        if (destroyField > Vector3.Distance(GameObject.Find("Player").transform.position,FirstPosition)) {

            //プレイヤーの破壊
            Debug.Log("PlayerDestroy");
            Destroy(GameObject.Find("Player"));
        }


        //プレイヤーが破壊されようがされまいが、自身を破壊する
        Destroy(this.gameObject);
    }

}
