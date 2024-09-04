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

    // �迭�� ���� ���� �޼���
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

    // ���� �� ���� ī�带 ������ �� �ִ� ��������
    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    // ��� ī�尡 ����������
    public bool AllCardsFlipped
    {
        get { return score == (columns * rows) / 2; }
    }

    // ī�� ������ �̺�Ʈ�� �߻����� �� ȣ��
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

        // ��� ī�尡 �������ٸ� ���� �ε�
        if (AllCardsFlipped)
        {
            GameObject.Find("Temp").GetComponent<Temp>().manager1.SetActive(true);
            GameObject.Find("Temp").GetComponent<Temp>().manager2.SetActive(true);

            GameObject.Find("GameManager").GetComponent<GameManager>().IsDrinkMGClear = "���� Ŭ����";
            
            UnloadMiniGame3Scene();
        }
    }

    public int sceneToLoad = 0;

    // ī�� ������ ����� Ȯ��
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
