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
        //resolutions.AddRange(Screen.resolutions); ��� �ػ� �迭�� �ֱ�
        //ȭ�� ����󵵰� 60�� ���� �����ͼ� ��Ͽ� �ֱ�
        for(int i = 0;i<Screen.resolutions.Length;i++)
        {
            if (Screen.resolutions[i].refreshRate == 60 && Screen.resolutions[i].width >= 800)
                resolutions.Add(Screen.resolutions[i]);
        }
        resolutionDropdown.options.Clear();

        int optionNum = 0;//��Ӵٿ� �ѹ� �ʱ�ȭ
        foreach(Resolution item in resolutions)
        {
            Dropdown.OptionData option = new Dropdown.OptionData();
            option.text = item.width + "x" + item.height + " "+ item.refreshRate + "hz";
            resolutionDropdown.options.Add(option);

            if (item.width == Screen.width && item.height == Screen.height)//���� �ػ󵵿� ���ؼ� ������ Ȯ�� �� �ʱ�ȭ��Ű��
                resolutionDropdown.value = optionNum;
            optionNum++;
        }
        resolutionDropdown.RefreshShownValue();
        // resolutions: ������� �ػ� ������ �����ϴ� �迭
        // �Ʒ� ����� ���� �ػ󵵰� ����ǰ� ��µ��� Ȯ�� �� �� �ִ�.
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
        //Screen.SetResolution(�ʺ�,����,��üȭ��,ȭ�� �����)
        Screen.SetResolution(resolutions[resolutionNum].width,
            resolutions[resolutionNum].height,
            screenMode);
    }

}
