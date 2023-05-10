using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Door_spawner : MonoBehaviour
{
    public float min_x;
    public float max_x;
    public GameObject door;
    GameObject newdoor;
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
    public GameObject Getobject()
    { return newdoor; }
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
            
            if (canSpawnhere) { break; }//������ �����ϴٸ��� ����
        }
        newdoor = Instantiate(door, spawnPos,Quaternion.Euler(Vector3.zero)) as GameObject;
        //������ Instaniate�� ��ȯ�ϴ°��� Object���̱⿡ GameObject�� ����ȯ�� ���ذ��̴�
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
            //bounds�� ��ü�� �������� ��ü�� �浹�ϴ� ������ ��Ÿ����.
            //bounds.center�� ��ü�� �߽����� �ǹ��Ѵ�.
            float width=colliders[i].bounds.extents.x;
            //extents.x�� ��ü�� �ʺ� �ǹ�
            float height=colliders[i].bounds.extents.y;
            //extents.y�� ��ü�� ���̸� �ǹ�

            float leftExtent=centerPoint.x-1 - width;
            //�׷��Ƿ� ������ �����Ϳ��� �ʺ� ������ ������ ��谪�� �� ���� �����°�
            //���� �ǵ������� ���ͺ��� �� ���� ũ��� �ؼ� �΋Hġ�� �ʴ°��� �ش�ȭ�س���
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
