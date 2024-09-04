using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextGame : MonoBehaviour
{

    public void OnClickNextGame()
    {
        Debug.Log("Next Game");
        SceneManager.LoadScene("NextGameScene");
    }

    public void OnClickMainMenu()
    {
        Debug.Log("Main Menu");
        SceneManager.LoadScene("MainScene");

    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
