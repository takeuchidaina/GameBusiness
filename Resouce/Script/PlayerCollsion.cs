﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollsion : MonoBehaviour
{
    [SerializeField]
    static public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Goal") {; }
        //else if (collision.gameObject.tag == "Wall")
        //{
        //    StageManager.Instance.StageEnd(true);
        //    Destroy(player);
        //}
            // StageManager.Instance.StageEnd(true);
    }
}
