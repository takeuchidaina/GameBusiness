using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PlayerDeadEffect : MonoBehaviour
{
    public GameObject particleObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Object") 
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
            Destroy(this.gameObject); //衝突したゲームオブジェクトを削除
        }
    }
}