//SpikeScript.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeScript : MonoBehaviour
{
    public SpikeGenerator spikeGenerator;

    void Update()
    {
        transform.Translate(Vector2.left * spikeGenerator.currentSpeed * Time.unscaledDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 여기서 게임 종료 처리를 수행합니다.
            Debug.Log("Game Over");

            // 비활성화된 매니저들 다시 활성화
            GameObject.Find("Temp").GetComponent<Temp>().manager1.SetActive(true);
            GameObject.Find("Temp").GetComponent<Temp>().manager2.SetActive(true);

            GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 실패";

            Destroy(this.gameObject);

            


        }
    }

    //// 추가된 BackToMainGameFail 함수 호출 부분
    //public void BackToMainGameFail()
    //{
    //    Time.timeScale = 1.0f;
    //    GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 실패";
    //    SceneManager.UnloadScene(SceneManager.GetSceneByName("MiniGame" + GameObject.Find("GameManager").GetComponent<SpecialEvent>().MGScene));
    //}
}
