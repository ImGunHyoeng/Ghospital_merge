using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightDirector : MonoBehaviour
{
    float span = 3.0f;
    float delta = 0;
    public int ratio = 5; // 매 프레임마다 50%확률


    /* 플레이어가 방안에 있거나 다른 전등이 꺼진 시간이  얼마 지나지 않았거나 불을 킨지 얼마 지나지 않았다면 꺼지지 않기
             * 플레이어가 있을땐 타이어 스탑 일정시간이 지나야 동작한다.
             * 방의 번호와 전등의 번호는 일치한다. 플레이어가 전등과 같은 번호의 방에 있다면 전등의 타이머는 멈춘다.
             * 플레이어가 방안에 없거나 다른 방에 있다면 타이너는 동작한다.
             * 대화 중,컷씬 진행 중일땐 타이머가 멈춘다.
               */
    public void Start()
    {
      
    }
    void Update()
    {
        GameObject[] light = GameObject.FindGameObjectsWithTag("Light");
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights;

        for (int i = 0; i < light.Length; i++)
            light[i].GetComponent<LightController>().lightOff = RoomLights[i];



        //GameObject[] light = GameObject.FindGameObjectsWithTag("Light");
        //int a = Random.Range(0, light.Length);
        //delta += Time.deltaTime;
        //if (delta > span)
        //{
        //    int random = Random.Range(0, 10);
        //    if (ratio > random)
        //    {
        //        if (light[a].GetComponent<LightController>().lightOff == 0)
        //        {
        //            light[a].GetComponent<LightController>().lightOff = 1;
        //        }
        //    }
        //    delta = 0;
        //}
    }
}
