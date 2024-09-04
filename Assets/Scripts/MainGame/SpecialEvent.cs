using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpecialEvent : MonoBehaviour
{
    public List<GameObject> SpecialEventObj;

    public float EventTime = 0;

    //이벤트 발생 최대치
    public int specialEventNum = 0;

    public int MGScene;

    GameObject Player;
    GameObject GameManager;
    GameObject ReputationBar;

    public string IsMGClear = "게임전";

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
        //제한시간 시작
        if(GameObject.Find("Temp").GetComponent<Temp>().Run != true)
        {
            EventTime += Time.deltaTime;
        }
        

        if(EventTime <= 10.0f)
        {
            if (Vector3.Distance(obj.transform.position, Player.transform.position) <= 1.0f)
            {
                print("진상 이벤트 활성화 가능");
                obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(true);


                if (Input.GetKeyDown(KeyCode.Space) && GameObject.Find("Temp").GetComponent<Temp>().Run == false)
                {
                    //게임 일시정지
                    //GameManager.GetComponent<GameManager>().PauseGame();

                    GameObject.Find("Temp").GetComponent<Temp>().Run = true;
                    

                    int rand = Random.Range(1, 2);
                    if (rand == 1)
                    {
                        //미니게임1 씬 불러오기
                        SceneManager.LoadScene("MiniGame1", LoadSceneMode.Additive);
                        MGScene = 1;
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                    }
                    else if (rand == 2)
                    {
                        //미니게임2 씬 불러오기
                        SceneManager.LoadScene("MiniGame2", LoadSceneMode.Additive);
                        MGScene = 2;
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                        GameObject.FindGameObjectWithTag("Manager").SetActive(false);
                    }
                    else if (rand == 3)
                    {
                        //미니게임3 씬 불러오기
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

                //명성 감소
                ReputationBar.GetComponent<Image>().fillAmount -= 0.2f;
                //진상 이벤트 리스트에 제거
                SpecialEventObj.Remove(obj);
                //이벤트 발생 숫자 1 감소
                specialEventNum--;

                obj.GetComponent<CustomerMove>().Alert.SetActive(false);

                //obj.GetComponent<CustomerMove>().buy = "구매함";

                GameObject.Find("Temp").GetComponent<Temp>().Run = false;
            }

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);
        }
    }

    public void EventClear(GameObject obj)
    {
        if (IsMGClear == "게임 클리어")
        {
            if (MGScene == 1)
            {
                StartCoroutine(UnloadSceneAsync("MiniGame1"));
            }

            EventTime = 0;
            IsMGClear = "게임전";
            GameManager.GetComponent<GameManager>().MoneyNum += 300;
            //obj.GetComponent<CustomerMove>().buy = "구매함";
            obj.GetComponent<CustomerMove>().dir = obj.GetComponent<CustomerMove>().tempDir;
            
            obj.GetComponent<CustomerMove>().Alert.SetActive(false);

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);

            //진상 이벤트 리스트에 제거
            SpecialEventObj.Remove(obj);
            //이벤트 발생 숫자 1 감소
            specialEventNum--;

            GameObject.Find("Temp").GetComponent<Temp>().Run = false;


        }
        else if (IsMGClear == "게임 실패")
        {
            if (MGScene == 1)
            {
                StartCoroutine(UnloadSceneAsync("MiniGame1"));
            }


            EventTime = 0;
            IsMGClear = "게임전";
            //명성 감소
            ReputationBar.GetComponent<Image>().fillAmount -= 0.2f;
            //obj.GetComponent<CustomerMove>().buy = "구매함";

            obj.GetComponent<CustomerMove>().dir = obj.GetComponent<CustomerMove>().tempDir;

            obj.GetComponent<CustomerMove>().Alert.SetActive(false);

            obj.GetComponent<CustomerMove>().EventSpaceActive.SetActive(false);

            //진상 이벤트 리스트에 제거
            SpecialEventObj.Remove(obj);
            //이벤트 발생 숫자 1 감소
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

