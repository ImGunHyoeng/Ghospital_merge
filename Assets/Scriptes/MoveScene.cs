using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    GameObject director;
    bool Can_Enter;
    private void Start()
    {
        Can_Enter = false;
        this.director = GameObject.Find("GameDirector");
    }

    private void Update()
    {
        if(Can_Enter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(gameObject.CompareTag("ExitRoom"))
                {
                    director.GetComponent<GameDirector>().ExitRoom();
                }

                if(gameObject.CompareTag("IntoRoom"))
                {
                    Debug.Log("Check Overlap with Door");
                    director.GetComponent<GameDirector>().IntoRoom();
                }
            }
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_Enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_Enter = false;
        }
    }
}
