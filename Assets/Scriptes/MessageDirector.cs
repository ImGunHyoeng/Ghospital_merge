using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDirector : MonoBehaviour
{
   
    int time;
    [SerializeField] Sprite FirstMes;
    
    [SerializeField] Sprite SecondMes;

    private void Update()
    {
        time = GameObject.Find("Time").GetComponent<Phone_TImer>().gettime();
        if (time < 3)
        {
            Notice_Rule();
        }
        if(time >= 3)
        {
            Notice_patientGone();
        }

    }
    void Notice_Rule()
    {
        gameObject.GetComponent<Image>().sprite = FirstMes;
    }
   void Notice_patientGone()
    {
        gameObject.GetComponent<Image>().sprite = SecondMes;
    }
}
