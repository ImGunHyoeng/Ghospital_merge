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
    public Sprite inperson;
    public Sprite empty;
    public int ratio;
    GameObject patient;

    private void Start()
    {
        delta = 0;
        ratio = 5;
        patient = GameObject.Find("Patient");
    }

    private void Update()
    {
        delta += Time.deltaTime;
        if (delta > 5.0f)
        {
            int rand_num = Random.Range(0, 10);
            if(rand_num > ratio)
            {
                PatientGone();
            }
            delta = 0f;
        }

    }

    //환자 생성과 삭제
    void PatientGone()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = this.empty;
        
        patient.SetActive(true);
        
    }

    public void PatientComeback()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = this.inperson;

        patient.SetActive(false);
    }


    

    


}
