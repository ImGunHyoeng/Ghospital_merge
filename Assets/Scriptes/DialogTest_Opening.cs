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
	//private	TextMeshProUGUI	textCountdown;
	[SerializeField]
	private RawImage titlescene;
	[SerializeField]
	private	DialogSystem_Opening	dialogSystem02;

	private IEnumerator Start()
	{
		//textCountdown.gameObject.SetActive(false);
		titlescene.gameObject.SetActive(false);

		// ù ��° ��� �б� ����
		yield return new WaitUntil(()=>dialogSystem01.UpdateDialog());

		// ��� �б� ���̿� ���ϴ� �ൿ�� �߰��� �� �ִ�.
		// ĳ���͸� �����̰ų� �������� ȹ���ϴ� ����.. ����� 5-4-3-2-1 ī��Ʈ �ٿ� ����
		//textCountdown.gameObject.SetActive(true);
		titlescene.gameObject.SetActive(true);

		int count = 5;
		while ( count > 0 )
		{
			//textCountdown.text = count.ToString();
			count --;

			yield return new WaitForSeconds(1);
		}
		//textCountdown.gameObject.SetActive(false);

		titlescene.gameObject.SetActive(false);

		// �� ��° ��� �б� ����
		yield return new WaitUntil(()=>dialogSystem02.UpdateDialog());

		SceneManager.LoadScene("NewPath");
		//textCountdown.gameObject.SetActive(true);
		//textCountdown.text = "The End";

		//yield return new WaitForSeconds(2);

		//UnityEditor.EditorApplication.ExitPlaymode();
	}
}

