using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    // 특정 시간이 되면 랜덤하게 사라진다,
    // 커튼에 e를 눌러서 열어보면 환자가 있는지 없는지 알 수 있다.
    // 환자가 없어지면 랜점한 장소에 환자가 쓰러져있고 상호작용해서 일으켜 돌아갈 수 있다.
    // 방을 벗어나도 계속 동작해야한다.
    bool Can_Check;

    public GameObject director;
    public Sprite full;
    public Sprite empty;
    public Sprite cutton;
    public AudioSource open;


    public int patient_exist;

    private void Start()
    {
        Can_Check = false;
        patient_exist = 1;
       
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Can_Check == true)
            {
                open.Play();
                Open_Cutton();
            }
        }
    }

    void Open_Cutton()
    {
        if (patient_exist == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.full;
            StartCoroutine(Close_Cutton());
           
        }

        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = this.empty;
            StartCoroutine(Close_Cutton());
           
        }
    }


    //change sprite according to patient exist
    public void PatientGone()
    {
        patient_exist = 0;
    }

    public void PatientComeback()
    {
        patient_exist = 1;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))      
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

    IEnumerator Close_Cutton()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.GetComponent<SpriteRenderer>().sprite = this.cutton;
    }
    

}
