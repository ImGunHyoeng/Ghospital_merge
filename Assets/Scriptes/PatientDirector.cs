using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientDirector : MonoBehaviour
{
    GameObject get_down_patient;
    int[] disappear_patients;
    int patient_num;

    
    
void Start()
    {
        disappear_patients = GameObject.Find("GameDirector").GetComponent<GameDirector>().Room_Patients;
        get_down_patient = GameObject.Find("Patient_parent");
        patient_num = get_down_patient.transform.Find("Patient").GetComponent<PatientController>().number_of_patient;
    }

    
    void Update()
    {
        //Debug.Log("patient num: " + patient_num);
        if(disappear_patients[patient_num] == 0)
        {
            //get_down_patient.SetActive(true);
            get_down_patient.transform.Find("Patient").gameObject.SetActive(true);
        }
        else
        {
            //get_down_patient.SetActive(false);
            get_down_patient.transform.Find("Patient").gameObject.SetActive(false);
        }
    }
}
