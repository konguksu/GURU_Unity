using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    //�մ� ���� �ӵ�
    public float Genspeed = 3f;

    //�ð� ����
    float time;

    //�մ� ������
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

        //���� �ӵ���ŭ �ð��� �帣��
        if(time >= Genspeed)
        {
            //�ð� �ʱ�ȭ
            time = 0;
            //���� �ӵ� �缳��
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
