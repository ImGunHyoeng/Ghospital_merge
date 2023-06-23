using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using TMPro;

public class DialogSystem_Opening : MonoBehaviour
{
	[SerializeField]
	private Speaker_Opening[] speakers_opening;					// 대화에 참여하는 캐릭터들의 UI 배열
	[SerializeField]
	private DialogData_Opening[]	dialogs;                    // 현재 분기의 대사 목록 배열
	[SerializeField]
	private BackGround_Opening bg;                      // 현재 분기의 배경화면 설정
	[SerializeField]
	private	bool			isAutoStart = true;         // 자동 시작 여부
	private	bool			isFirst = true;				// 최초 1회만 호출하기 위한 변수
	private	int				currentDialogIndex = -1;	// 현재 대사 순번
	private	int				currentSpeakerIndex = 0;	// 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
	private	float			typingSpeed = 0.1f;			// 텍스트 타이핑 효과의 재생 속도
	private	bool			isTypingEffect = false;     // 텍스트 타이핑 효과를 재생중인지


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
		// 모든 대화 관련 게임오브젝트 비활성화
		for ( int i = 0; i < speakers_opening.Length; ++ i )
		{
			SetActiveObjects(speakers_opening[i], false);
			// 캐릭터 이미지는 보이도록 설정
			//speakers[i].spriteRenderer.gameObject.SetActive(true);
		}

		//bg.background.gameObject.SetActive(true);
	}

	public bool UpdateDialog()
	{
		
		// 대사 분기가 시작될 때 1회만 호출
		if ( isFirst == true )
		{
			// 초기화. 캐릭터 이미지는 활성화하고, 대사 관련 UI는 모두 비활성화
			Setup();
			bg.background.gameObject.SetActive(true);
			// 자동 재생(isAutoStart=true)으로 설정되어 있으면 첫 번째 대사 재생
			/*if ( isAutoStart ) */
			SetNextDialog();
			isFirst = false;
		}

		if ( Input.GetMouseButtonDown(0) )
		{
			// 텍스트 타이핑 효과를 재생중일때 마우스 왼쪽 클릭하면 타이핑 효과 종료
			if ( isTypingEffect == true )
			{
				isTypingEffect = false;
				
				// 타이핑 효과를 중지하고, 현재 대사 전체를 출력한다
				StopCoroutine("OnTypingText");
				speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
				// 대사가 완료되었을 때 출력되는 커서 활성화
				speakers_opening[currentSpeakerIndex].objectArrow.SetActive(true);

				return false;
			}
			
			// 대사가 남아있을 경우 다음 대사 진행
			if ( dialogs.Length > currentDialogIndex + 1 )
			{
				SetNextDialog();
			}
			// 대사가 더 이상 없을 경우 모든 오브젝트를 비활성화하고 true 반환
			else
			{
				// 현재 대화에 참여했던 모든 캐릭터, 대화 관련 UI를 보이지 않게 비활성화
				for ( int i = 0; i < speakers_opening.Length; ++ i )
				{
					SetActiveObjects(speakers_opening[i], false);
					// SetActiveObjects()에 캐릭터 이미지를 보이지 않게 하는 부분이 없기 때문에 별도로 호출
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
		
		// 이전 화자의 대화 관련 오브젝트 비활성화
		SetActiveObjects(speakers_opening[currentSpeakerIndex], false);
		
		// 다음 대사를 진행하도록 
		currentDialogIndex ++;

		// 현재 화자 순번 설정
		currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

		// 현재 화자의 대화 관련 오브젝트 활성화
		SetActiveObjects(speakers_opening[currentSpeakerIndex], true);
		// 현재 화자 이름 텍스트 설정
		speakers_opening[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;
		// 현재 화자의 대사 텍스트 설정
		speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
		
		StartCoroutine("OnTypingText");
	}

	private void SetActiveObjects(Speaker_Opening speaker_opening, bool visible)
	{
		speaker_opening.imageDialog.gameObject.SetActive(visible);
		speaker_opening.textName.gameObject.SetActive(visible);
		speaker_opening.textDialogue.gameObject.SetActive(visible);

		// 화살표는 대사가 종료되었을 때만 활성화하기 때문에 항상 false
		speaker_opening.objectArrow.SetActive(false);

		// 캐릭터 알파 값 변경
		//Color color = speaker.spriteRenderer.color;
		//color.a = visible == true ? 1 : 0.2f;
		//speaker.spriteRenderer.color = color;
		
	}

	public void SetOrginal()
    {
		isAutoStart = true;         // 자동 시작 여부
	    isFirst = true;                // 최초 1회만 호출하기 위한 변수
		currentDialogIndex = -1;    // 현재 대사 순번
		currentSpeakerIndex = 0;    // 현재 말을 하는 화자(Speaker)의 speakers 배열 순번
		typingSpeed = 0.1f;           // 텍스트 타이핑 효과의 재생 속도
		isTypingEffect = false;     // 텍스트 타이핑 효과를 재생중인지
    }

	private IEnumerator OnTypingText()
	{
		

		int index = 0;
		
		isTypingEffect = true;
		

		// 텍스트를 한글자씩 타이핑치듯 재생
		while ( index < dialogs[currentDialogIndex].dialogue.Length )
		{
			
			speakers_opening[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);
			
			index ++;
			
			yield return new WaitForSecondsRealtime(0.1f);
			
		}

		isTypingEffect = false;

		// 대사가 완료되었을 때 출력되는 커서 활성화
		speakers_opening[currentSpeakerIndex].objectArrow.SetActive(true);
	}
}

[System.Serializable]
public struct Speaker_Opening
{
	//public	SpriteRenderer	spriteRenderer;		// 캐릭터 이미지 (청자/화자 알파값 제어)
	public	Image			imageDialog;		// 대화창 Image UI
	public	TextMeshProUGUI	textName;			// 현재 대사중인 캐릭터 이름 출력 Text UI
	public	TextMeshProUGUI	textDialogue;		// 현재 대사 출력 Text UI
	public	GameObject		objectArrow;        // 대사가 완료되었을 때 출력되는 커서 오브젝트
}

[System.Serializable]
public struct DialogData_Opening
{
	public	int		speakerIndex;	// 이름과 대사를 출력할 현재 DialogSystem의 speakers 배열 순번
	public	string	name;			// 캐릭터 이름
	[TextArea(3, 5)]
	public	string	dialogue;		// 대사
}

[System.Serializable]

public struct BackGround_Opening
{
	public RawImage background;
}


