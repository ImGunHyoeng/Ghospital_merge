using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    bool isSound;
    public CanvasGroup MenuIn;
    public CanvasGroup MenuQuit;
    [SerializeField]
    public DialogSystem_Opening dialogSystem01;
    //GameObject director;
    int time;

    public AudioSource click_btn;

    public void OnBthClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneLoader.LoadSceneHandle("OpeningScene", 0);
                break;

            case BTNType.Countinue:
                SceneLoader.LoadSceneHandle("NewPath", 0);
                break;


            case BTNType.Option:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Sound:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Exit:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Back:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Phone:
                //director.GetComponent<GameDirector>().show_ph = 1;
                click_btn.Play();
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Map:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.QR:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Message:
                time = GameObject.Find("Time").GetComponent<Phone_TImer>().gettime();
                Debug.Log("check time:" + time);
                if (time < 1)
                {
                    StartCoroutine("Typing_text");
                }
                else
                {
                    CanvasGroupOn(MenuIn);
                    CanvasGroupOff(MenuQuit);
                }
                break;

            case BTNType.Quit:
                Application.Quit();
                break;

            case BTNType.ReStart:
                //SceneLoader.LoadSceneHandle("Title",0);
                SceneManager.LoadScene("Title");
                break;

            case BTNType.Resolution:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Call:
                click_btn.Play();
                StartCoroutine("Typing_text");
                break;
        }
    }

    IEnumerator Typing_text()
    {
        dialogSystem01.SetOrginal();
           yield return new WaitUntil(() => dialogSystem01.UpdateDialog());
        
    }

    public void CanvasGroupOn(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.interactable = true;
        cg.blocksRaycasts = true;
    }
    public void CanvasGroupOff(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.interactable = false;
        cg.blocksRaycasts = false;
    }

    //��ư�� ���콺 ���ٴ�� ũ�� Ű��� 
    void Start()
    {
        defaultScale = buttonScale.localScale;
        //director = GameObject.Find("GameDirector");
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale * 1.2f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonScale.localScale = defaultScale;
    }

}
