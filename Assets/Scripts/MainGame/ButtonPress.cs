using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPress : MonoBehaviour
{
    public GameObject ShopPopUp;
    // Start is called before the first frame update
    void Start()
    {
        //음료 미니게임 씬 불러오기
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopButtonOpen()
    {
        print("상점 오픈");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Shop"));

        //게임 일시정지
        GameObject.Find("GameManager").GetComponent<GameManager>().PauseGame();

        //상점 화면 켜기
        GameObject.Find("ShopManager").GetComponent<ShopManager>().ShopScene.SetActive(true);


    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 실행된 게임의 프로그램 종료
#endif
    }

}
