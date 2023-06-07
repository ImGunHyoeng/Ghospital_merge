using UnityEngine;
//using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class SceneSelector : MonoBehaviour
{
    [Scene]
    public string newScene;

    public void ChangeScene()
    {
        SceneManager.LoadScene(newScene, LoadSceneMode.Single);
    }

    //public void ChangeNetworkScene()
    //{
    //    if (NetworkServer.active && NetworkManager.singleton != null)
    //    {
    //        NetworkManager.singleton.ServerChangeScene(newScene);
    //    }
    //}
}
