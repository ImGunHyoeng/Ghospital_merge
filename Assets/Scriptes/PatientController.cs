using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{
    // when gameobject that has patients'tag is acting,  patient can teleport to random Path or Other Room one by one randomly
    GameObject bed;
    GameObject clock;

    float delta;
    int ratio;

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
        bed = GameObject.Find("Bed");
        clock = GameObject.Find("Time");
    }

    private void Update()
    {

        //if (clock.GetComponent<Phone_TImer>().gettime() >= 3) //if clock time is more than 3AM
        //{
        //    delta += Time.deltaTime; //Patient Event Start
        //    if (delta > 5.0f)
        //    {
        //        int rand_num = Random.Range(0, 10);
        //        if (rand_num > ratio)
        //        {
        //            bed.GetComponent<BedController>().PatientGone();
        //        }
        //        delta = 0f;
        //    }
        //}


        if (Can_lift)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                //plus patient comeback anim
                bed.GetComponent<BedController>().PatientComeback();
            }
        }
    }

    public bool PatientMove()
    {
        //patient is lay down on random pos in Scene except PatientRoom
        return true;
    }
    

}
