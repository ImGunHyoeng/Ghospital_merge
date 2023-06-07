using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatientGenerator : MonoBehaviour
{
    public GameObject patientprefab;
    private void Update()
    {
        GameObject[] num_of_bed = GameObject.FindGameObjectsWithTag("Bed");
        int[] num_of_in_bed_patient = GameObject.Find("GameDirector").GetComponent<GameDirector>().PatientinBed;

        //for (int i = 0; i < num_of_bed.Length; i++)
        //      num_of_in_bed_patient[i] = num_of_bed[i].GetComponent<BedController>().patient_ON;
    }
    // Start is called before the first frame update
    

}
