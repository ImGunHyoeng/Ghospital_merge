using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewOption : MonoBehaviour
{
    FullScreenMode screenMode;
    public Dropdown resolutionDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    public int resolutionNum;

    void Start()
    {
      InitUI();
    }

    
    void InitUI()
    {
        //resolutions.AddRange(Screen.resolutions); 모든 해상도 배열에 넣기
        //화면 재생빈도가 60인 값만 가져와서 목록에 넣기
        for(int i = 0;i<Screen.resolutions.Length;i++)
        {
            if (Screen.resolutions[i].refreshRate == 60 && Screen.resolutions[i].width >= 800)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutionDropdown.options.Clear();

        int optionNum = 0;//드롭다운 넘버 초기화
        foreach(Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " "+ item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)//현재 해상도와 비교해서 같은지 확인 후 초기화시키기
                resolutionDropdown.value = optionNum;
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();
        // resolutions: 모니터의 해상도 설정을 저장하는 배열
        // 아래 출력을 통해 해상도가 저장되고 출력됨을 확인 할 수 있다.
        //foreach(Resolution item in resolutions)
        //{
        //    Debug.Log(item.width + "X" + item.height + " " + item.refreshRate);
        //}
    }

    public void DropboxOptionChange(int x)
    {
        resolutionNum = x;
    }

    public void OkBthClick()
    {
        //Screen.SetResolution(너비,높이,전체화면,화면 재생빈도)
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
    }

}
