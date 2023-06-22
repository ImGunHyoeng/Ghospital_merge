using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomDoor : MonoBehaviour
{
    bool Can_Check;
    bool something_exist;
    public Sprite close;
    public Sprite open;

    private void Start()
    {
        Can_Check = false;
        something_exist = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Can_Check == true)
            {
                Open_Door();
            }
        }
    }

    void Open_Door()
    {
        if (something_exist == true)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.open;
            StartCoroutine(Close_Door());

        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.open;
            StartCoroutine(Close_Door());

        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Can_Check = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Can_Check = false;
        }
    }

    IEnumerator Close_Door()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.GetComponent<SpriteRenderer>().sprite = this.close;
    }

}
