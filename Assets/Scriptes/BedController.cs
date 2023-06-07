using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    // 특정 시간이 되면 랜덤하게 사라진다,
    // 커튼에 e를 눌러서 열어보면 환자가 있는지 없는지 알 수 있다.
    // 환자가 없어지면 랜점한 장소에 환자가 쓰러져있고 상호작용해서 일으켜 돌아갈 수 있다.
    // 방을 벗어나도 계속 동작해야한다.

    public int trigger_time;
    float delta;
    public Sprite full;
    public Sprite empty;
    public int ratio;
    public GameObject GetDown_patient;
    GameObject clock;
    public bool patient_exit;

    private void Start()
    {
        delta = 0;
        ratio = 5;
        clock = GameObject.Find("Time");
        patient_exit = true;
    }

    private void Update()
    {
        if (clock.GetComponent<Phone_TImer>().gettime() >= 3) //if clock time is more than 3AM
        {
            delta += Time.deltaTime; //Patient Event Start
            if (delta > 5.0f)
            {
                int rand_num = Random.Range(0, 10);
                if (rand_num > ratio)
                {
                    PatientGone();
                }
                delta = 0f;
            }
        }

    }

    //환자 생성과 삭제
    public void PatientGone()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = this.empty;
        patient_exit = false;
       // GetDown_patient.SetActive(true);   
    }

    public void PatientComeback()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = this.full;
        patient_exit = true;
      //  GetDown_patient.SetActive(false);
    }
}
