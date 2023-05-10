using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Soundmenu : MonoBehaviour
{
    //오디오 믹서
    public AudioMixer audioMixer;

    //슬라이더
    public Slider BgmSlider;
    public Slider SfxSlider;

    //볼륨 조절
    public void SetBgmVolme()
    {
        //매끄러운 느낌위해 로그값 전달
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
        //슬라이더가 제공하는 메서드, 파라미터와 볼륨값 전달
    }

    public void SetSfxVolme()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
        // Mathf: 수학과 관련된 메서드 모임
    }
}
