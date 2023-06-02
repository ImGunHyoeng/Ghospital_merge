using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    GameObject[] enemy;
    GameObject lightdir;
    GameObject phone;
    public int show_ph;
    public float timeScale;

    public int[] RoomLights = { 0, 0, 0, 0, 0, 0 };
    float span = 3.0f;
    float delta = 0;
    public int ratio = 5;

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
       
        lightdir = GameObject.Find("LightDirector");
        phone = GameObject.Find("Playmenu");
        show_ph = 0;
        timeScale = 1;
    }

    private void Update()
    {
        //�������� �Ұ����ϱ�
        Time.timeScale = timeScale;
        int a = Random.Range(0, RoomLights.Length);
        delta += Time.deltaTime;
        if (delta > span)
        {
            int random = Random.Range(0, 10);
            if (ratio > random)
            {
                if (RoomLights[a] == 0)
                {
                    RoomLights[a] = 1;
                }
            }
            delta = 0;
        }

       


        //if(Input.GetKeyDown(KeyCode.H)) //H�� �� Ű��
        //{
        //    Debug.Log("here OK");
        //    if (show_ph == 0)
        //    {
        //        Debug.Log("here OK");
        //        show_ph = 1;
        //        phone.GetComponent<CanvasGroup>().alpha = 1;
        //        phone.GetComponent<CanvasGroup>().interactable = true;
        //        phone.GetComponent<CanvasGroup>().blocksRaycasts = true;

        //    }
        //    if (show_ph == 1)
        //    {
        //        show_ph = 0;
        //        phone.GetComponent<CanvasGroup>().alpha = 0;
        //        phone.GetComponent<CanvasGroup>().interactable = false;
        //        phone.GetComponent<CanvasGroup>().blocksRaycasts = false;

        //    }

        //}

        enemy = GameObject.FindGameObjectsWithTag("Enemy");


        //if(phone.GetComponent<CanvasGroup>().alpha == 0) //if pohone On all stop
        //{
        //    PhoneOn();
           
        //    //allstop();
        //}
        //if (phone.GetComponent<CanvasGroup>().alpha == 1)
        //{
        //    show_ph = 0;
        //    //allbegin();//오류남
        //}


    }

    // 2 * 3 �迭, ���� ����� ������ ������ ��Ÿ����. ������ ������ ������ �ð� ���Ŀ� �ϳ��� ������, �� �濡 ��� ������ ������ ���Ͱ� ���´�.
    // ���� ��� ���� ���� �������� ���Ͱ� �÷��̰��� �ִ� �������� ������ �÷��̾ ������ �߰��Ѵ�.
    // �� ��ȿ� �ִ� ������ �ڽ��� ��ȣ�� �°� ����ȴ�. 

    public void PhoneOn()
    {
        //show_ph = 1;
        timeScale = 0;
    }

    public void PhoneOff()
    {

        timeScale = 1;
    }

    //public void allstop()
    //{
    //    lightdir.GetComponent<LightDirector>().ratio = 0;
    //    for(int i = 0;i<enemy.Length;i++)
    //    {
    //        enemy[i].GetComponent<EnemyController>().speed = 0f;
    //    }
       
    //}

    //public void allbegin()
    //{
    //    lightdir.GetComponent<LightDirector>().ratio = 5;//93번째 줄때문에 오류
    //    for (int i = 0; i < enemy.Length; i++)
    //    {
    //        enemy[i].GetComponent<EnemyController>().speed = 3.0f;
    //    }
    //}
   public void meetEnemy()
    {
        SceneManager.LoadScene("MeetEnemy");
    }

    public void IntoRoom()
    {
        SceneManager.LoadScene("Play");
    }
}
