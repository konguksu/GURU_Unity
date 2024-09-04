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

        if(EndingManager.GetComponent<GameOverManager>().Ending == "�� ����")
        {
            EndingOn[0].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "��� ����")
        {
            EndingOn[1].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "���b ����")
        {
            EndingOn[2].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "��� ����")
        {
            EndingOn[3].SetActive(true);
        }
        else if (EndingManager.GetComponent<GameOverManager>().Ending == "�̷�.. ����")
        {
            EndingOn[4].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
