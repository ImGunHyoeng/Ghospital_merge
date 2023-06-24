using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("Gotitle");
    }

    IEnumerator Gotitle()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Title");
    }
}
