using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_timer : MonoBehaviour
{
    public float time=2;
    bool isdone;
    private void Update()
    {
        if(time>=0f)
        time -= Time.deltaTime;
        if(time<0f)
           isdone = true;
    }
    public bool isWork() { return isdone; }
}
