//SpikeGenerator.cs

using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SpikeGenerator : MonoBehaviour
{
    public GameObject spike;
    public float currentSpeed;
    public float SpeedMultiplier;
    private int spikeCount = 0;  // 추가한 변수, 생성된 장애물의 수를 추적합니다.
    private int maxSpikes = 6;  // 최대 장애물 생성 횟수를 5로 설정합니다.

    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MiniGame1"));
    }
    void Awake()
    {
        
        currentSpeed = 12f;
        StartCoroutine(GenerateSpikes());
    }

    IEnumerator GenerateSpikes()
    {
        while (spikeCount < maxSpikes)
        {
            generateSpike();
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before generating the next spike
        }
    }

    public void generateSpike()
    {
        if (spikeCount >= maxSpikes) // 생성된 장애물이 5개를 초과하면, 더이상 생성하지 않습니다.
            return;

        GameObject SpikeIns = Instantiate(spike, transform.position, transform.rotation);
        SpikeIns.GetComponent<SpikeScript>().spikeGenerator = this;
        //레이어 순서 설정
        SpikeIns.GetComponent<SpriteRenderer>().sortingLayerName = "MiniGame";
        spikeCount++;// 새로운 장애물이 생성될 때마다 카운트를 증가시킵니다.
    }    
}
