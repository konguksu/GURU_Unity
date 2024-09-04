using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MGButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MiniGame" + GameObject.Find("GameManager").GetComponent<SpecialEvent>().MGScene));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BackToMainGameClear()
    {
        Time.timeScale = 1.0f;

        GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 클리어";

        StartCoroutine(UnloadSceneAsync("MiniGame" + GameObject.Find("GameManager").GetComponent<SpecialEvent>().MGScene));
    }

    public void BackToMainGameFail()
    {
        Time.timeScale = 1.0f;
        GameObject.Find("GameManager").GetComponent<SpecialEvent>().IsMGClear = "게임 실패";

        StartCoroutine(UnloadSceneAsync("MiniGame" + GameObject.Find("GameManager").GetComponent<SpecialEvent>().MGScene));
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
