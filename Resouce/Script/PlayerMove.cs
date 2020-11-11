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

        // Use this for initialization
        private void Awake()
        {
            isRotate = false;

            AscendSpeed = 0.02f;
            UpSpeed = 0.002f;
            SideSpeed = 0.02f;
            DawnSpeed = 0.00f;
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

            ////////////////////////// →移動
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                isRotate = true;
                transform.position += new Vector3(SideSpeed, 0, 0 * Time.deltaTime);
                transform.Rotate(new Vector3(0, 0, -5));
            }

            /////////////////////////// ←移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                transform.position += new Vector3(-SideSpeed, 0, 0 * Time.deltaTime);
                transform.Rotate(new Vector3(0, 0, 5));
            }

            //////////////////////// ↑移動
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                transform.position += new Vector3(0, UpSpeed, 0 * Time.deltaTime);
            }

            ///////////////////////// ↓移動
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                transform.position += new Vector3(0, -DawnSpeed, 0 * Time.deltaTime);
            }
            isRotate = false;
        }
    }
}