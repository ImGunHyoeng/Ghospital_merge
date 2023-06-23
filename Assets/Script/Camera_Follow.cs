using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float Y_offset = 1.5f;
    Transform target;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Find_player());
        Y_offset = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            newPos = new Vector3(target.position.x, target.position.y+Y_offset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
        }
    }
    IEnumerator Find_player()
    {
        yield return new WaitForSeconds(0.01f);
        if (GameObject.FindWithTag("Player") == null)
        {
            StartCoroutine(Find_player());
        }
        else
        {
            target = GameObject.FindWithTag("Player").transform;
            yield break;
        }

    }
}
