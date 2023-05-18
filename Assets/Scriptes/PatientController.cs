using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{

    GameObject bed;
    bool Can_lift = false;

    private void Start()
    {
        bed = GameObject.Find("Bed");
    }

    private void Update()
    {
        if(Can_lift)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                bed.GetComponent<BedController>().PatientComeback();
            }
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.tag == "Player")
    //    {
    //        bed.GetComponent<BedController>().PatientComeback();
    //    }

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_lift = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_lift = false;
        }
    }
}
