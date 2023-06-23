using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndDirector : MonoBehaviour
{
    GameObject enemyvideo;

    private void Start()
    {
        enemyvideo = GameObject.Find("Canvas_video");
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

    }
    void MeetFastEnemy()
    {

    }

}
