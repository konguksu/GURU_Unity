using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopButton : MonoBehaviour
{
    GameObject GameManager;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;

    public GameObject ShopScene;

    // Start is called before the first frame update
    void Start()
    {
        
        GameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseShop()
    {
        Time.timeScale = 1.0f;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Day1Scene"));
        GameObject.Find("ShopScene").SetActive(false);

    }

    public void UGDP2()
    {
        if((GameManager.GetComponent<GameManager>().MoneyNum >= 1000) && (GameManager.GetComponent<GameManager>().IsDP2Active == false))
        {
            B1.GetComponent<Text>().text = "업그레이드1 완료";
            GameManager.GetComponent<GameManager>().MoneyNum -= 1000;
            GameManager.GetComponent<GameManager>().IsDP2Active = true;
        }
        
    }

    public void UGDP3()
    {
        //DP2 활성화 상태라면
        if ((GameManager.GetComponent<GameManager>().IsDP2Active) && (GameManager.GetComponent<GameManager>().IsDP3Active == false))
        {
            if (GameManager.GetComponent<GameManager>().MoneyNum >= 2000)
            {
                B2.GetComponent<Text>().text = "업그레이드2 완료";
                GameManager.GetComponent<GameManager>().MoneyNum -= 2000;
                GameManager.GetComponent<GameManager>().IsDP3Active = true;
            }


        }
        else
        {
            
        }
    }

    public void UGDP4()
    {
        //DP3 활성화 상태라면
        if ((GameManager.GetComponent<GameManager>().IsDP3Active) && (GameManager.GetComponent<GameManager>().IsDP4Active == false))
        {
            if (GameManager.GetComponent<GameManager>().MoneyNum >= 3000)
            {
                B3.GetComponent<Text>().text = "업그레이드3 완료";
                GameManager.GetComponent<GameManager>().MoneyNum -= 3000;
                GameManager.GetComponent<GameManager>().IsDP4Active = true;
            }


        }
        else
        {

        }
    }
}
