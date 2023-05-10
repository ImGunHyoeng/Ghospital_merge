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

    private void Start()
    {
       
        lightdir = GameObject.Find("LightDirector");
        phone = GameObject.Find("Playmenu");
        show_ph = 0;
    }

    private void Update()
    {
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
}
