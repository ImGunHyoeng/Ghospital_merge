using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    // when gameobject that has patients'tag is acting,  patient can teleport to random Path or Other Room one by one randomly
   
    GameObject director;
    public int number_of_patient;

    bool Can_lift = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Can_lift = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Can_lift = false;
        }
    }
    private void Start()
    {
        director = GameObject.Find("GameDirector");
    }

    private void Update()
    {


        if (Can_lift)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                // Play patient's wake up animation with Coroutine
                director.GetComponent<GameDirector>().Room_Patients[number_of_patient] = 1;
            }
        }
    }
}
