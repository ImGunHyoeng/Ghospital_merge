using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move_limit : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float Y_offset = 1.5f;
    Transform target;
    Vector3 newPos;
    public Vector2 center;
    public Vector2 size;
    float width;
    float height;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Find_player());
        Y_offset = 1.5f;
        height = Camera.main.orthographicSize;
        width=height*Screen.width/Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            newPos = new Vector3(target.position.x, target.position.y + Y_offset, -10f);
            transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
            float lx = size.x * 0.5f - width;
            float clampX=Mathf.Clamp(transform.position.x,-lx+center.x,lx+center.x);
            newPos = new Vector3(clampX, target.position.y + Y_offset, -10f);
            transform.position = newPos;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(center, size);
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
