using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Phone_TImer : MonoBehaviour
{
    public int one_hour;
    private int time;
    private bool isend;
    private Texture2D ph_time;
    private string time_path;
    private Sprite curr_sprite;
    private Image curr_img;
    // Start is called before the first frame update
    void Start()
    {
        curr_img = GetComponent<Image>(); //getcomponent는 레퍼런스 변수를 반환시켜줌 그렇기에 변환하면 원본이 변환됨
        //curr_sprite = GetComponent<Image>().sprite;
        time_path = string.Format("TIme_" + time.ToString());
        one_hour = 30;
        isend = false;
        time = 0;
        ph_time = Resources.Load(time_path, typeof(Texture2D)) as Texture2D;//리소스 파일에 있는 것을 가져오는 식이다.
        //ph_time = GameObject.Find("Time_" + time.ToString()).GetComponent<Image>();

        StartCoroutine(countHour());
    }
    IEnumerator countHour()
    {
        //Debug.Log("yes");
        yield return new WaitForSeconds(one_hour);
        time++;
        StartCoroutine(change());
    }
    IEnumerator change()
    {
        time_path = string.Format("TIme_" + time.ToString());
        //ph_time = Resources.Load(time_path, typeof(Texture2D)) as Texture2D;
        //ph_time = GameObject.Find("TIme_" + time.ToString()).GetComponent<Image>();
        //curr_sprite =Sprite.Create(ph_time,new Rect(0,0,296,119),new Vector2(0.5f,0.5f));
        curr_img.sprite = Resources.Load(time_path, typeof(Sprite)) as Sprite;//원본의 스프라이트에 파일의 값을 변경해서 연결시켜줌
        yield return null;
        if (time < 6)
            StartCoroutine(countHour());
        else
            SceneManager.LoadScene("Clear");
    }
    // Update is called once per frame
    public int gettime() { return time; }
}
