using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpecialEvent : MonoBehaviour
{
    public List<GameObject> SpecialEventObj;

    public float EventTime = 0;

    //�̺�Ʈ �߻� �ִ�ġ
    public int specialEventNum = 0;

    public int MGScene;

    GameObject Player;
    GameObject GameManager;
    GameObject ReputationBar;

    public string IsMGClear = "������";

    //public bool Run = false;
    void Start()
    {
        SpecialEventObj = new List<GameObject>();
        Player = GameObject.Find("Player");
        GameManager = GameObject.Find("GameManager");
        ReputationBar = GameObject.Find("ReputationBar");
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < specialEventNum; i++)
        {
            if(SpecialEventObj[i] != null)
            {
                SpEvent(SpecialEventObj[i]);
                
            }
            
        }
    }

    public void SpEvent(GameObject obj)
    {
        //���ѽð� ����
        if(GameObject.Find("Temp").GetComponent<Temp>().Run != true)
        {
            EventTime += Time.deltaTime;
        }
        

        if(EventTime <= 10.0f)
        {
            if (Vector3.Distance(obj.transform.position, Player.transform.position) <= 1.0f)
            {
                print("���� �̺�Ʈ Ȱ��ȭ ����");
                obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(true);


                if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Temp").GetComponent<Temp>().Run == false)
                {
                    //���� �Ͻ�����
                    //GameManager.GetComponent<GameManager>().PauseGame();

                    GameObject.Find("Temp").GetComponent<Temp>().Run = true;
                    

                    int rand = Random.Range(1, 2);
                    if (rand == 1)
                    {
                        //�̴ϰ���1 �� �ҷ�����
                        SceneManager.LoadScene("MiniGame1", LoadSceneMode.Additive);
                        MGScene = 1;
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                    }
                    else if (rand == 2)
                    {
                        //�̴ϰ���2 �� �ҷ�����
                        SceneManager.LoadScene("MiniGame2", LoadSceneMode.Additive);
                        MGScene = 2;
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                    }
                    else if (rand == 3)
                    {
                        //�̴ϰ���3 �� �ҷ�����
                        SceneManager.LoadScene("MiniGame3", LoadSceneMode.Additive);
                        MGScene = 3;
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                    }
                }

                EventClear(obj);


            }
        }

        else
        {
            if(EventTime > 10.0f)
            {
                obj.GetComponent<CustomerMove>().dir = obj.GetComponent<CustomerMove>().tempDir;

                EventTime = 0;

                //�� ����
                ReputationBar.GetComponent<Image>().fillAmount -= 0.2f;
                //���� �̺�Ʈ ����Ʈ�� ����
                SpecialEventObj.Remove(obj);
                //�̺�Ʈ �߻� ���� 1 ����
                specialEventNum--;

                obj.GetComponent<CustomerMove>().Alert.SetActive(false);

                //obj.GetComponent<CustomerMove>().buy = "������";

                GameObject.Find("Temp").GetComponent<Temp>().Run = false;
            }

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);
        }
    }

    public void EventClear(GameObject obj)
    {
        if (IsMGClear == "���� Ŭ����")
        {
            if (MGScene == 1)
            {
                StartCoroutine(UnloadSceneAsync("MiniGame1"));
            }

            EventTime = 0;
            IsMGClear = "������";
            GameManager.GetComponent<GameManager>().MoneyNum += 300;
            //obj.GetComponent<CustomerMove>().buy = "������";
            obj.GetComponent<CustomerMove>().dir = obj.GetComponent<CustomerMove>().tempDir;
            
            obj.GetComponent<CustomerMove>().Alert.SetActive(false);

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);

            //���� �̺�Ʈ ����Ʈ�� ����
            SpecialEventObj.Remove(obj);
            //�̺�Ʈ �߻� ���� 1 ����
            specialEventNum--;

            GameObject.Find("Temp").GetComponent<Temp>().Run = false;


        }
        else if (IsMGClear == "���� ����")
        {
            if (MGScene == 1)
            {
                StartCoroutine(UnloadSceneAsync("MiniGame1"));
            }


            EventTime = 0;
            IsMGClear = "������";
            //�� ����
            ReputationBar.GetComponent<Image>().fillAmount -= 0.2f;
            //obj.GetComponent<CustomerMove>().buy = "������";

            obj.GetComponent<CustomerMove>().dir = obj.GetComponent<CustomerMove>().tempDir;

            obj.GetComponent<CustomerMove>().Alert.SetActive(false);

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);

            //���� �̺�Ʈ ����Ʈ�� ����
            SpecialEventObj.Remove(obj);
            //�̺�Ʈ �߻� ���� 1 ����
            specialEventNum--;

            GameObject.Find("Temp").GetComponent<Temp>().Run = false;


        }
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        var sceneUnloadOperation = SceneManager.UnloadSceneAsync(sceneName);
        while (!sceneUnloadOperation.isDone)
        {
            yield return null;
        }
    }
}

