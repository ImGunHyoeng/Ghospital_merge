using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeLightOn : MonoBehaviour
{

    bool Can_TurnOn;
    GameObject lightdirector;
   
    void Start()
    {
        Can_TurnOn = false;
        lightdirector = GameObject.Find("LightDirector");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            
            Can_TurnOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_TurnOn = false;
        }
    }

    void Update()
    {
        if(Can_TurnOn)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                lightdirector.GetComponent<LightDirector>().Player_Turn_On_the_Light();
            }
        }
        
    }
}
