using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    GameObject Player;

    public GameObject DP1;
    public GameObject DP2;
    public GameObject DP3;
    public GameObject DP4;

    public GameObject DP1Text;
    public GameObject DP2Text;
    public GameObject DP3Text;
    public GameObject DP4Text;

    //�� �迭
    GameObject[] bread;
    Vector3[] BPos;


    GameObject DrinkEventObj;
    public GameObject DrinkActive;
    public string IsDrinkMGClear;
    Vector3 DrinkEventPos;

    public bool IsDP2Active;
    public bool IsDP3Active;
    public bool IsDP4Active;

    //������ȯ ��ġ �迭
    public GameObject[] p = new GameObject[11];

    //��
    public int MoneyNum = 0;
    GameObject MoneyText;

    public GameObject DrinkOrderOBJ;

    public GameObject Reputation;

    void Start()
    {
        IsDrinkMGClear = "������";

        Player = GameObject.Find("Player");

        //��
        MoneyText = GameObject.Find("MoneyText");

        bread = new GameObject[16];
        BPos = new Vector3[16];

        DrinkEventObj = GameObject.Find("DrinkEventPos");
        DrinkEventPos = DrinkEventObj.transform.position;

        //DP Ȱ��ȭ ����
        IsDP2Active = false;
        IsDP3Active = false;
        IsDP4Active = false;



        print("�Ŵ��� ����");

    }

    // Update is called once per frame
    void Update()
    {
        //�� ����ȭ
        MoneyText.GetComponent<Text>().text = "" + MoneyNum;

        //DP Ȱ��ȭ ����
        DP1Active();
        if (IsDP2Active)
        {
            DP2Active();
        }
        if (IsDP3Active)
        {
            DP3Active();
        }
        if (IsDP4Active)
        {
            DP4Active();
        }

        //���� �̺�Ʈ Ȱ��ȭ �� �����̽��� ������
        if (Input.GetKeyDown(KeyCode.Space) && DrinkActive.activeSelf == true && GameObject.Find("Temp").GetComponent<Temp>().Run2 == false)
        {
            print("�����̽��� ����");




            GameObject.Find("Temp").GetComponent<Temp>().Run2 = true;

            GameObject.FindGameObjectWithTag("Manager").SetActive(false);
            GameObject.FindGameObjectWithTag("Manager").SetActive(false);
            //���� �Ͻ�����
            //PauseGame();

            //���� �̴ϰ��� �� �ҷ�����
            SceneManager.LoadScene("DrinkMiniGame", LoadSceneMode.Additive);
        }

    }

    //DP1 ����������
    void DP1Active()
    {
        //�� 1~4
        for (int i = 0; i < 4; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //�����̽��� ������ ����
                IsSelected(bread[i], true);
                //�� ��� ä���
                FillBread(bread[i]);
            }
            else
            {
                IsSelected(bread[i], false);
            }

        }

    }
    void DP2Active()
    {
        //�� 5~8���̰�
        DP2.SetActive(true);
        DP2Text.SetActive(true);

        //�� 5~8���ͷ���
        for (int i = 4; i < 8; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //�����̽��� ������ ����
                IsSelected(bread[i], true);
                //�� ��� ä���
                FillBread(bread[i]);
            }
            else
            {
                IsSelected(bread[i], false);
            }

        }

    }

    void DP3Active()
    {
        //�� 9~12���̰�
        DP3.SetActive(true);
        DP3Text.SetActive(true);

        //�� 9~12���ͷ���
        for (int i = 8; i < 12; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //�����̽��� ������ ����
                IsSelected(bread[i], true);
                //�� ��� ä���
                FillBread(bread[i]);
            }
            else
            {
                IsSelected(bread[i], false);
            }

        }

    }

    void DP4Active()
    {
        //�� 13~16 ���̰�
        DP4.SetActive(true);
        DP4Text.SetActive(true);

        //�� 13~16 ���ͷ���
        for (int i = 12; i < 15; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //�����̽��� ������ ����
                IsSelected(bread[i], true);
                //�� ��� ä���
                FillBread(bread[i]);
            }
            else
            {
                IsSelected(bread[i], false);
            }
        }

    }


    void IsSelected(GameObject bread, bool TF)
    {
        Vector3 breadPos = bread.transform.position;
        if (TF == true)
        {
            bread.GetComponent<BreadCompo>().Select.SetActive(true);
        }
        else
        {
            bread.GetComponent<BreadCompo>().Select.SetActive(false);
        }

    }

    void FillBread(GameObject bread)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bread.GetComponent<BreadCompo>().StockNum = 5;
        }

    }

    public void DrinkMiniGame()
    {
        if (Vector3.Distance(DrinkEventPos, Player.transform.position) <= 0.8f)
        {
            print("���� �̺�Ʈ ���ष��");
            DrinkActive.SetActive(true);
        }
        else
        {
            DrinkActive.SetActive(false);
        }

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;

    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
    }
}
