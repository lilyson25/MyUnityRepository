using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 * 슬라이더는 UI 
 * 
 * 자동완성으로 만들어지는 슬라이더 조인트 2D의 경우는 
 * Rigidbody 물리제어를 받은 게임 오브젝트가 공간에서 선을 따라 미끌어지게 하는 설정을 할 때 사용
 * ex) 미닫이문
 * */

public class SoundControler : MonoBehaviour
{

    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider MasterVolumeSlider;
    [SerializeField] private Slider BGMVolumeSlider;
    [SerializeField] private Slider SFXVolumeSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        MasterVolumeSlider.onValueChanged.AddListener(SetMaster);
        BGMVolumeSlider.onValueChanged.AddListener(SetBGM);
        SFXVolumeSlider.onValueChanged.AddListener(SetSFX);
    }
    private void SetSFX(float volume)
    {
        //오디오믹서가 가지고 잇는 파라미터(expose)의수치를 설정하는 기능
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    private void SetBGM(float volume)
    {
        //오디오믹서가 가지고 잇는 파라미터(expose)의수치를 설정하는 기능
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
   

    private void SetMaster(float volume)
    {
         //오디오믹서가 가지고 잇는 파라미터(expose)의수치를 설정하는 기능
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        /*  
             [H2] 자주사용되는 Mathf함수
             * 1. Mathf.Deg2Rad
               degree(60분법)을 통해 radian(호도법)을 계산하는 코드 --> 각도 계산 코드
               PI/180 또는 pi*2 / 360
         
             * 2. Mathf.Rad2Deg
               라디안 값을 디그리 값으로 바꿔줌
               360/ (pi*2)
               1라디안은 약 57도

             * 3. Mathf.Abs
               절대값을 계산해주는 기능
             
             * 4. Mathf.Athan
               아크 탄젠트 값을 계산

             * 5. Mathf.ceil
               소수점 올림 계산

             * 6. Mathf.Clamp(value, min, max)  -----> 가장자주사용됨
               value를 main과 max사이의 값으로 고정
              
             * 7. Mathf.Log10
               베이스가 10으로 지정되어있는 수의 로그를 반환해주는 기능
               ex) Debug.Log(Mathf.Log10(100))

             이번 예제에서는 오디오 믹서의 최소 ~ 최대 볼륨 값 때문에 로그 함수가 사용됨
             최소가 -80, 최대가 0
             수치변경시 Mathf.Log10(슬라이더 수치) * 20);을 통해 범위를 설정하고
             슬라이더의 최소 값이 0.01일 경우 -80이 1일 경우 0이 계산됨
        */
    }
}
 


    //Event코드는 update를 짤 필요가 없음