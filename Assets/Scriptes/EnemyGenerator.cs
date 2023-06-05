using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject slow_enemyPrefab;
    public GameObject fast_enemyPrefab;
    public int exist = 0; 
    public float All_RoomLightOff; 
    public float AllLightOff; 
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
        AllLightOff = 0;
        All_RoomLightOff = 0;
    }


    void Update()
    {
        scene = SceneManager.GetActiveScene();
        float check = 1.0f;
        
        if (scene.name == "Play")
        {
            
            GameObject[] off = GameObject.FindGameObjectsWithTag("Light");

            for (int i = 0; i < off.Length; i++)
            {
                check *= off[i].GetComponent<LightController>().lightOff; 
            }
            
            All_RoomLightOff = check;

            if (this.exist == 0 && this.All_RoomLightOff == 1.0f && AllLightOff == 0.0f)
            {
                Appear_SlowEnemy();
            }

            if (All_RoomLightOff == 0f) //when the player turn on any light
            {
                Destroy(enemy);
                exist = 0;
            }

        }
        
            
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights;

        for (int i = 0; i < RoomLights.Length; i++)
        {
            check *= RoomLights[i];
        }
        AllLightOff = check;

        if (this.exist == 0 && this.AllLightOff == 1.0f)
        {
            Appear_FastEnemy();
        }

    }

    void Appear_SlowEnemy()
    {
        this.enemy = Instantiate(slow_enemyPrefab);
        this.exist = 1;
        this.patten = 1;
    }

    void Appear_FastEnemy()
    {
        this.enemy = Instantiate(fast_enemyPrefab);
        this.exist = 1;
        this.patten = 2;
    }
}
