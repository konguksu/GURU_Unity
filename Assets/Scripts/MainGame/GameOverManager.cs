using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    GameObject GameManager;

    int TimeOverCheck;

    public string Ending;

    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Day1Scene"))
        {
            if (((int)GameManager.GetComponent<TimeManager>().TimeNum >= GameManager.GetComponent<TimeManager>().TimeLimit))
            {
                if (GameManager.GetComponent<GameManager>().IsDP4Active == true)
                {
                    if (GameManager.GetComponent<GameManager>().MoneyNum >= 1000)
                    {
                        Ending = "�� ����";
                    }
                    else
                    {
                        Ending = "��� ����";
                    }
                }
                else if (GameManager.GetComponent<GameManager>().IsDP3Active == true)
                {
                    Ending = "���b ����";
                }
                else if (GameManager.GetComponent<GameManager>().IsDP2Active == true)
                {
                    Ending = "��� ����";
                }
                else
                {
                    Ending = "�̷�.. ����";
                }

                SceneManager.LoadScene("EndingScene");

            }
        
            if(GameManager.GetComponent<GameManager>().Reputation.GetComponent<Image>().fillAmount <= 0)
            {
                Ending = "�̷�.. ����";
                SceneManager.LoadScene("EndingScene");
            }
            
        }
    }
}
