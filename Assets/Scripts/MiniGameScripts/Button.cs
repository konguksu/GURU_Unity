using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    GameObject GameManager;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("DrinkMiniGame"));
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMainGameClear()
    {
        Time.timeScale = 1.0f;

        GameObject.Find("GameManager").GetComponent<GameManager>().IsDrinkMGClear = "���� Ŭ����";

        StartCoroutine(UnloadSceneAsync("DrinkMiniGame"));
    }

    public void BackToMainGameFail()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("GameManager").GetComponent<GameManager>().IsDrinkMGClear = "���� ����";

        StartCoroutine(UnloadSceneAsync("DrinkMiniGame"));
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        AsyncOperation asyncUnload = SceneManager.UnloadSceneAsync(sceneName);
        while (!asyncUnload.isDone)
        {
            yield return null;
        }
    }
}
