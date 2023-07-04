using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneCheck : MonoBehaviour
{
    Scene scene;
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
        if (scene.name == "Title")
        {
            GameObject.Find("AudioDirector").GetComponent<AudioDirector>().title();
        }
        if (scene.name == "Main_Hall")
        {
            GameObject.Find("AudioDirector").GetComponent<AudioDirector>().Ingame();
        }
    }

}
