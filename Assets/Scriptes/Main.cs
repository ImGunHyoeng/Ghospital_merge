using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main : MonoBehaviour
{

    private void Awake()
    {
        var obj = FindObjectsOfType<GameDirector>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayBtn()
    {
        SceneManager.LoadScene("Loading");
    }
    
}
