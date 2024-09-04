using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    GameObject GameManager;
    public GameObject B1;
    public GameObject B2;
    public GameObject B3;

    public GameObject Warning;

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
        Warning.GetComponent<Text>().text = "";
        GameObject.Find("ShopScene").SetActive(false);
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Day1Scene"));
        

    }

    public void UGDP2()
    {
        if((GameManager.GetComponent<GameManager>().MoneyNum >= 1000) && (GameManager.GetComponent<GameManager>().IsDP2Active == false))
        {
            B1.GetComponent<Text>().text = "업그레이드1 완료";
            GameManager.GetComponent<GameManager>().MoneyNum -= 1000;
            GameManager.GetComponent<GameManager>().IsDP2Active = true;
        }

        else
        {
            if(GameManager.GetComponent<GameManager>().IsDP2Active == true)
            {
                Warning.GetComponent<Text>().text = "이미 완료한 업그레이드입니다";
            }

            //돈 부족
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 1000)
            {
                Warning.GetComponent<Text>().text = "돈이 부족합니다";
            }
            
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

            //돈 부족
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 2000)
            {
                Warning.GetComponent<Text>().text = "돈이 부족합니다";
            }


        }

        else
        {
            
            if (GameManager.GetComponent<GameManager>().IsDP3Active == true)
            {
                Warning.GetComponent<Text>().text = "이미 완료한 업그레이드입니다";
            }

            else if (GameManager.GetComponent<GameManager>().IsDP2Active == false)
            {
                Warning.GetComponent<Text>().text = "이전 업그레이드를 완료해주세요";
            }

      
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

            //돈 부족
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 3000)
            {
                Warning.GetComponent<Text>().text = "돈이 부족합니다";
            }

        }

        else
        {

            if (GameManager.GetComponent<GameManager>().IsDP4Active == true)
            {
                Warning.GetComponent<Text>().text = "이미 완료한 업그레이드입니다";
            }

            else if (GameManager.GetComponent<GameManager>().IsDP3Active == false)
            {
                Warning.GetComponent<Text>().text = "이전 업그레이드를 완료해주세요";
            }

        }
        

        
    }
}
