using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reading_Notice : MonoBehaviour
{
    bool Can_read;
    bool notice_on;
    //GameObject director; //if you wish, it can make stop time
    GameObject notice;

    private void Start()
    {
        Can_read = false;
        notice_on = false;
        //director = GameObject.Find("GameDirector");
        notice = GameObject.Find("Canvas_Notice");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Can_read == true)
        {
            if(notice_on == false)
            {
                Show_Notice();
                Debug.Log("Show Notice");
                //director.GetComponent<GameDirector>().TimeStop();
            }
            else
            {
                Off_Notice();
                Debug.Log("Close Notice");
                //director.GetComponent<GameDirector>().TimeStart();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_read = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Can_read = false;
        }
    }

    void Show_Notice()
    {
        notice.transform.Find("Notice").gameObject.SetActive(true);
        notice_on = true;
    }

    void Off_Notice()
    {
        notice.transform.Find("Notice").gameObject.SetActive(false);
        notice_on = false;
    }

}
