using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dont_Destroy_object : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        var objs=FindObjectsOfType<Dont_Destroy_object>();//dont�� ������Ʈ�� �����´�
        if(objs.Length==1)
        {
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

 
}
