using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedController : MonoBehaviour
{
    // Ư�� �ð��� �Ǹ� �����ϰ� �������,
    // Ŀư�� e�� ������ ����� ȯ�ڰ� �ִ��� ������ �� �� �ִ�.
    // ȯ�ڰ� �������� ������ ��ҿ� ȯ�ڰ� �������ְ� ��ȣ�ۿ��ؼ� ������ ���ư� �� �ִ�.
    // ���� ����� ��� �����ؾ��Ѵ�.

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

    //ȯ�� ������ ����
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
