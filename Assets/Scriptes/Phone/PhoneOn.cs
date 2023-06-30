using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneOn : MonoBehaviour
{
    GameObject director;
    GameObject player;
   
   
    void Start()
    {
        director = GameObject.Find("GameDirector");
        player = GameObject.Find("Player");
    }

    public void phoneon()
    {
        player.GetComponent<PlayerController>().use_something = true;
        StartCoroutine(stoptime());
    }

    IEnumerator stoptime()
    {
        yield return new WaitForSeconds(0.01f);
        director.GetComponent<GameDirector>().TimeStop();
    }
}
