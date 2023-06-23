using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using TMPro;

public class DialogTest_Opening : MonoBehaviour
{
	[SerializeField]
	private	DialogSystem_Opening	dialogSystem01;
   
    //[SerializeField]
    //private RawImage titlescene;
    [SerializeField]
	private	DialogSystem_Opening	dialogSystem02;
    [SerializeField]
    private DialogSystem_Opening dialogSystem03;
    [SerializeField]
    private DialogSystem_Opening dialogSystem04;
    [SerializeField]
    private DialogSystem_Opening dialogSystem05;
    [SerializeField]
    private DialogSystem_Opening dialogSystem06;
    

    private IEnumerator Start()
	{
        // 첫 번째 대사 분기 시작
        yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());
        yield return new WaitForSeconds(0.1f);
        // 대사 분기 사이에 원하는 행동을 추가할 수 있다.
        // 두 번째 대사 분기 시작
        yield return new WaitUntil(() => dialogSystem02.UpdateDialog());
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => dialogSystem03.UpdateDialog());
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => dialogSystem04.UpdateDialog());
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => dialogSystem05.UpdateDialog());
        yield return new WaitForSeconds(0.1f);
        yield return new WaitUntil(() => dialogSystem06.UpdateDialog());
       
        SceneManager.LoadScene("Main_Hall");
		
	}
}

