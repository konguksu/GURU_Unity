// Theif.cs
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Theif : MonoBehaviour
{
    public float speed = 1.0f; // 이동 속도 설정, 원하는 값으로 변경 가능

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // 왼쪽으로 이동
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") // Assuming the player object has a tag of "Player"
        {
            Debug.Log("Game Clear");

            // Stop game time
            //Time.timeScale = 0;


            // 비활성화된 매니저들 다시 활성화
            GameObject.Find("Temp").GetComponent<Temp>().manager1.SetActive(true);
            GameObject.Find("Temp").GetComponent<Temp>().manager2.SetActive(true);

            GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 클리어";

          
        }
    }

    //// 추가된 BackToMainGameFail 함수 호출 부분
    //public void BackToMainGameFail()
    //{
    //    Time.timeScale = 1.0f;
    //    GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 클리어";
    //    SceneManager.UnloadScene(SceneManager.GetSceneByName("MiniGame" + GameObject.Find("GameManager").GetComponent<SpecialEvent>().MGScene));
    //}
}
