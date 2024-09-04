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

    //빵 배열
    GameObject[] bread;
    Vector3[] BPos;


    GameObject DrinkEventObj;
    public GameObject DrinkActive;
    public string IsDrinkMGClear;
    Vector3 DrinkEventPos;

    public bool IsDP2Active;
    public bool IsDP3Active;
    public bool IsDP4Active;

    //방향전환 위치 배열
    public GameObject[] p = new GameObject[11];

    //돈
    public int MoneyNum = 0;
    GameObject MoneyText;

    public GameObject DrinkOrderOBJ;

    public GameObject Reputation;

    void Start()
    {
        IsDrinkMGClear = "게임전";

        Player = GameObject.Find("Player");

        //돈
        MoneyText = GameObject.Find("MoneyText");

        bread = new GameObject[16];
        BPos = new Vector3[16];

        DrinkEventObj = GameObject.Find("DrinkEventPos");
        DrinkEventPos = DrinkEventObj.transform.position;

        //DP 활성화 여부
        IsDP2Active = false;
        IsDP3Active = false;
        IsDP4Active = false;



        print("매니저 실행");

    }

    // Update is called once per frame
    void Update()
    {
        //돈 동기화
        MoneyText.GetComponent<Text>().text = "" + MoneyNum;

        //DP 활성화 여부
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

        //음료 이벤트 활성화 중 스페이스바 누르면
        if (Input.GetKeyDown(KeyCode.Space) && DrinkActive.activeSelf == true && GameObject.Find("Temp").GetComponent<Temp>().Run2 == false)
        {
            print("스페이스바 누름");




            GameObject.Find("Temp").GetComponent<Temp>().Run2 = true;

            GameObject.FindGameObjectWithTag("Manager").SetActive(false);
            GameObject.FindGameObjectWithTag("Manager").SetActive(false);
            //게임 일시정지
            //PauseGame();

            //음료 미니게임 씬 불러오기
            SceneManager.LoadScene("DrinkMiniGame", LoadSceneMode.Additive);
        }

    }

    //DP1 열려있을때
    void DP1Active()
    {
        //빵 1~4
        for (int i = 0; i < 4; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //스페이스바 아이콘 띄우기
                IsSelected(bread[i], true);
                //빵 재고 채우기
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
        //빵 5~8보이게
        DP2.SetActive(true);
        DP2Text.SetActive(true);

        //빵 5~8인터렉션
        for (int i = 4; i < 8; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //스페이스바 아이콘 띄우기
                IsSelected(bread[i], true);
                //빵 재고 채우기
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
        //빵 9~12보이게
        DP3.SetActive(true);
        DP3Text.SetActive(true);

        //빵 9~12인터렉션
        for (int i = 8; i < 12; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //스페이스바 아이콘 띄우기
                IsSelected(bread[i], true);
                //빵 재고 채우기
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
        //빵 13~16 보이게
        DP4.SetActive(true);
        DP4Text.SetActive(true);

        //빵 13~16 인터렉션
        for (int i = 12; i < 15; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            BPos[i] = bread[i].transform.position;

            if (Vector3.Distance(BPos[i], Player.transform.position) <= 1.35f)
            {
                //스페이스바 아이콘 띄우기
                IsSelected(bread[i], true);
                //빵 재고 채우기
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
            print("음료 이벤트 실행ㅇ중");
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
