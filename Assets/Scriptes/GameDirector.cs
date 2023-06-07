using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    public float timeScale;

    public int[] RoomLights = { 0, 0, 0, 0, 0, 0 };
    public int[] PatientinBed = { 0, 0, 0, 0, 0, 0 };
    [SerializeField]float check_Time = 3.0f; 
    [SerializeField]float delay_Time = 3.0f; //when the one light off, set delay
    float delta = 0;
    [SerializeField] int ratio = 5; //probability of light turn off randomly
   

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
    }

    private void Update()
    {
        Time.timeScale = timeScale; //Manage Fps

        Automatically_light_OFF();


    }

    public void Automatically_light_OFF()
    {
        int a = Random.Range(0, RoomLights.Length); //get random light_number

        delta += Time.deltaTime;
        if (delta > check_Time) // check light every checktime
        {
           
            int random = Random.Range(0, 10);
            if (ratio > random)
            {
                if (RoomLights[a] == 0)
                {
                    RoomLights[a] = 1;
                    Delay();
                }
            }
            delta = 0;
        }
    }

    private void Delay()
    {
        delta += Time.deltaTime;
        if (delta > delay_Time)
        {
            delta = 0;
            return;
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

    
}
