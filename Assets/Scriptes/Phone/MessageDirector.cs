using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageDirector : MonoBehaviour
{
   
    int time;
    [SerializeField] Sprite FirstMes;
    
    [SerializeField] Sprite SecondMes;

    public AudioSource mes_aram;
    bool checkfirst_aram = true;
    bool checksecond_aram = true;

    private void Update()
    {
        time = GameObject.Find("Time").GetComponent<Phone_TImer>().gettime();
        if (time >= 1 && time < 3 && checkfirst_aram == true)
        {
            mes_aram.Play();
            Notice_Rule();
            checkfirst_aram = false;
        }
        if(time >= 3 && checksecond_aram == true)
        {
            mes_aram.Play();
            Notice_patientGone();
            checksecond_aram = false;
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
