using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreadCompo : MonoBehaviour
{
    public GameObject buyPos;

    public GameObject BreadLeftText;

    public int StockNum;

    public GameObject Select;

    // Start is called before the first frame update
    void Start()
    {
        StockNum = 5;
    }

    // Update is called once per frame
    void Update()
    {
        BreadLeftText.GetComponent<Text>().text = ""+StockNum;
    }
}
