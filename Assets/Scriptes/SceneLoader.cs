using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    public static string loadScene;
    public static int loadType;


    void Start()
    {
        StartCoroutine(LoadScene());
    }

   public static void LoadSceneHandle(string _name,int _loadType)
    {
        loadScene = _name;
        loadType = _loadType;
        SceneManager.LoadScene("Loading");
    }
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync(loadScene);
        //AsyncOperation operation = SceneManager.LoadSceneAsync("Play");
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            yield return null;

            if (loadType == 0)
                Debug.Log("New game"); //새 게임
            else if (loadType == 1)
                Debug.Log("Old game"); //헌 게임

            if (progressbar.value < 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            }
            else if(operation.progress >= 0.9f)
            {
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            }
            if(progressbar.value >= 1f)
            {
                loadtext.text = "Press SpaceBar";
            }

            if(Input.GetKeyDown(KeyCode.Space) && progressbar.value >= 1f && operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }
        }
    }
  
    
}
