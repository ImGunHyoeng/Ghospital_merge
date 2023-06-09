using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public float timeScale;

    public int[] Room_Lights = { 0, 0, 0, 0, 0, 0 };
    public int[] Room_Patients = { 1, 1, 1, 1, 1, 1 };

    [SerializeField]float check_Time = 3.0f; 
    [SerializeField]float delay_Time = 10.0f; //when the one light off, set delay
    float delta = 0;
    float delay_delta = 0;
    [SerializeField] int TurnOFF_ratio = 5; //probability of light turn off randomly
    [SerializeField] int Disappear_ratio = 5; //probability of patient disappear randomly

    [SerializeField] bool one_light_off_immediately;
    [SerializeField] bool one_patient_disappear_immediately;

    private void Awake()
    {
        var obj = FindObjectsOfType<GameDirector>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        timeScale = 1;
        one_light_off_immediately = false;
        one_patient_disappear_immediately = false;
    }

    private void Update()
    {
        Time.timeScale = timeScale; //Manage Fps
        delay_delta -= Time.deltaTime;
        if(delay_delta <= 0f)
        {
            Debug.Log("End Delay");
            Automatically_light_OFF();
            Automatically_Patient_disappear();
            delay_delta = 0f;
        }
       
        if(one_light_off_immediately == true || one_patient_disappear_immediately == true)
        {
            delay_delta = delay_Time;
            Debug.Log("Make Delay");
            one_light_off_immediately = false;
            one_patient_disappear_immediately = false;
        }
        


    }

    public void Automatically_light_OFF()
    {
        int a = Random.Range(0, Room_Lights.Length); //get random light_number

        delta += Time.deltaTime;
        if (delta > check_Time) // check light every checktime
        {
           
            int random = Random.Range(0, 10);
            if (TurnOFF_ratio > random)
            {
                if (Room_Lights[a] == 0)
                {
                    Room_Lights[a] = 1;
                    one_light_off_immediately = true;
                }
            }
            delta = 0;
        }
    }

    public void Automatically_Patient_disappear()
    {
        int a = Random.Range(0, Room_Patients.Length); //get random light_number

        delta += Time.deltaTime;
        if (delta > check_Time) // check light every checktime
        {

            int random = Random.Range(0, 10);
            if (Disappear_ratio > random)
            {
                if (Room_Patients[a] == 1)
                {
                    Room_Patients[a] = 0;
                    one_patient_disappear_immediately = true;
                }
            }
            delta = 0;
        }
    }



    public void TimeStop()
    {
        timeScale = 0;
    }

    public void TimeStart()
    {
        timeScale = 1;
    }

   public void meetEnemy()
    {
        SceneManager.LoadScene("MeetEnemy");
    }

    public void Patient_selfDie()
    {
        //1. play animation that patient get's up and go back to bed
        //2. make patient's bed full
        //3. set delay
    }

    
}
