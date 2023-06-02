using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOn : MonoBehaviour
{
    GameObject director;
   
   
    void Start()
    {
        director = GameObject.Find("GameDirector");
        
    }

    public void phoneon()
    {
        director.GetComponent<GameDirector>().TimeStop();
    }
}
