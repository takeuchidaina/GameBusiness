using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -0.01f, 0);
        if (transform.position.y < -60.0f)
        {
            transform.position = new Vector3(0, 30, 0);
        }
    }
}
