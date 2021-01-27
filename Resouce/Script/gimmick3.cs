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

    public GameObject particleObject;

    public AudioSource audio;
    public AudioSource audio2;


    // Start is called before the first frame update
    void Start()
    {
        FirstPosition = transform.position;

        Vector3 tmpScale = new Vector3(destroyField, destroyField, 0);
        transform.GetChild(0).gameObject.GetComponent<Transform>().localScale = tmpScale;

        gameObject.GetComponent<CircleCollider2D>().radius = destroyField / 2;

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
            audio2.Play();


        }
    }

    void PlayerDestroy()
    {
        Debug.Log("PlayerDestroyCheck");
        //二点間の距離とって、あたり判定の円の半径の内側まだいるならPlayer破壊
        //Vector3 playerVec3 = GameObject.Find("Player").transform.position);
        if (destroyField / 2 > Vector3.Distance(GameObject.Find("Player").transform.position, FirstPosition))
        {

            //プレイヤーの破壊
            Debug.Log("PlayerDestroy");
            Destroy(GameObject.Find("Player"));
        }


        //プレイヤーが破壊されようがされまいが、自身を破壊する
        Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
        audio2.Stop();
        audio.Play();

        Destroy(this.gameObject);
    }

}
