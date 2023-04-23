using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    bool ison = false;
    public Texture image_e;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            ison= true;
        }
    /*    else
        {
            Destroy(this.gameObject);
            GameObject a = GameObject.Find("RandomDoor_ctr");
            Door_spawner b = a.GetComponent<Door_spawner>();
            b.spawn_door();
            b.setspawnfalse();
        }*/
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ison = true;
        }
       /* else
        {
            Destroy(this.gameObject);
            GameObject a = GameObject.Find("RandomDoor_ctr");
            Door_spawner b = a.GetComponent<Door_spawner>();
            b.spawn_door();
            b.setspawnfalse();
        }
        Debug.Log("yes");*/
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ison = false;
        }
    }
    /*    private void OnGUI()
        {
            Rect labelRect = new Rect(this.transform.position.x, this.transform.position.y+10f, this.transform.localScale.x+10, this.transform.localScale.y+10f);

            // Rect를 사용하여 라벨 생성
            GUI.Label(labelRect, "라벨");
        }*/

    void OnGUI()
    {
        
        // 스크립트를 가지고 있는 객체의 위치를 가져옵니다.
        Vector3 objectPosition = transform.position;

        // 스크립트를 가지고 있는 객체의 좌표를 화면 좌표로 변환합니다.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        // 문자열을 표시할 Rect를 생성합니다.
        Rect labelRect = new Rect(screenPosition.x-50, screenPosition.y-300f, 100, 100);

        // 문자열을 표시합니다.
        if (ison)
            GUI.Label(labelRect, image_e);
    }

}
