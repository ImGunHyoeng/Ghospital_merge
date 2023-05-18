using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientController : MonoBehaviour
{

    GameObject bed;

    private void Start()
    {
        bed = GameObject.Find("Bed");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bed.GetComponent<BedController>().PatientComeback();
        }

    }
}
