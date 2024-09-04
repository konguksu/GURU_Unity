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
            B1.GetComponent<Text>().text = "���׷��̵�1 �Ϸ�";
            GameManager.GetComponent<GameManager>().MoneyNum -= 1000;
            GameManager.GetComponent<GameManager>().IsDP2Active = true;
        }

        else
        {
            if(GameManager.GetComponent<GameManager>().IsDP2Active == true)
            {
                Warning.GetComponent<Text>().text = "�̹� �Ϸ��� ���׷��̵��Դϴ�";
            }

            //�� ����
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 1000)
            {
                Warning.GetComponent<Text>().text = "���� �����մϴ�";
            }
            
        }
        
        
    }

    public void UGDP3()
    {
        //DP2 Ȱ��ȭ ���¶��
        if ((GameManager.GetComponent<GameManager>().IsDP2Active) && (GameManager.GetComponent<GameManager>().IsDP3Active == false))
        {
            if (GameManager.GetComponent<GameManager>().MoneyNum >= 2000)
            {
                B2.GetComponent<Text>().text = "���׷��̵�2 �Ϸ�";
                GameManager.GetComponent<GameManager>().MoneyNum -= 2000;
                GameManager.GetComponent<GameManager>().IsDP3Active = true;
            }

            //�� ����
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 2000)
            {
                Warning.GetComponent<Text>().text = "���� �����մϴ�";
            }


        }

        else
        {
            
            if (GameManager.GetComponent<GameManager>().IsDP3Active == true)
            {
                Warning.GetComponent<Text>().text = "�̹� �Ϸ��� ���׷��̵��Դϴ�";
            }

            else if (GameManager.GetComponent<GameManager>().IsDP2Active == false)
            {
                Warning.GetComponent<Text>().text = "���� ���׷��̵带 �Ϸ����ּ���";
            }

      
        }
        
    }

    public void UGDP4()
    {
        //DP3 Ȱ��ȭ ���¶��
        if ((GameManager.GetComponent<GameManager>().IsDP3Active) && (GameManager.GetComponent<GameManager>().IsDP4Active == false))
        {
            if (GameManager.GetComponent<GameManager>().MoneyNum >= 3000)
            {
                B3.GetComponent<Text>().text = "���׷��̵�3 �Ϸ�";
                GameManager.GetComponent<GameManager>().MoneyNum -= 3000;
                GameManager.GetComponent<GameManager>().IsDP4Active = true;
            }

            //�� ����
            else if (GameManager.GetComponent<GameManager>().MoneyNum < 3000)
            {
                Warning.GetComponent<Text>().text = "���� �����մϴ�";
            }

        }

        else
        {

            if (GameManager.GetComponent<GameManager>().IsDP4Active == true)
            {
                Warning.GetComponent<Text>().text = "�̹� �Ϸ��� ���׷��̵��Դϴ�";
            }

            else if (GameManager.GetComponent<GameManager>().IsDP3Active == false)
            {
                Warning.GetComponent<Text>().text = "���� ���׷��̵带 �Ϸ����ּ���";
            }

        }
        

        
    }
}
