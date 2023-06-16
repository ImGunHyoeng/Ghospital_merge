using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Next_audio : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource list1;
    public AudioSource list2;

    // Update is called once per frame
    private void Start()
    {
        list1.Play();
        StartCoroutine(Next_audio_co());
    }
    void Update()
    {
        
    }
    IEnumerator Next_audio_co()
    {
        yield return new WaitForSeconds(0.1f);
        if (list1 == null || list2 == null)
            StartCoroutine(Next_audio_co());
        if(list1.isPlaying==false)
        {
            list2.Play();
        }
        else
        {
            StartCoroutine(Next_audio_co());
        }
    }
}
