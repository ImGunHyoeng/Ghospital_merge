using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear_Scene : MonoBehaviour
{
    public bool clear = false;
    float isTIme;
    private void Start()
    {
        Invoke("isClear", 4f);
        isTIme = 10f;
    }
    public void isClear()
    {
        clear = true;
    }
    private void Update()
    {
        isTIme-=Time.deltaTime;
        Debug.Log(clear);
        if( clear )
        {
            if(Input.anyKey||isTIme<=0)
            {
                SceneManager.LoadScene("TItle");
            }
        }
    }
}
