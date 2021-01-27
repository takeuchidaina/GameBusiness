using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeATK : MonoBehaviour
{
    public static double timer;
    GameObject timeObj;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0;
        timeObj = GameObject.Find("Time");
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        timeObj.GetComponent<Text>().text = timer.ToString("F2");
    }
}
