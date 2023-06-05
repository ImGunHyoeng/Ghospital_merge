using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightDirector : MonoBehaviour
{
    float span = 3.0f;
    float delta = 0;
    public int ratio = 5; // �� �����Ӹ��� 50%Ȯ��


    /* �÷��̾ ��ȿ� �ְų� �ٸ� ������ ���� �ð���  �� ������ �ʾҰų� ���� Ų�� �� ������ �ʾҴٸ� ������ �ʱ�
             * �÷��̾ ������ Ÿ�̾� ��ž �����ð��� ������ �����Ѵ�.
             * ���� ��ȣ�� ������ ��ȣ�� ��ġ�Ѵ�. �÷��̾ ����� ���� ��ȣ�� �濡 �ִٸ� ������ Ÿ�̸Ӵ� �����.
             * �÷��̾ ��ȿ� ���ų� �ٸ� �濡 �ִٸ� Ÿ�̳ʴ� �����Ѵ�.
             * ��ȭ ��,�ƾ� ���� ���϶� Ÿ�̸Ӱ� �����.
               */
    public void Start()
    {
        GameObject[] light = GameObject.FindGameObjectsWithTag("Light");// Find Light in room
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights; //Direct Room Light get off

        for (int i = 0; i < light.Length; i++)
            light[i].GetComponent<LightController>().lightOff = RoomLights[i]; //Get the RoomLight's number and set Lightoff or on 
    }
    void Update()
    {
        GameObject[] light = GameObject.FindGameObjectsWithTag("Light");// Find Light in room
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights; //Direct Room Light get off

        for (int i = 0; i < light.Length; i++)
              RoomLights[i] = light[i].GetComponent<LightController>().lightOff; //Get the RoomLight's number and set Lightoff or on 

    }

    public void Player_Turn_On_the_Light()
    {
        
        GameObject[] light = GameObject.FindGameObjectsWithTag("Light");
        int[] RoomLights = GameObject.Find("GameDirector").GetComponent<GameDirector>().RoomLights;
        for (int i = 0; i < light.Length; i++)
        {
            light[i].GetComponent<LightController>().lightOff = 0;
        }
    }
}
