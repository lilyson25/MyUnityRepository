using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

/*
 * �����̴��� UI 
 * 
 * �ڵ��ϼ����� ��������� �����̴� ����Ʈ 2D�� ���� 
 * Rigidbody ������� ���� ���� ������Ʈ�� �������� ���� ���� �̲������� �ϴ� ������ �� �� ���
 * ex) �̴��̹�
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
        //������ͼ��� ������ �մ� �Ķ����(expose)�Ǽ�ġ�� �����ϴ� ���
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }
    private void SetBGM(float volume)
    {
        //������ͼ��� ������ �մ� �Ķ����(expose)�Ǽ�ġ�� �����ϴ� ���
        audioMixer.SetFloat("BGM", Mathf.Log10(volume) * 20);
    }
   

    private void SetMaster(float volume)
    {
         //������ͼ��� ������ �մ� �Ķ����(expose)�Ǽ�ġ�� �����ϴ� ���
        audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);

        /*  
             [H2] ���ֻ��Ǵ� Mathf�Լ�
             * 1. Mathf.Deg2Rad
               degree(60�й�)�� ���� radian(ȣ����)�� ����ϴ� �ڵ� --> ���� ��� �ڵ�
               PI/180 �Ǵ� pi*2 / 360
         
             * 2. Mathf.Rad2Deg
               ���� ���� ��׸� ������ �ٲ���
               360/ (pi*2)
               1������ �� 57��

             * 3. Mathf.Abs
               ���밪�� ������ִ� ���
             
             * 4. Mathf.Athan
               ��ũ ź��Ʈ ���� ���

             * 5. Mathf.ceil
               �Ҽ��� �ø� ���

             * 6. Mathf.Clamp(value, min, max)  -----> �������ֻ���
               value�� main�� max������ ������ ����
              
             * 7. Mathf.Log10
               ���̽��� 10���� �����Ǿ��ִ� ���� �α׸� ��ȯ���ִ� ���
               ex) Debug.Log(Mathf.Log10(100))

             �̹� ���������� ����� �ͼ��� �ּ� ~ �ִ� ���� �� ������ �α� �Լ��� ����
             �ּҰ� -80, �ִ밡 0
             ��ġ����� Mathf.Log10(�����̴� ��ġ) * 20);�� ���� ������ �����ϰ�
             �����̴��� �ּ� ���� 0.01�� ��� -80�� 1�� ��� 0�� ����
        */
    }
}
 


    //Event�ڵ�� update�� © �ʿ䰡 ����