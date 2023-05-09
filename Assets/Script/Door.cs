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
    public bool Getison() { return ison; }
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

            // Rect�� ����Ͽ� �� ����
            GUI.Label(labelRect, "��");
        }*/

    void OnGUI()
    {
        
        // ��ũ��Ʈ�� ������ �ִ� ��ü�� ��ġ�� �����ɴϴ�.
        Vector3 objectPosition = transform.position;

        // ��ũ��Ʈ�� ������ �ִ� ��ü�� ��ǥ�� ȭ�� ��ǥ�� ��ȯ�մϴ�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        // ���ڿ��� ǥ���� Rect�� �����մϴ�.
        Rect labelRect = new Rect(screenPosition.x-50, screenPosition.y-300f, 100, 100);

        // ���ڿ��� ǥ���մϴ�.
        if (ison)
            GUI.Label(labelRect, image_e);
    }

}
