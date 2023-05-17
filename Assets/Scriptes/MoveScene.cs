using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScene : MonoBehaviour
{
    GameObject director;
    private void Start()
    {
        this.director = GameObject.Find("GameDirector");
    }
    public void GotoRoom()
    {
        this.director.GetComponent<GameDirector>().IntoRoom();
    }
}
