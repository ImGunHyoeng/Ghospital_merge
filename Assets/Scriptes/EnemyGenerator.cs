using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject enemyPrefab;
    int exist = 0; //enemy 이미 있으면 추가 생성 x
    float AllLightOff =  0; //모든 불이 꺼져있는지 체크
    public int patten;
    Scene scene;

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
    private void Start()
    {
       
    }


    void Update()
    {
        scene = SceneManager.GetActiveScene();
        Debug.Log(scene.name);
        float check = 1.0f;
        
        if (scene.name == "Play")//방안의 불이 꺼진 경우
        {
            GameObject[] off = GameObject.FindGameObjectsWithTag("Light");

            for (int i = 0; i < off.Length; i++) // 모든 불이 꺼져있으면 AllLightoff =  1이 되도록 논리곱 사용
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
        if (scene.name == "Path")
        {
            //복도에서 모든 방의 불이 다 꺼진 경우
            Debug.Log("IM Here");
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
        
        
        
    }
}
