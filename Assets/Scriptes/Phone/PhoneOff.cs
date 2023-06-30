using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOff : MonoBehaviour
{
    GameObject director;
    GameObject player;

    void Start()
    {
        director = GameObject.Find("GameDirector");
        player = GameObject.Find("Player");
    }

    public void phoneoff()
    {
        player.GetComponent<PlayerController>().use_something = false;
        director.GetComponent<GameDirector>().TimeStart();
    }
}
