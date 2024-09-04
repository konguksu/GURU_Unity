using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public GameObject TimeText;

    public float TimeNum = 0;
    public int TimeLimit = 90;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeText.GetComponent<Text>().text = "" + (TimeLimit - (int)TimeNum);
        TimeNum += Time.deltaTime;
         
    }
}
