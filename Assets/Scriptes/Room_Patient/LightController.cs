using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    SpriteRenderer sr;
    public int lightOff = 1;

    private void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {

       if(lightOff == 1)
        {
            sr.material.color = new Color(1, 1, 1);
        }
        if (lightOff == 0)
        {
            sr.material.color = new Color(0, 0, 0);
        }

    }


}

