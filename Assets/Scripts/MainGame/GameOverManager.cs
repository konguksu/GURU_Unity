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
                        Ending = "굿 엔딩";
                    }
                    else
                    {
                        Ending = "쏘쏘 엔딩";
                    }
                }
                else if (GameManager.GetComponent<GameManager>().IsDP3Active == true)
                {
                    Ending = "낟밷 엔딩";
                }
                else if (GameManager.GetComponent<GameManager>().IsDP2Active == true)
                {
                    Ending = "배드 엔딩";
                }
                else
                {
                    Ending = "이런.. 엔딩";
                }

                SceneManager.LoadScene("EndingScene");

            }
        
            if(GameManager.GetComponent<GameManager>().Reputation.GetComponent<Image>().fillAmount <= 0)
            {
                Ending = "이런.. 엔딩";
                SceneManager.LoadScene("EndingScene");
            }
            
        }
    }
}
