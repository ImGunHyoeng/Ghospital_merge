using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_Scene_move: MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator move_scene ()
    {
        
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Next Path");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(move_scene());
        
    }
}
