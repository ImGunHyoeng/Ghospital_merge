using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    GameObject director;
    bool Can_Enter;
    [SerializeField]
    public DialogSystem_Opening dialogSystem01; //dialog when player can't get out the room
    public bool alllight_off = false;

    private void Start()
    {
        Can_Enter = false;
        this.director = GameObject.Find("GameDirector");
    }

    private void Update()
    {
        alllight_off = true;
        //Debug.Log("alllight off: " + alllight_off);
        if (Can_Enter)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
               
                if (alllight_off == false)
                {
                    Debug.Log("alllight off: " + alllight_off);
                    if (gameObject.CompareTag("Door"))
                    {
                        GetComponent<SceneSelector>().ChangeScene();
                        //GameObject.Find("EnemyGenerator").GetComponent<EnemyGenerator>().enemy_exist = false;
                    }
                }
                else
                    Cantgetout_room();
            }
        }
    }
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_Enter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Can_Enter = false;
        }
    }

    void Cantgetout_room()
    {
        Typing_text();
    }

    IEnumerator Typing_text()
    {
        dialogSystem01.SetOrginal();
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

    }


}
