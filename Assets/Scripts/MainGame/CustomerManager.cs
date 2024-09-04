using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //손님 생성 속도
    public float Genspeed = 3f;

    //시간 측정
    float time;

    //손님 프리팹
    public GameObject customer1;
    public GameObject customer2;

    

    void Start()
    {
        
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        //생성 속도만큼 시간이 흐르면
        if(time >= Genspeed)
        {
            //시간 초기화
            time = 0;
            //생성 속도 재설정
            Genspeed = Random.Range(2f, 6f);

            int rand = Random.Range(0, 2);
            print(rand);

            if(rand == 0)
            {
                GameObject customer = Instantiate(customer1);
                
            }
            else 
            {
                GameObject customer = Instantiate(customer2);
                
            }
        }
    }
}
