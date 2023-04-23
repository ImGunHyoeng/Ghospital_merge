using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_spawner : MonoBehaviour
{
    public float min_x;
    public float max_x;
    public GameObject door;
    bool isspawn = false;
    float spawntimer;
    // Start is called before the first frame update
    void Start()
    {
        spawntimer = Random.RandomRange(4, 10);
    }

    public void setspawnfalse()
    {
        isspawn = false;
    }
    public void spawn_door()
    {
        float transform_x= Random.RandomRange(min_x, max_x);
        Instantiate(door, new Vector3(transform_x, 0.2f,0f),Quaternion.Euler(Vector3.zero));
        isspawn = true;
    }
    // Update is called once per frame
    void Update()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer< 0&&!isspawn) 
        {
            spawn_door();
        }
    }
    
}
