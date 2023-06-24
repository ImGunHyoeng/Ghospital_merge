using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndDirector : MonoBehaviour
{
    GameObject enemyvideo;
    int enemy_type;

    GameObject GmD;
    GameObject EneD;
    GameObject Play;
    GameObject CanvasTim;
    GameObject CanvasPh;

    private void Start()
    {
        enemyvideo = GameObject.Find("Canvas_video");
        
        enemy_type = GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().patten;

        GmD = GameObject.Find("GameDirector");
        EneD = GameObject.Find("EnemyGenerator");
        Play = GameObject.FindWithTag("Player");
        CanvasTim = GameObject.Find("Canvas_Timer");
        CanvasPh = GameObject.Find("Canvas_Phone");
        AllDelete();

        Debug.Log(enemy_type + "-------------");
        if(enemy_type == 1)
              MeetSlowEnemy();
        if (enemy_type == 2)
              MeetFastEnemy();

        Destroy(EneD);
        

    }
    private void Update()
    {
       if(Input.GetMouseButton(0))
        {
            GoTitle();
        }

    }
    void GoTitle()
    { 
      SceneLoader.LoadSceneHandle("Title", 0); 
    }
    void MeetSlowEnemy()
    {
        enemyvideo.transform.Find("RI_slowenemy_vod").gameObject.SetActive(true);
    }
    void MeetFastEnemy()
    {
        enemyvideo.transform.Find("RI_fastenemy_vod").gameObject.SetActive(true);
    }


    void AllDelete()
    {
        if (GmD == null || Play == null || CanvasTim == null || CanvasPh == null)
            return;
        
        Destroy(GmD);
        Destroy(Play);
        Destroy(CanvasTim);
        Destroy(CanvasPh);
    }
}
