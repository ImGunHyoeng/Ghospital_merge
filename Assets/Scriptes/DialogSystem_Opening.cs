using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class DialogSystem_Opening : MonoBehaviour
{
	[SerializeField]
	private Speaker_Opening[] speakers_opening;					// ��ȭ�� �����ϴ� ĳ���͵��� UI �迭
	[SerializeField]
	private DialogData_Opening[]	dialogs;                    // ���� �б��� ��� ��� �迭
	[SerializeField]
	private BackGround_Opening bg;                      // ���� �б��� ���ȭ�� ����
	[SerializeField]
	private	bool			isAutoStart = true;         // �ڵ� ���� ����
	private	bool			isFirst = true;				// ���� 1ȸ�� ȣ���ϱ� ���� ����
	private	int				currentDialogIndex = -1;	// ���� ��� ����
	private	int				currentSpeakerIndex = 0;	// ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
	private	float			typingSpeed = 0.1f;			// �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
	private	bool			isTypingEffect = false;     // �ؽ�Ʈ Ÿ���� ȿ���� ���������


    private void Start()
    {
		//typingSpeed *= 1000 * Time.unscaledDeltaTime;

	}
    private void Awake()
	{
		Setup();
	}

	private void Setup()
	{
		// ��� ��ȭ ���� ���ӿ�����Ʈ ��Ȱ��ȭ
		for ( int i = 0; i < speakers_opening.Length; ++ i )
		{
			SetActiveObjects(speakers_opening[i], false);
			// ĳ���� �̹����� ���̵��� ����
			//speakers[i].spriteRenderer.gameObject.SetActive(true);
		}

		//bg.background.gameObject.SetActive(true);
	}

	public bool UpdateDialog()
	{
		
		// ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
		if ( isFirst == true )
		{
			// �ʱ�ȭ. ĳ���� �̹����� Ȱ��ȭ�ϰ�, ��� ���� UI�� ��� ��Ȱ��ȭ
			Setup();
			bg.background.gameObject.SetActive(true);
			// �ڵ� ���(isAutoStart=true)���� �����Ǿ� ������ ù ��° ��� ���
			/*if ( isAutoStart ) */
			SetNextDialog();
			isFirst = false;
		}

		if ( Input.GetMouseButtonDown(0) )
		{
			// �ؽ�Ʈ Ÿ���� ȿ���� ������϶� ���콺 ���� Ŭ���ϸ� Ÿ���� ȿ�� ����
			if ( isTypingEffect == true )
			{
				isTypingEffect = false;
				
				// Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�
				StopCoroutine("OnTypingText");
				speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
				// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
				speakers_opening[currentSpeakerIndex].objectArrow.SetActive(true);

				return false;
			}
			
			// ��簡 �������� ��� ���� ��� ����
			if ( dialogs.Length > currentDialogIndex + 1 )
			{
				SetNextDialog();
			}
			// ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
			else
			{
				// ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
				for ( int i = 0; i < speakers_opening.Length; ++ i )
				{
					SetActiveObjects(speakers_opening[i], false);
					// SetActiveObjects()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
					//speakers[i].spriteRenderer.gameObject.SetActive(false);
				}
				bg.background.gameObject.SetActive(false);

				return true;
			}
		}

		return false;
	}

	private void SetNextDialog()
	{
		
		// ���� ȭ���� ��ȭ ���� ������Ʈ ��Ȱ��ȭ
		SetActiveObjects(speakers_opening[currentSpeakerIndex], false);
		
		// ���� ��縦 �����ϵ��� 
		currentDialogIndex ++;

		// ���� ȭ�� ���� ����
		currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

		// ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
		SetActiveObjects(speakers_opening[currentSpeakerIndex], true);
		// ���� ȭ�� �̸� �ؽ�Ʈ ����
		speakers_opening[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
		// ���� ȭ���� ��� �ؽ�Ʈ ����
		speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		
		StartCoroutine("OnTypingText");
	}

	private void SetActiveObjects(Speaker_Opening speaker_opening, bool visible)
	{
		speaker_opening.imageDialog.gameObject.SetActive(visible);
		speaker_opening.textName.gameObject.SetActive(visible);
		speaker_opening.textDialogue.gameObject.SetActive(visible);

		// ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ�ϱ� ������ �׻� false
		speaker_opening.objectArrow.SetActive(false);

		// ĳ���� ���� �� ����
		//Color color = speaker.spriteRenderer.color;
		//color.a = visible == true ? 1 : 0.2f;
		//speaker.spriteRenderer.color = color;
		
	}

	public void SetOrginal()
    {
		isAutoStart = true;         // �ڵ� ���� ����
	    isFirst = true;                // ���� 1ȸ�� ȣ���ϱ� ���� ����
		currentDialogIndex = -1;    // ���� ��� ����
		currentSpeakerIndex = 0;    // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
		typingSpeed = 0.1f;           // �ؽ�Ʈ Ÿ���� ȿ���� ��� �ӵ�
		isTypingEffect = false;     // �ؽ�Ʈ Ÿ���� ȿ���� ���������
    }

	private IEnumerator OnTypingText()
	{
		

		int index = 0;
		
		isTypingEffect = true;
		

		// �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
		while ( index < dialogs[currentDialogIndex].dialogue.Length )
		{
			
			speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);
			
			index ++;
			
			yield return new WaitForSecondsRealtime(0.1f);
			
		}

		isTypingEffect = false;

		// ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
		speakers_opening[currentSpeakerIndex].objectArrow.SetActive(true);
	}
}

[System.Serializable]
public struct Speaker_Opening
{
	//public	SpriteRenderer	spriteRenderer;		// ĳ���� �̹��� (û��/ȭ�� ���İ� ����)
	public	Image			imageDialog;		// ��ȭâ Image UI
	public	TextMeshProUGUI	textName;			// ���� ������� ĳ���� �̸� ��� Text UI
	public	TextMeshProUGUI	textDialogue;		// ���� ��� ��� Text UI
	public	GameObject		objectArrow;        // ��簡 �Ϸ�Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ
}

[System.Serializable]
public struct DialogData_Opening
{
	public	int		speakerIndex;	// �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
	public	string	name;			// ĳ���� �̸�
	[TextArea(3, 5)]
	public	string	dialogue;		// ���
}

[System.Serializable]

public struct BackGround_Opening
{
	public RawImage background;
}


