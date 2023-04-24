using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door_spawner : MonoBehaviour
{
    public float min_x;
    public float max_x;
    public GameObject door;

    public Collider2D[] colliders;
    public Vector2 boundry;

    bool isspawn = false;
    float spawntimer;

    // Start is called before the first frame update
    void Start()
    {
        spawntimer = Random.RandomRange(4, 10);
    }

    IEnumerator spanwdoor()
    {
        yield return new WaitForSeconds(2f);
        setspawnfalse();
    }
    public void setspawnfalse()
    {
        isspawn = false;
    }
    public void spawn_door()
    {
        bool canSpawnhere;

        float transform_x= Random.RandomRange(min_x, max_x);
        Vector3 spawnPos = new Vector3(transform_x, 0.2f, 0f);
        canSpawnhere=PreventSpawnOverlap(spawnPos);
        while(!canSpawnhere)
        {
            transform_x = Random.RandomRange(min_x, max_x);
            spawnPos = new Vector3(transform_x, 0.2f, 0f);
            canSpawnhere = PreventSpawnOverlap(spawnPos);
            
            if (canSpawnhere) { break; }//스폰이 가능하다면은 정지
        }
        GameObject newdoor=Instantiate(door, spawnPos,Quaternion.Euler(Vector3.zero)) as GameObject;
        //원래는 Instaniate가 반환하는값이 Object값이기에 GameObject로 형변환을 해준것이다
        isspawn = true;
        spawntimer = 5f;
        StartCoroutine(spanwdoor());
        Destroy(newdoor,5f);
        
    }
    // Update is called once per frame
    void Update()
    {
        spawntimer -= Time.deltaTime;
        if(spawntimer< 0) 
        {
            spawn_door();
        }
    }

    bool PreventSpawnOverlap(Vector3 spawnpos)
    { 
        colliders = Physics2D.OverlapBoxAll(transform.position, boundry,0);
        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint=colliders[i].bounds.center;
            //bounds는 객체의 경계상자의 물체가 충돌하는 영역을 나타낸다.
            //bounds.center는 물체의 중심점을 의미한다.
            float width=colliders[i].bounds.extents.x;
            //extents.x는 물체의 너비를 의미
            float height=colliders[i].bounds.extents.y;
            //extents.y는 물체의 높이를 의미

            float leftExtent=centerPoint.x-1 - width;
            //그러므로 센터의 포인터에서 너비를 빼면은 왼쪽의 경계값을 뺀 값이 나오는것
            //나는 의도적으로 센터보다 더 넓은 크기로 해서 부딫치지 않는것을 극대화해놓음
            float rightExtent=centerPoint.x+1 + width;
            float lowerExtent = centerPoint.y+1 - height;
            float upperExtent=centerPoint.y+1 + height;
            if(spawnpos.x>=leftExtent && spawnpos.x<=rightExtent )
            {
                if(spawnpos.y>=lowerExtent&&spawnpos.y<=upperExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }
    
}
