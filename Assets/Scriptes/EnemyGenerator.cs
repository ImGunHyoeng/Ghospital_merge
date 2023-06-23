using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyGenerator : MonoBehaviour
{
   
    GameObject enemy;
    public GameObject slow_enemyPrefab;
    public GameObject fast_enemyPrefab;
    public bool enemy_exist; 
    [SerializeField] bool All_RoomLightOff;
    [SerializeField] bool AllLightOff;
    float check; //this variable check room light off or not and check room patient gone or not
    public int patten;
    Scene scene;
    GameObject room_bg;


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
        AllLightOff = false;
        All_RoomLightOff = false;
        enemy_exist = false;
        //StartCoroutine(Check_Enemy_Exist());
      
    }


    void Update()
    {
        Check_Enemy_Exist();

        scene = SceneManager.GetActiveScene();
        check = 0f;
        
        if (scene.name == "PatientRoom101" || scene.name == "PatientRoom102")
        {
            room_bg = GameObject.Find("Canvas_BG");
            Check_Room_Light();

        }

        Check_ALL_Light();

    }
    //set anim  to walk, and set anim to disappear

    void Check_Room_Light()
    {
            GameObject[] off = GameObject.FindGameObjectsWithTag("Light");

            for (int i = 0; i < off.Length; i++)
            {
                check += off[i].GetComponent<LightController>().lightOff;
            }

            if (check == 0)
            {
                All_RoomLightOff = true;
            }
            if (check >= 1)
            {
                All_RoomLightOff = false;
            }
       

            if (this.enemy_exist == false && this.All_RoomLightOff == true && AllLightOff == false)
            {
            //room_bg.transform.Find("BG_LightOn").gameObject.SetActive(false);
            
            Appear_SlowEnemy();
            }

            if (All_RoomLightOff == false) //when the player turn on any light
            {
                enemy_exist = false;
            //room_bg.transform.Find("BG_LightOn").gameObject.SetActive(true);
            
            Disappear_Enemy();
            }
    }

    void Check_ALL_Light()
    {
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().Room_Lights;

        for (int i = 0; i < RoomLights.Length; i++)
        {
            check += RoomLights[i];
        }

        if (check == 0)
        {
            AllLightOff = true;
        }
        if (check >= 1)
        {
            AllLightOff = false;
        }


        if (this.enemy_exist == false && this.AllLightOff == true)
        {
            Appear_FastEnemy();
        }
    }

    void Appear_SlowEnemy()
    {
        this.enemy = Instantiate(slow_enemyPrefab);
        //this.enemy_exist = true;
        this.patten = 1;
    }

    void Appear_FastEnemy()
    {
        this.enemy = Instantiate(fast_enemyPrefab);
        //this.enemy_exist = true;
        this.patten = 2;
    }

    void Check_Enemy_Exist()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            enemy_exist = true;
        }
        else
        {
            enemy_exist = false;
        }
    }

    public bool Disappear_Enemy()
    {
        return enemy_exist;
    }
    //IEnumerator Check_Enemy_Exist()
    //{
    //    if (GameObject.FindGameObjectWithTag("Enemy"))
    //    {
    //        enemy_exist = true;
    //    }
    //    else
    //    {
    //        enemy_exist = false;
    //    }
    //    yield return new WaitForSeconds(0.1f);
    //    StartCoroutine(Check_Enemy_Exist());
    //}

}
