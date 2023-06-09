using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_All : MonoBehaviour
{
    // Start is called before the first frame update
    //GameObject DtM;
    GameObject GmD;
    GameObject Play;
    GameObject EneD;
    GameObject CanvasTim;
    GameObject CanvasPh;
    PlayerController p;
    void Start()
    {
        //DtM = GameObject.Find("DataManager");
        GmD = GameObject.Find("GameDirector");
        Play = GameObject.FindWithTag("Player");
        EneD = GameObject.Find("EnemyGenerator");
        CanvasTim = GameObject.Find("Canvas_Timer");
        CanvasPh = GameObject.Find("Canvas_Phone");
        //StartCoroutine(FindAll());
        
        AllDelete();
    }

    // Update is called once per frame
    private void Update()
    {
       /* GmD = GameObject.Find("GameDirector");
        Play = GameObject.FindWithTag("Player");
        EneD = GameObject.Find("EnemyGenerator");
        CanvasTim = GameObject.Find("Canvas_Timer");
        CanvasPh = GameObject.Find("Canvas_Phone");*/
    }
 /*   IEnumerator FindAll()
    {
        if (GmD == null || Play == null || EneD == null || CanvasTim == null || CanvasPh == null)
        {
            //DtM = GameObject.Find("DataManager");
            GmD = GameObject.Find("GameDirector"); 
            Play = GameObject.Find("Player");
            EneD = GameObject.Find("EnemyGenerator");
            CanvasTim = GameObject.Find("Canvas_Timer");
            CanvasPh = GameObject.Find("Canvas_Phone");
        }
        else 
        { 
            AllDelete();
            yield break;
        }
        StartCoroutine(FindAll());
    }*/
    void AllDelete()
    {
       //
        if(GmD != null)
            Destroy(GmD);
        if(EneD != null)
            Destroy(EneD);
        if(CanvasTim != null)
            Destroy(CanvasTim);
        if(CanvasPh != null)
            Destroy(CanvasPh);
        if (Play == null)
            Play = GameObject.FindWithTag("Untouchable");
        Destroy(Play);


    }
}
