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

    //���� ��ġ
    // public Vector3 GenPos = new Vector3(8.2f, 3.0f, 0f);
    public GameObject GenPos;


    //������ȯ ��ġ �迭
    public Vector3[] P;

    //�մ� �̵� �ӵ�
    public Vector3 MoveX = new Vector3(2f, 0, 0);
    public Vector3 MoveY = new Vector3(0, 2f, 0);

    //�մ� �̵� ����
    public string dir;
    public string tempDir;

    //���� ���� ����
    int rand;

    //��ȯ ��ġ�� �����ߴ°�
    bool DirChange = true;

    //���� ��°�
    public string buy;

    //��&������ġ �迭
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

        //���� ��ġ
        GenPos = GameObject.Find("GenPos");
        this.transform.position = GenPos.transform.position;
        buy = "���� ��";
        //���� �̵� ����
        rand = Random.Range(0, 2);

        //��&���� ��ġ �迭 
        bread = new GameObject[16];
        breadBuyPos = new Vector3[16];



        print("���� ����(0��1��): " + rand);
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
        else if (dir == "DrinkOrder" || dir == "�̺�Ʈ ����" || dir == "�Ͻ�����")
        {
            transform.Translate(0, 0, 0);
            x = 0;
            y = 0;
        }
        //else if (dir == "�̺�Ʈ ����")
        //{
        //    transform.Translate(0, 0, 0);
        //}
        //�ִϸ��̼�
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

        if (buy == "���� ��")
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

        //���� ���� �� ���ð� ����
        if (buy == "���� ����")
        {
            print("���� ��� ��");

            buyTime += Time.deltaTime;
            if (buyTime >= 0.2f)
            {
                buyTime = 0;
                buy = "���� ��";
            }
        }

        if (DirChange == false)
        {
            //������ȯ ���� ���� �ð� ���� �� Ǯ��
            time += Time.deltaTime;

            if (time >= StopTime)
            {
                time = 0;
                DirChange = true;
            }

        }

        //�̴ϰ��� �̵��� ����(�̺�Ʈ �߻� �մ��� �ƴϰ�, ������ �Ͻ������϶��� ���� x)
        if ((GameObject.Find("Temp").GetComponent<Temp>().Run == true || GameObject.Find("Temp").GetComponent<Temp>().Run2 == true) && dir != "�̺�Ʈ ����" && dir != "�Ͻ�����")
        {
            //���� �̵����� �ӽ�����
            tempDir = dir;
            //�̵� �Ͻ�����
            dir = "�Ͻ�����";
        }

        //�̴ϰ��� ����ǰ� �Ͻ����� ���¿�����
        else if ((GameObject.Find("Temp").GetComponent<Temp>().Run == false || GameObject.Find("Temp").GetComponent<Temp>().Run2 == false) && dir == "�Ͻ�����")
        {
            //�ӽ� �����ߴ� �̵��������� �ٽ� ����
            dir = tempDir;

        }


    }

    void ChangeDirection()
    {
        //���� �� �̵�
        if (buy == "���� ��")
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

                //20���� Ȯ���� �����ֹ��̵�
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

                //20���� Ȯ���� �����ֹ��̵� (�ٸ� �մ��� �ֹ����� �ƴ϶��)
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

        //���� �� �̵�
        if (buy == "������")
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

            //�Ա� ���޽� ������Ʈ ����
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
                //�� ����
                if (a == 0)
                {
                    //��� ������
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 300;

                        print("��1 ���: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "������";
                    }
                    else
                    {
                        print("������");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "���� ����";
                    }

                }
                //�� ���ž���
                else if (a == 1)
                {
                    buy = "���� ����";
                    print("��1 ���ž���");
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
                //30���� Ȯ���� �� ����
                if (a <= 0.3)
                {
                    //��� ������
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        //��� ����
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        //�� ���� & �ؽ�Ʈ ����
                        GameManager.GetComponent<GameManager>().MoneyNum += 400;

                        print("��1 ���: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "������";
                    }
                    else
                    {
                        print("������");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "���� ����";
                    }

                }
                //�� ���ž���
                else
                {
                    buy = "���� ����";
                    print("��1 ���ž���");
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
                //20���� Ȯ���� �� ����
                if (a <= 0.2)
                {
                    //��� ������
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 500;

                        print("��1 ���: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "������";
                    }
                    else
                    {
                        print("������");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "���� ����";
                    }

                }
                //�� ���ž���
                else
                {
                    buy = "���� ����";
                    print("��1 ���ž���");
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
                //10���� Ȯ���� �� ����
                if (a <= 0.1)
                {
                    //��� ������
                    if (bread[i].GetComponent<BreadCompo>().StockNum > 0)
                    {
                        bread[i].GetComponent<BreadCompo>().StockNum--;
                        GameManager.GetComponent<GameManager>().MoneyNum += 700;

                        print("��1 ���: " + bread[i].GetComponent<BreadCompo>().StockNum);
                        buy = "������";
                    }
                    else
                    {
                        print("������");
                        ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
                        buy = "���� ����";
                    }

                }
                //�� ���ž���
                else
                {
                    buy = "���� ����";
                    print("��1 ���ž���");
                }

            }
        }
    }
    void DrinkOrder()
    {


        //���ѽð� ����
        if (GameObject.Find("Temp").GetComponent<Temp>().Run2 != true)
        {
            //�ֹ� �ð����� ����
            orderTime += Time.deltaTime;
        }


        //�ð����� �ȿ� �ֹ� ���޾�����
        if (orderTime >= 0.3f && Alert.activeSelf == true)
        {
            dir = "Right";

            orderTime = 0;
            Alert.SetActive(false);
            ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;
            GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);

            buy = "������";


        }

        //�ð� ���� ���� ��
        else if (orderTime <= 0.3f)
        {
            Alert.SetActive(true);
            GameManager.GetComponent<GameManager>().DrinkMiniGame();

            //�̴ϰ��� Ŭ����� 300�� ����
            if (GameManager.GetComponent<GameManager>().IsDrinkMGClear == "���� Ŭ����")
            {
                GameManager.GetComponent<GameManager>().MoneyNum += 800;
                dir = "Right";
                orderTime = 0;
                Alert.SetActive(false);

                GameObject.Find("Temp").GetComponent<Temp>().Run2 = false;

                GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);
                GameManager.GetComponent<GameManager>().DrinkOrderOBJ = null;
                GameManager.GetComponent<GameManager>().IsDrinkMGClear = "������";
                buy = "������";
            }

            //�̴ϰ��� Ŭ���� ���н� �� ����
            else if (GameManager.GetComponent<GameManager>().IsDrinkMGClear == "���� ����")
            {
                dir = "Right";
                orderTime = 0;
                Alert.SetActive(false);
                ReputationBar.GetComponent<Image>().fillAmount -= 0.1f;

                GameObject.Find("Temp").GetComponent<Temp>().Run2 = false;

                GameManager.GetComponent<GameManager>().DrinkActive.SetActive(false);
                GameManager.GetComponent<GameManager>().DrinkOrderOBJ = null;
                GameManager.GetComponent<GameManager>().IsDrinkMGClear = "������";
                buy = "������";
            }
        }

    }

    void SpecialEvent()
    {
        print("���� �̺�Ʈ ����?");

        if ((Random.Range(0f, 1.0f) <= 0.1f) && (GameManager.GetComponent<SpecialEvent>().specialEventNum < 3) && buy == "���� ��")
        {

            print("���� �̺�Ʈ �ߵ�");

            if (dir != "�Ͻ�����")
            {
                tempDir = dir;
            }


            dir = "�̺�Ʈ ����";

            buy = "������";
            //���� �̺�Ʈ ����Ʈ�� �߰�
            GameManager.GetComponent<SpecialEvent>().SpecialEventObj.Add(this.gameObject);
            //�̺�Ʈ �߻� ���� 1 ����
            GameManager.GetComponent<SpecialEvent>().specialEventNum++;

            Alert.SetActive(true);
        }

    }
}
