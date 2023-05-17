using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject[] enemy;
    GameObject lightdir;
    GameObject phone;
    public int show_ph;

    public int[] RoomLights = { 0, 0, 0, 0, 0, 0 };
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
    }

    private void Update()
    {
        //복도에서 불관리하기
        
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

       


        //if(Input.GetKeyDown(KeyCode.H)) //H로 폰 키기
        //{
        //    Debug.Log("here OK");
        //    if (show_ph == 0)
        //    {
        //        Debug.Log("here OK");
        //        show_ph = 1;
        //        phone.GetComponent<CanvasGroup>().alpha = 1;
        //        phone.GetComponent<CanvasGroup>().interactable = true;
        //        phone.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //    }
        //    if (show_ph == 1)
        //    {
        //        show_ph = 0;
        //        phone.GetComponent<CanvasGroup>().alpha = 0;
        //        phone.GetComponent<CanvasGroup>().interactable = false;
        //        phone.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //    }

        //}

        enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(phone.GetComponent<CanvasGroup>().alpha == 0)
        {
            show_ph = 1;
            allstop();
        }
        if (phone.GetComponent<CanvasGroup>().alpha == 1)
        {
            show_ph = 0;
            allbegin();
        }


    }

    // 2 * 3 배열, 각각 방안의 전등의 꺼짐을 나타낸다. 각각의 전등이 일정한 시간 이후에 하나씩 꺼지고, 한 방에 모든 전구가 꺼지면 몬스터가 나온다.
    // 만약 모든 방의 불이 꺼졌으면 몬스터가 플레이가가 있는 복도에도 나오고 플레이어를 빠르게 추격한다.
    // 각 방안에 있는 전등은 자신의 번호에 맞게 적용된다. 

    public void allstop()
    {
        lightdir.GetComponent<LightDirector>().ratio = 0;
        for(int i = 0;i<enemy.Length;i++)
        {
            enemy[i].GetComponent<EnemyController>().speed = 0f;
        }
       
    }

    public void allbegin()
    {
        lightdir.GetComponent<LightDirector>().ratio = 5;
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<EnemyController>().speed = 3.0f;
        }
    }
   public void meetEnemy()
    {
        SceneManager.LoadScene("MeetEnemy");
    }

    public void IntoRoom()
    {
        SceneManager.LoadScene("Play");
    }
}
