using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_On_GUI : MonoBehaviour
{
    bool ison = false;
    Texture image_e;
    public float Y_pos;
    public float X_pos;
    // Start is called before the first frame update
    private void Start()
    {
        image_e = Resources.Load("e", typeof(Texture2D)) as Texture2D;
    }
    public bool Getison() { return ison; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ison = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ison = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            ison = false;
        }
    }


    void OnGUI()
    {

        // ��ũ��Ʈ�� ������ �ִ� ��ü�� ��ġ�� �����ɴϴ�.
        Vector3 objectPosition = transform.position;

        // ��ũ��Ʈ�� ������ �ִ� ��ü�� ��ǥ�� ȭ�� ��ǥ�� ��ȯ�մϴ�.
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(objectPosition);

        // ���ڿ��� ǥ���� Rect�� �����մϴ�.
        Rect labelRect = new Rect(screenPosition.x - 50+X_pos, screenPosition.y +100+Y_pos, 100, 100);

        // ���ڿ��� ǥ���մϴ�.
        if (ison&& !PlayerController.get_ishde())
            GUI.Label(labelRect, image_e);
    }

}
