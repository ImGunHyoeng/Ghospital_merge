using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BtnType : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public BTNType currentType;
    public Transform buttonScale;
    Vector3 defaultScale;
    bool isSound;
    public CanvasGroup MenuIn;
    public CanvasGroup MenuQuit;
    //GameObject director;

    public void OnBthClick()
    {
        switch (currentType)
        {
            case BTNType.New:
                SceneLoader.LoadSceneHandle("Play", 0);
                break;

            case BTNType.Countinue:
                SceneLoader.LoadSceneHandle("Play", 1);
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
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;

            case BTNType.Quit:
                Application.Quit();
                break;

            case BTNType.ReStart:
                SceneLoader.LoadSceneHandle("Title",0);
                break;

            case BTNType.Resolution:
                CanvasGroupOn(MenuIn);
                CanvasGroupOff(MenuQuit);
                break;
        }
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
