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
        //���� �̴ϰ��� �� �ҷ�����
        SceneManager.LoadScene("Shop", LoadSceneMode.Additive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShopButtonOpen()
    {
        print("���� ����");
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Shop"));

        //���� �Ͻ�����
        GameObject.Find("GameManager").GetComponent<GameManager>().PauseGame();

        //���� ȭ�� �ѱ�
        GameObject.Find("ShopManager").GetComponent<ShopManager>().ShopScene.SetActive(true);


    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // ����� ������ ���α׷� ����
#endif
    }

}
