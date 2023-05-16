using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour,IPointerDownHandler
{
    public CanvasGroup dialoguegroup;
    public Text dialogueText;
    public GameObject nextText;
    public Queue<string> sentences;
    private string currentSentence;
    public float typingspeed;
    private bool istyping;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);//line에 있는걸 받아옴
        }
        dialoguegroup.alpha = 1;
        dialoguegroup.blocksRaycasts = true;//마우스 이벤트를 감지한다

        NextSentence();
    }
    public void NextSentence()
    {
        if(sentences.Count!=0)//하나라도 있는경우
        {
            currentSentence= sentences.Dequeue();
            //하나의 경우라도 있는경우
            istyping= true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else
        {
            dialoguegroup.alpha = 0;
            dialoguegroup.blocksRaycasts = false;//마우스 이벤트를 감지한다

        }
    }
    IEnumerator Typing(string line)
    {
        dialogueText.text = "";
        foreach(char letter in line.ToCharArray())//string열 char로 변환해서 집어넣음
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(dialogueText.text.Equals(currentSentence))
        {
            nextText.SetActive(true);
            istyping = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)//해당 스크립트가 붙은 오브젝트에 클릭, 터치가 있을 때 호출된다
    {
        if(!istyping)
            NextSentence();
    }

   
}
