using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject enemyPrefab;
    int exist = 0; //enemy �̹� ������ �߰� ���� x
    float AllLightOff =  0; //��� ���� �����ִ��� üũ
    public int patten; 
   

    private void Awake()
    {
        var obj = FindObjectsOfType<EnemyGenerator>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Update()
    {
        float check = 1.0f;
        GameObject[] off = GameObject.FindGameObjectsWithTag("Light");
        if (off==null ) //�������� ��� ���� ���� �� ���� ���
        {
            
            int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights;

            for (int i = 0; i < RoomLights.Length; i++)
            {
                check *= RoomLights[i];
          
            }
            AllLightOff += check;
            
            if (this.exist == 0 && this.AllLightOff == 1.0f)
            {
               
                this.enemy = Instantiate(enemyPrefab);
                this.exist = 1;
                this.patten = 2;
            }
        }
        else //����� ���� ���� ���
        {
            Debug.Log("IM Here");
            for (int i = 0; i < off.Length; i++) // ��� ���� ���������� AllLightoff =  1�� �ǵ��� ����� ���
            {
                check *= off[i].GetComponent<LightController>().lightOff;
            }
            AllLightOff += check;

            if (this.exist == 0 && this.AllLightOff == 1.0f)
            {
                this.enemy = Instantiate(enemyPrefab);
                this.exist = 1;
                this.patten = 1;
            }

        }
        
    }
}
