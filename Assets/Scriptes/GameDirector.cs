using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject lightdir;
    GameObject phone;
    public int show_ph;
    public float timeScale;

    public int[] RoomLights = { 0, 0, 0, 0, 0, 0 };
    public int[] PatientinBed = { 0, 0, 0, 0, 0, 0 };
    float span = 3.0f;
    float delta = 0;
    public int ratio = 5;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameDirector>();
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
       
        lightdir = GameObject.Find("LightDirector");
        phone = GameObject.Find("Playmenu");
        show_ph = 0;
        timeScale = 1;
    }

    private void Update()
    {
        Time.timeScale = timeScale; //Manage game Runing

        int a = Random.Range(0, RoomLights.Length);
        delta += Time.deltaTime;
        if (delta > span)
        {
            int random = Random.Range(0, 10);
            if (ratio > random)
            {
                if (RoomLights[a] == 0)
                {
                    RoomLights[a] = 1;
                }
            }
            delta = 0;
        }
        
    }


    public void TimeStop()
    {
        timeScale = 0;
    }

    public void TimeStart()
    {
        timeScale = 1;
    }

   public void meetEnemy()
    {
        SceneManager.LoadScene("MeetEnemy");
    }

    public void ExitRoom()
    {
        GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().exist = 0;
        SceneManager.LoadScene("Path");
    }
    public void IntoRoom()
    {
        GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().exist = 0;
        SceneManager.LoadScene("Play");
    }
}
