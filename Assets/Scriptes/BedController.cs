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

    //ȯ�� ������ ����
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
