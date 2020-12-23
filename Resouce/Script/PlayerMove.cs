using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField]  public Camera Camera;
        private bool isRotate;  // playerの角度ふらぐ
        [SerializeField] private float AscendSpeed; // 浮上スピード
        [SerializeField] private float UpSpeed;     // w入力時のスピードアップ
        [SerializeField] private float SideSpeed;   // a,dの入力時スピード
        [SerializeField] private float DawnSpeed;   // s入力時のスピードダウン量
        private float PlayerAngle;



        private Vector3 vec;
     //   private Vector3 speed;
        public float speed;

        private  const float NomalSpeed = 10;
        // Use this for initialization
        private void Awake()
        {
            isRotate = false;

            AscendSpeed = 0.01f;
            UpSpeed = 0.05f;
            SideSpeed = 0.002f;
            DawnSpeed = 0.05f;

            PlayerAngle = 1.0f;
            vec = transform.rotation * new Vector3(0, 1, 0);
            speed = NomalSpeed;
        }

        private void Update()
        {
            Move();
        }

        // Update is called once per frame
        private void Move()
        {

            Camera.transform.position = new Vector3(transform.position.x, transform.position.y,-0.75f);


            //////////////////////////// →移動
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                isRotate = true;
                //Debug.Log(isRotate);
                //    transform.position += new Vector3(SideSpeed, 0, 0 * Time.deltaTime);
                Quaternion rot = Quaternion.Euler(0,0,-PlayerAngle);
                Quaternion tmp = this.transform.rotation ;
                this.transform.rotation = rot * tmp;
            }
            //if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
            //{
            //    // this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //    transform.rotation = Quaternion.LookRotation(new Vector3(0.0f, 0.0f, 0.0f));
            //    
            //}
            /////////////////////////// ←移動
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                isRotate = true;
               // transform.position += new Vector3(-SideSpeed, 0, 0 * Time.deltaTime);
              //  this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, PlayerAngle);
                Quaternion rot = Quaternion.Euler(0, 0, PlayerAngle);
                Quaternion tmp = this.transform.rotation;
                this.transform.rotation = rot * tmp;
                isRotate = false;
            }
            //if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
            //{
            //   // this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            //    transform.rotation = Quaternion.LookRotation(new Vector3(0.0f,0.0f,0.0f) );
            //    
            //}
            ////////////////////////// ↑移動
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                // transform.position += new Vector3(0, UpSpeed, 0 * Time.deltaTime);
                speed += 0.5f;
            }
            else
            {
                if (NomalSpeed < speed) speed-=0.05f;
            }
            ////////////////////////// ↓移動
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                //transform.position += new Vector3(0, -DawnSpeed, 0 * Time.deltaTime);
                speed += -0.5f;
            }
            else
            {
                 if (NomalSpeed > speed) speed += 0.05f;
            }
          
            
            // speed = NomalSpeed;
            ////////////////////////// 常時↑移動
            //  transform.position += new Vector3(0, AscendSpeed, 0 * Time.deltaTime);
            vec =this.transform.up*UpSpeed;
            transform.position -= (vec * speed)*Time.deltaTime;
        }
    }
}