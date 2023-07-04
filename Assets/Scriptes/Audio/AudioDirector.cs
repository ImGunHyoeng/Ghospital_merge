using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;


public class AudioDirector : MonoBehaviour
{
    bool once = true;
    public AudioSource Bgm_Title;
    public AudioSource Bgm_Ingame;
    public AudioSource Bgm_Nurse_Coming;
    //Scene scene;

    private void Awake()
    {
        var obj = FindObjectsOfType<AudioDirector>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void Update()
    //{
    //    scene = SceneManager.GetActiveScene();
    //    if (scene.name == "Title")
    //    {
    //        title();
    //    }
    //    if (scene.name == "Main_Hall")
    //    {
    //        Ingame();
    //    }
    //}
    public void title()
    {
        Bgm_Nurse_Coming.Stop();
        Bgm_Title.Play();
    }
    public void Ingame()
    {
        Bgm_Title.Stop();
        Bgm_Ingame.Play();
    }
    public void nursecoming()
    {
        Bgm_Ingame.Stop();
        Bgm_Nurse_Coming.Play();
    }

}
