using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOff : MonoBehaviour
{
    GameObject director;


    void Start()
    {
        director = GameObject.Find("GameDirector");

    }

    public void phoneoff()
    {
        director.GetComponent<GameDirector>().PhoneOff();
    }
}
