using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene_move_Center : MonoBehaviour
{
    static public bool center_move=false;
    public SceneSelector SceneSelector;
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
        PlayerController.set_move_scene();
        Debug.Log(PlayerController.scene_move.ToString());
        //yield return new WaitForSeconds(0.1f);
        yield return null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            center_move = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            center_move = false;
        }
    }
}
