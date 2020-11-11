using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Player
{
    public class PlayerMove : MonoBehaviour
    {

        private bool isRotate;  // playerの角度ふらぐ
        [SerializeField] private float AscendSpeed; // 浮上スピード
        [SerializeField] private float UpSpeed;     // w入力時のスピードアップ
        [SerializeField] private float SideSpeed;   // a,dの入力時スピード
        [SerializeField] private float DawnSpeed;   // s入力時のスピードダウン量
        private float PlayerAngle;

        // Use this for initialization
        private void Awake()
        {
            isRotate = false;

            AscendSpeed = 0.01f;
            UpSpeed = 0.002f;
            SideSpeed = 0.02f;
            DawnSpeed = 0.005f;

            PlayerAngle = 30.0f;
        }

        private void Update()
        {
            Move();
        }

        // Update is called once per frame
        private void Move()
        {
        

            ////////////////////////// 常時↑移動
            transform.position += new Vector3(0, AscendSpeed, 0 * Time.deltaTime);

            //////////////////////////// →移動
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                isRotate = true;
                //Debug.Log(isRotate);
                transform.position += new Vector3(SideSpeed, 0, 0 * Time.deltaTime);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -PlayerAngle);
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Debug.Log("キーが離されたよ");
            }
            /////////////////////////// ←移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                isRotate = true;
                transform.position += new Vector3(-SideSpeed, 0, 0 * Time.deltaTime);
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, PlayerAngle);
                isRotate = false;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            {
                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
                Debug.Log("キーが離されたよ");
            }
            ////////////////////////// ↑移動
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, UpSpeed, 0 * Time.deltaTime);
            }

            ////////////////////////// ↓移動
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -DawnSpeed, 0 * Time.deltaTime);
            }
        }
    }
}