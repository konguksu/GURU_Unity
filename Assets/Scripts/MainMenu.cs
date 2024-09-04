using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnClickTutorial()
    {
        Debug.Log("Tutorial");
    }

    public void OnClickNewGame()
    {
        Debug.Log("New Game");
        SceneManager.LoadScene("IntroScene");
    }


    public void OnClickExitGame()
    {
        Debug.Log("Exit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ����� ������ ���α׷� ����
#endif
    }
}