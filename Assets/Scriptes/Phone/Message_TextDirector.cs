using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message_TextDirector : MonoBehaviour
{
    [SerializeField]
    private DialogSystem_Opening firstmes;
    [SerializeField]
    private DialogSystem_Opening secondmes;
    int time;

    
    private void Update()
    {
        time = GameObject.Find("Time").GetComponent<Phone_TImer>().gettime();
        if (time < 3)
        {
            StartWork();
        }
        if (time >= 3)
        {
            ThreePm();
        }

    }
    void StartWork()
    {
        gameObject.GetComponent<GameDirector>().dialogSystem01 = firstmes;
    }

    void ThreePm()
    {
        gameObject.GetComponent<GameDirector>().dialogSystem01 = secondmes;
    }
}
