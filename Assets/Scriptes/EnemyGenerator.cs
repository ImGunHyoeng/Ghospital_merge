using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject enemyPrefab;
    int exist = 0; 
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
            
            AllLightOff = check;

            if (this.exist == 0 && this.AllLightOff == 1.0f)
            {
                this.enemy = Instantiate(enemyPrefab);
                this.exist = 1;
                this.patten = 1;
            }

        }
        if (scene.name == "Path")
        {
            
            int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights;

            for (int i = 0; i < RoomLights.Length; i++)
            {
                check *= RoomLights[i];

            }
            AllLightOff = check;

            if (this.exist == 0 && this.AllLightOff == 1.0f)
            {

                this.enemy = Instantiate(enemyPrefab);
                this.exist = 1;
                this.patten = 2;
            }

        }

       
        if (AllLightOff == 0f) //when the player turn on any light
        {
            Destroy(enemy);
            exist = 0;
        }


    }
}
