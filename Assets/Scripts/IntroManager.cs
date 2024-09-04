using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    // can ignore the update, it's just to make the coroutines get called for example

    [SerializeField] Image image = null;
    [SerializeField] TextMeshProUGUI text1 = null;
    [SerializeField] TextMeshProUGUI text2 = null;
    [SerializeField] TextMeshProUGUI text3 = null;
    [SerializeField] TextMeshProUGUI text4 = null;
    [SerializeField] TextMeshProUGUI text5 = null;
    [SerializeField] TextMeshProUGUI text6 = null;
    [SerializeField] TextMeshProUGUI text7 = null;
    [SerializeField] TextMeshProUGUI text8 = null;
    [SerializeField] TextMeshProUGUI text9 = null;


    void Start()
    {
        StartCoroutine(FadeTextToFullAlpha(2.0f, image, text1, text2, text3, text4, text5, text6, text7, text8, text9));
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Day1Scene");
        }
    }

    public IEnumerator FadeTextToFullAlpha(float t, Image i, TextMeshProUGUI t1, TextMeshProUGUI t2, TextMeshProUGUI t3, TextMeshProUGUI t4, TextMeshProUGUI t5
        , TextMeshProUGUI t6, TextMeshProUGUI t7, TextMeshProUGUI t8, TextMeshProUGUI t9)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        t1.color = new Color(t1.color.r, t1.color.g, t1.color.b, 0);
        t2.color = new Color(t2.color.r, t2.color.g, t2.color.b, 0);
        t3.color = new Color(t3.color.r, t3.color.g, t3.color.b, 0);
        t4.color = new Color(t4.color.r, t4.color.g, t4.color.b, 0);
        t5.color = new Color(t5.color.r, t5.color.g, t5.color.b, 0);
        t6.color = new Color(t6.color.r, t6.color.g, t6.color.b, 0);
        t7.color = new Color(t7.color.r, t7.color.g, t7.color.b, 0);
        t8.color = new Color(t8.color.r, t8.color.g, t8.color.b, 0);
        t9.color = new Color(t9.color.r, t9.color.g, t9.color.b, 0);


        while (t1.color.a < 1.0f)
        {
            t1.color = new Color(t1.color.r, t1.color.g, t1.color.b, t1.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t1.color = new Color(t1.color.r, t1.color.g, t1.color.b, 1);
        while (t1.color.a > 0.0f)
        {
            t1.color = new Color(t1.color.r, t1.color.g, t1.color.b, t1.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t2.color.a < 1.0f)
        {
            t2.color = new Color(t2.color.r, t2.color.g, t2.color.b, t2.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t2.color = new Color(t2.color.r, t2.color.g, t2.color.b, 1);
        while (t2.color.a > 0.0f)
        {
            t2.color = new Color(t2.color.r, t2.color.g, t2.color.b, t2.color.a - (Time.deltaTime / t));
            yield return null;
        }

        while (t3.color.a < 1.0f)
        {
            t3.color = new Color(t3.color.r, t3.color.g, t3.color.b, t3.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t3.color = new Color(t3.color.r, t3.color.g, t3.color.b, 1);
        while (t3.color.a > 0.0f)
        {
            t3.color = new Color(t3.color.r, t3.color.g, t3.color.b, t3.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t4.color.a < 1.0f)
        {
            t4.color = new Color(t4.color.r, t4.color.g, t4.color.b, t4.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t4.color = new Color(t4.color.r, t4.color.g, t4.color.b, 1);
        while (t4.color.a > 0.0f)
        {
            t4.color = new Color(t4.color.r, t4.color.g, t4.color.b, t4.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t5.color.a < 1.0f)
        {
            t5.color = new Color(t5.color.r, t5.color.g, t5.color.b, t5.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t5.color = new Color(t5.color.r, t5.color.g, t5.color.b, 1);
        while (t5.color.a > 0.0f)
        {
            t5.color = new Color(t5.color.r, t5.color.g, t5.color.b, t5.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t6.color.a < 1.0f)
        {
            t6.color = new Color(t6.color.r, t6.color.g, t6.color.b, t6.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t6.color = new Color(t6.color.r, t6.color.g, t6.color.b, 1);
        while (t6.color.a > 0.0f)
        {
            t6.color = new Color(t6.color.r, t6.color.g, t6.color.b, t6.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t7.color.a < 1.0f)
        {
            t7.color = new Color(t7.color.r, t7.color.g, t7.color.b, t7.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t7.color = new Color(t7.color.r, t7.color.g, t7.color.b, 1);
        while (t7.color.a > 0.0f)
        {
            t7.color = new Color(t7.color.r, t7.color.g, t7.color.b, t7.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t8.color.a < 1.0f)
        {
            t8.color = new Color(t8.color.r, t8.color.g, t8.color.b, t8.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t8.color = new Color(t8.color.r, t8.color.g, t8.color.b, 1);
        while (t8.color.a > 0.0f)
        {
            t8.color = new Color(t8.color.r, t8.color.g, t8.color.b, t8.color.a - (Time.deltaTime / t));
            yield return null;
        }


        while (t9.color.a < 1.0f)
        {
            t9.color = new Color(t9.color.r, t9.color.g, t9.color.b, t9.color.a + (Time.deltaTime / t));
            yield return null;
        }
        t9.color = new Color(t9.color.r, t9.color.g, t9.color.b, 1);
        while (t9.color.a > 0.0f)
        {
            t9.color = new Color(t9.color.r, t9.color.g, t9.color.b, t9.color.a - (Time.deltaTime / t));
            yield return null;
        }

        /*while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }*/

        SceneManager.LoadScene("Day1Scene");
    }

    /* 변수 t는 이미지나 텍스트가 나타나거나 사라지는 데 소요되는 시간을 의미한다.(time)
       즉, Image i가 1.5초동안 천천히 나타났다가 1.5초동안 천천히 사라지고,
       이후 Text(TMP) j가 1.5초동안 천천히 나타났다가 1.5초동안 천천히 사라진다.

       이미지나 텍스트의 r, g, b 값은 그대로 두고,
       투명도를 의미하는 a값을 0에서 1까지 증가시켰다가
       1에서 0까지 감소시키는 방식으로 나타남과 사라짐을 구현하였다.*/

}