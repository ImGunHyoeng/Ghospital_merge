using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedDirector : MonoBehaviour
{
    public int Room_number;
    
    void Start()
    {
        GameObject[] bed = GameObject.FindGameObjectsWithTag("Bed");
        int[] disappear_patient = GameObject.Find("GameDirector").GetComponent<GameDirector>().Room_Patients;

        for (int i = 0; i < bed.Length; i++)
            bed[i].GetComponent<BedController>().patient_exist = disappear_patient[i + (bed.Length * (Room_number - 101))]; //Get the RoomLight's number and set Lightoff or on 
    }
    void Update()
    {
        GameObject[] bed = GameObject.FindGameObjectsWithTag("Bed");// Find Light in room
        int[] disappear_patient = GameObject.Find("GameDirector").GetComponent<GameDirector>().Room_Patients; //Direct Room Light get off

        for (int i = 0; i < bed.Length; i++)
            disappear_patient[i + (bed.Length * (Room_number - 101))] = bed[i].GetComponent<BedController>().patient_exist; //Get the RoomLight's number and set Lightoff or on 
    }


}
