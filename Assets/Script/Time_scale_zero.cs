using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_scale_zero : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        Debug.Log(Time.timeScale);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
