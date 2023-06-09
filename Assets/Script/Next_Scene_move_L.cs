using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene_move_L: MonoBehaviour
{
    public SceneSelector SceneSelector;
    // Start is called before the first frame update
    IEnumerator move_scene ()
    {
        
        DataManager.instance.playerData.movedirection = -1;
        DataManager.instance.SaveData();

        SceneSelector.ChangeScene();
        //SceneManager.LoadScene( SceneSelector.ChangeScene());
        //yield return new WaitForSeconds(1);
        PlayerController.set_move_scene();
        Debug.Log(PlayerController.scene_move.ToString());
        yield return new WaitForSeconds(0.1f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(move_scene());
        }
        
    }
}
