using System.Collections;/*
using System.Collections.Generic;
using UnityEditorInternal;*/
using UnityEngine;/*
using UnityEngine.SceneManagement;
*/
public class Next_Scene_move_Center : MonoBehaviour
{
    static public bool center_move=false;
    public SceneSelector SceneSelector;
    bool touch = false;
    public bool alllight_off = false;

    [SerializeField]
    public DialogSystem_Opening dialogSystem01; //dialog when player can't get out the room
    // Start is called before the first frame update
    IEnumerator move_scene()
    {
        if (DataManager.instance == null)
            yield break;//�ڷ�ƾ ���ߴ� �Լ�
        DataManager.instance.playerData.movedirection = 0;
        DataManager.instance.SaveData();

        SceneSelector.ChangeScene();
        //SceneManager.LoadScene("Next Path");
        //yield return new WaitForSeconds(1);
        PlayerController.set_move_scene_center();
        Debug.Log(PlayerController.scene_move.ToString());
        //yield return new WaitForSeconds(0.1f);
        yield return null;
    }
    
    private void Update()
    {
       
        if (touch)
        {
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("pressE and alloff:  " + alllight_off);
                if (alllight_off == false)
                {
                    StartCoroutine(move_scene());
                    touch = false;
                }
                else
                    Cantgetout_room();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
           touch=true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            touch = false;
        }
    }

    void Cantgetout_room()
    {
        Debug.Log("start function");
        StartCoroutine(Typing_text());
        Debug.Log("end function");
    }

    IEnumerator Typing_text()
    {
        Debug.Log("On Typing");
        dialogSystem01.SetOrginal();
        yield return new WaitUntil(() => dialogSystem01.UpdateDialog());

    }
}
