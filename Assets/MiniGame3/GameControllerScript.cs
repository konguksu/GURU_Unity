using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerScript : MonoBehaviour
{
    public const int columns = 4;
    public const int rows = 2;

    public const float Xspace = 4f;
    public const float Yspace = -5f;

    [SerializeField] private MainImageScript startObject;
    [SerializeField] private Sprite[] images;

    // 배열을 섞기 위한 메서드
    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for (int i = 0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("DrinkMiniGame"));

        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3 };
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                MainImageScript gameImage;
                if (i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImageScript;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
                gameImage.GetComponent<SpriteRenderer>().sortingLayerName = "MiniGame";
            }
        }
    }

    private MainImageScript firstOpen;
    private MainImageScript secondOpen;

    private int score = 0;
    private int attempts = 0;

    [SerializeField] private TextMesh scoreText;
    [SerializeField] private TextMesh attemptsText;

    // 현재 두 장의 카드를 뒤집을 수 있는 상태인지
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // 모든 카드가 뒤집혔는지
    public bool AllCardsFlipped
    {
        get { return score == (columns * rows) / 2; }
    }

    // 카드 뒤집기 이벤트가 발생했을 때 호출
    public void imageOpened(MainImageScript startObject)
    {
        if (firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }

        // 모든 카드가 뒤집혔다면 씬을 로드
        if (AllCardsFlipped)
        {
            GameObject.Find("Temp").GetComponent<Temp>().manager1.SetActive(true);
            GameObject.Find("Temp").GetComponent<Temp>().manager2.SetActive(true);

            GameObject.Find("GameManager").GetComponent<GameManager>().IsDrinkMGClear = "게임 클리어";
            
            UnloadMiniGame3Scene();
        }
    }

    public int sceneToLoad = 0;

    // 카드 뒤집기 결과를 확인
    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            score++;
            scoreText.text = "Score: " + score;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }

        attempts++;
        attemptsText.text = "Attempts: " + attempts;

        firstOpen = null;
        secondOpen = null;
    }

    private IEnumerator UnloadSceneAsync(string sceneName)
    {
        yield return SceneManager.UnloadSceneAsync(sceneName);
    }

    private void UnloadMiniGame3Scene()
    {
        StartCoroutine(UnloadSceneAsync("DrinkMiniGame"));
    }
}
