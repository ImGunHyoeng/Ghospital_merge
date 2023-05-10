using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject enemyPrefab;
    int exist = 0; //enemy 이미 있으면 추가 생성 x
    float AllLightOff =  0; //모든 불이 꺼져있는지 체크
    

    void Update()
    {
        
        GameObject[] off = GameObject.FindGameObjectsWithTag("Light");
        float check = 1.0f;
        for (int i = 0; i < off.Length; i++) // 모든 불이 꺼져있으면 AllLightoff =  1이 되도록 논리곱 사용
        {
           check *= off[i].GetComponent<LightController>().lightOff;
        }
        AllLightOff += check;

        if (this.exist == 0 && this.AllLightOff == 1.0f)
        {
            this.enemy = Instantiate(enemyPrefab);
            this.exist = 1;
        }
    }
}
