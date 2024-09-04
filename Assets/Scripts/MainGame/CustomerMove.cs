using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerMove : MonoBehaviour
{


    GameObject ReputationBar;

    public float StopTime = 0.3f;
    public float time = 0;

    public float buyTime = 0;

    public float orderTime = 0;

    public float distan = 0.15f;

    //생성 위치
    // public Vector3 GenPos = new Vector3(8.2f, 3.0f, 0f);
    public GameObject GenPos;


    //방향전환 위치 배열
    public Vector3[] P;

    //손님 이동 속도
    public Vector3 MoveX = new Vector3(2f, 0, 0);
    public Vector3 MoveY = new Vector3(0, 2f, 0);

    //손님 이동 방향
    public string dir;
    public string tempDir;

    //랜덤 방향 지정
    int rand;

    //전환 위치에 도달했는가
    bool DirChange = true;

    //빵을 샀는가
    public string buy;

    //빵&구매위치 배열
    GameObject[] bread;
    Vector3[] breadBuyPos;

    private float x;
    private float y;
    private Animator myAnim;


    GameObject Money;
    GameObject CustomerManager;
    GameObject GameManager;

    public GameObject Alert;
    public GameObject EventSpaceActive;

    void Start()
    {
        myAnim = GetComponent<Animator>();

        //시작 위치
        GenPos = GameObject.Find("GenPos");
        this.transform.position = GenPos.transform.position;
        buy = "구매 전";
        //시작 이동 방향
        rand = Random.Range(0, 2);

        //빵&구매 위치 배열 
        bread = new GameObject[16];
        breadBuyPos = new Vector3[16];



        print("시작 방향(0왼1하): " + rand);
        if (rand == 0)
        {
            dir = "Left";
        }
        else if (rand == 1)
        {
            dir = "Down";
        }


        Money = GameObject.Find("MoneyText");
        CustomerManager = GameObject.Find("CustomerManager");
        GameManager = GameObject.Find("GameManager");

        ReputationBar = GameObject.Find("ReputationBar");

        P = new Vector3[11];

        for (int i = 0; i < P.Length; i++)
        {
            P[i] = GameManager.GetComponent<GameManager>().p[i].transform.position;
        }

        InvokeRepeating("SpecialEvent", 3f, 15f);
    }

    // Update is called once per frame
    void Update()
    {

        if (dir == "Left")
        {
            transform.Translate(-MoveX * Time.deltaTime);
            x = -1;
            y = 0;
        }
        else if (dir == "Right")
        {
            transform.Translate(MoveX * Time.deltaTime);
            x = 1;
            y = 0;
        }
        else if (dir == "Up")
        {
            transform.Translate(MoveY * Time.deltaTime);
            x = 0;
            y = 1;
        }
        else if (dir == "Down")
        {
            transform.Translate(-MoveY * Time.deltaTime);
            x = 0;
            y = -1;
        }
        else if (dir == "DrinkOrder" || dir == "이벤트 멈춤" || dir == "일시정지")
        {
            transform.Translate(0, 0, 0);
            x = 0;
            y = 0;
        }
        //else if (dir == "이벤트 멈춤")
        //{
        //    transform.Translate(0, 0, 0);
        //}
        //애니메이션
        myAnim.SetFloat("moveX", x);
        myAnim.SetFloat("moveY", y);

        if (x == 1 || x == -1 || y == 1 || y == -1)
        {
            myAnim.SetFloat("lastMoveX", x);
            myAnim.SetFloat("lastMoveY", y);
        }

        if (DirChange == true)
        {
            this.ChangeDirection();

        }

        if (buy == "구매 전")
        {
            BuyDP1();


            if (GameManager.GetComponent<GameManager>().IsDP2Active)
            {
                BuyDP2();
            }
            if (GameManager.GetComponent<GameManager>().IsDP3Active)
            {
                BuyDP3();
            }
            if (GameManager.GetComponent<GameManager>().IsDP4Active)
            {
                BuyDP4();
            }

        }

        //구매 실패 후 대기시간 설정
        if (buy == "구매 멈춤")
        {
            print("구매 대기 중");

            buyTime += Time.deltaTime;
            if (buyTime >= 0.2f)
            {
                buyTime = 0;
                buy = "구매 전";
            }
        }

        if (DirChange == false)
        {
            //방향전환 정지 일정 시간 지난 후 풀기
            time += Time.deltaTime;

            if (time >= StopTime)
            {
                time = 0;
                DirChange = true;
            }

        }

        //미니게임 이동시 멈춤(이벤트 발생 손님이 아니고, 방향이 일시정지일때는 실행 x)
        if ((GameObject.Find("Temp").GetComponent<Temp>().Run == true || GameObject.Find("Temp").GetComponent<Temp>().Run2 == true) && dir != "이벤트 멈춤" && dir != "일시정지")
        {
            //이전 이동방향 임시저장
            tempDir = dir;
            //이동 일시정지
            dir = "일시정지";
        }

        //미니게임 종료되고 일시정지 상태였으면
        else if ((GameObject.Find("Temp").GetComponent<Temp>().Run == false || GameObject.Find("Temp").GetComponent<Temp>().Run2 == false) && dir == "일시정지")
        {
            //임시 저장했던 이동방향으로 다시 설정
            dir = tempDir;

        }


    }

    void ChangeDirection()
    {
        //구매 전 이동
        if (buy == "구매 전")
        {
            if (Vector3.Distance(P[0], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Left";
                }
                else if (rand == 1)
                {
                    dir = "Down";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[1], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Left";
                }
                else if (rand == 1)
                {
                    dir = "Down";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[2], transform.position) <= distan)
            {
                float rand = Random.Range(0f, 1f);

                //20프로 확률로 음료주문이동
                if (rand <= 0.2f && GameManager.GetComponent<GameManager>().DrinkOrderOBJ == null)
                {
                    GameManager.GetComponent<GameManager>().DrinkOrderOBJ = this.gameObject;
                    dir = "Left";

                }


                else
                {
                    dir = "Down";
                }
                DirChange = false;

            }

            if (Vector3.Distance(P[3], transform.position) <= distan)
            {
                dir = "Left";
                DirChange = false;
            }

            if (Vector3.Distance(P[4], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Left";
                }
                else if (rand == 1)
                {
                    dir = "Up";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[5], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Left";
                }
                else if (rand == 1)
                {
                    dir = "Up";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[6], transform.position) <= distan)
            {
                float rand = Random.Range(0f, 1f);

                //20프로 확률로 음료주문이동 (다른 손님이 주문중이 아니라면)
                if (rand <= 0.2f && GameManager.GetComponent<GameManager>().DrinkOrderOBJ == null)
                {
                    GameManager.GetComponent<GameManager>().DrinkOrderOBJ = this.gameObject;
                    dir = "Left";

                }


                else
                {
                    dir = "Up";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[7], transform.position) <= distan)
            {
                dir = "Down";
                DirChange = false;
            }

            if (Vector3.Distance(P[8], transform.position) <= distan)
            {
                dir = "Left";
                DirChange = false;
            }

            if (Vector3.Distance(P[9], transform.position) <= distan)
            {
                dir = "Up";
                DirChange = false;
            }

            if (Vector3.Distance(P[10], transform.position) <= distan)
            {
                dir = "DrinkOrder";
                DirChange = false;
            }
        }

        if (dir == "DrinkOrder")
        {
            DrinkOrder();
        }

        //구매 후 이동
        if (buy == "구매함")
        {
            if (Vector3.Distance(P[0], transform.position) <= distan)
            {
                dir = "Right";
                DirChange = false;
            }

            if (Vector3.Distance(P[1], transform.position) <= distan)
            {
                dir = "Right";
                DirChange = false;
            }

            if (Vector3.Distance(P[2], transform.position) <= distan)
            {
                dir = "Right";
                DirChange = false;
            }

            if (Vector3.Distance(P[3], transform.position) <= distan)
            {
                dir = "Up";
                DirChange = false;
            }

            if (Vector3.Distance(P[4], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Up";
                }
                else if (rand == 1)
                {
                    dir = "Right";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[5], transform.position) <= distan)
            {
                rand = Random.Range(0, 2);
                if (rand == 0)
                {
                    dir = "Up";
                }
                else if (rand == 1)
                {
                    dir = "Right";
                }
                DirChange = false;
            }

            if (Vector3.Distance(P[6], transform.position) <= distan)
            {
                dir = "Right";
                DirChange = false;
            }

            if (Vector3.Distance(P[7], transform.position) <= distan)
            {
                dir = "Right";
                DirChange = false;
            }

            if (Vector3.Distance(P[8], transform.position) <= distan)
            {
                dir = "Up";
                DirChange = false;
            }

            //입구 도달시 오브젝트 제거
            if (Vector3.Distance(GenPos.transform.position, transform.position) <= distan)
            {
                Destroy(gameObject);
            }
        }
    }

    void BuyDP1()
    {
        for (int i = 0; i < 4; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            breadBuyPos[i] = bread[i].GetComponent<BreadCompo>().buyPos.transform.position;

            if (Vector3.Distance(breadBuyPos[i], transform.position) <= distan)
            {

                int a = Random.Range(0, 2);
                //빵 구매
                if (a == 0)
                {
                    //재고가 있으면
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 300;

                        print("빵1 재고: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "구매함";
                    }
                    else
                    {
                        print("재고없음");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "구매 멈춤";
                    }

                }
                //빵 구매안함
                else if (a == 1)
                {
                    buy = "구매 멈춤";
                    print("빵1 구매안함");
                }

            }
        }

    }

    void BuyDP2()
    {
        for (int i = 4; i < 8; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            breadBuyPos[i] = bread[i].GetComponent<BreadCompo>().buyPos.transform.position;

            if (Vector3.Distance(breadBuyPos[i], transform.position) <= distan)
            {

                float a = Random.Range(0f, 1.0f);
                //30프로 확률로 빵 구매
                if (a <= 0.3)
                {
                    //재고가 있으면
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        //재고 감소
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        //돈 증가 & 텍스트 변경
                        GameManager.GetComponent<GameManager>().MoneyNum += 400;

                        print("빵1 재고: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "구매함";
                    }
                    else
                    {
                        print("재고없음");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "구매 멈춤";
                    }

                }
                //빵 구매안함
                else
                {
                    buy = "구매 멈춤";
                    print("빵1 구매안함");
                }

            }
        }


    }

    void BuyDP3()
    {

        for (int i = 8; i < 12; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            breadBuyPos[i] = bread[i].GetComponent<BreadCompo>().buyPos.transform.position;

            if (Vector3.Distance(breadBuyPos[i], transform.position) <= distan)
            {

                float a = Random.Range(0f, 1.0f);
                //20프로 확률로 빵 구매
                if (a <= 0.2)
                {
                    //재고가 있으면
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 500;

                        print("빵1 재고: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "구매함";
                    }
                    else
                    {
                        print("재고없음");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "구매 멈춤";
                    }

                }
                //빵 구매안함
                else
                {
                    buy = "구매 멈춤";
                    print("빵1 구매안함");
                }

            }
        }
    }

    void BuyDP4()
    {

        for (int i = 12; i < 16; i++)
        {
            bread[i] = GameObject.Find("Bread " + (i + 1));
            breadBuyPos[i] = bread[i].GetComponent<BreadCompo>().buyPos.transform.position;

            if (Vector3.Distance(breadBuyPos[i], transform.position) <= distan)
            {

                float a = Random.Range(0f, 1.0f);
                //10프로 확률로 빵 구매
                if (a <= 0.1)
                {
                    //재고가 있으면
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 700;

                        print("빵1 재고: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "구매함";
                    }
                    else
                    {
                        print("재고없음");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "구매 멈춤";
                    }

                }
                //빵 구매안함
                else
                {
                    buy = "구매 멈춤";
                    print("빵1 구매안함");
                }

            }
        }
    }
    void DrinkOrder()
    {


        //제한시간 시작
        if (GameObject.Find("Temp").GetComponent<Temp>().Run2 != true)
        {
            //주문 시간제한 시작
            orderTime += Time.deltaTime;
        }


        //시간제한 안에 주문 못받았을시
        if (orderTime >= 0.3f && Alert.activeSelf == true)
        {
            dir = "Right";

            orderTime = 0;
            Alert.SetActive(false);
            ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
            GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);

            buy = "구매함";


        }

        //시간 제한 종료 전
        else if (orderTime <= 0.3f)
        {
            Alert.SetActive(true);
            GameManager.GetComponent<GameManager>().DrinkMiniGame();

            //미니게임 클리어시 300원 증가
            if (GameManager.GetComponent<GameManager>().IsDrinkMGClear == "게임 클리어")
            {
                GameManager.GetComponent<GameManager>().MoneyNum += 800;
                dir = "Right";
                orderTime = 0;
                Alert.SetActive(false);

                GameObject.Find("Temp").GetComponent<Temp>().Run2 = false;

                GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);
                GameManager.GetComponent<GameManager>().DrinkOrderOBJ = null;
                GameManager.GetComponent<GameManager>().IsDrinkMGClear = "게임전";
                buy = "구매함";
            }

            //미니게임 클리어 실패시 명성 감소
            else if (GameManager.GetComponent<GameManager>().IsDrinkMGClear == "게임 실패")
            {
                dir = "Right";
                orderTime = 0;
                Alert.SetActive(false);
                ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;

                GameObject.Find("Temp").GetComponent<Temp>().Run2 = false;

                GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);
                GameManager.GetComponent<GameManager>().DrinkOrderOBJ = null;
                GameManager.GetComponent<GameManager>().IsDrinkMGClear = "게임전";
                buy = "구매함";
            }
        }

    }

    void SpecialEvent()
    {
        print("진상 이벤트 실행?");

        if ((Random.Range(0f, 1.0f) <= 0.1f) && (GameManager.GetComponent<SpecialEvent>().specialEventNum < 3) && buy == "구매 전")
        {

            print("진상 이벤트 발동");

            if (dir != "일시정지")
            {
                tempDir = dir;
            }


            dir = "이벤트 멈춤";

            buy = "구매함";
            //진상 이벤트 리스트에 추가
            GameManager.GetComponent<SpecialEvent>().SpecialEventObj.Add(this.gameObject);
            //이벤트 발생 숫자 1 증가
            GameManager.GetComponent<SpecialEvent>().specialEventNum++;

            Alert.SetActive(true);
        }

    }
}
