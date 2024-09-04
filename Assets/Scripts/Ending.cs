using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    GameObject EndingManager;

    public GameObject[] EndingOn = new GameObject[5];

    void Start()
    {
        EndingManager = GameObject.Find("EndingManager");

        if(EndingManager.GetComponent<GameOverManager>().Ending == "±Â ¿£µù")
        {
            EndingOn[0].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "½î½î ¿£µù")
        {
            EndingOn[1].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "³®“b ¿£µù")
        {
            EndingOn[2].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "¹èµå ¿£µù")
        {
            EndingOn[3].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "ÀÌ·±.. ¿£µù")
        {
            EndingOn[4].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
