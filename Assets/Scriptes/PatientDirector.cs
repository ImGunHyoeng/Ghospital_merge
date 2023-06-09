using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientDirector : MonoBehaviour
{
    public GameObject get_down_patient;
    int[] disappear_patients;
    int patient_num;
    void Start()
    {
        patient_num = get_down_patient.GetComponent<PatientController>().number_of_patient;
        disappear_patients = GameObject.Find("GameDirector").GetComponent<GameDirector>().Room_Patients;
    }

    
    void Update()
    {
        if(disappear_patients[patient_num] == 0)
        {
            get_down_patient.SetActive(true);
        }
        else
        {
            get_down_patient.SetActive(false);
        }
    }
}
