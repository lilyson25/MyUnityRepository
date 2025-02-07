using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioBoardVisualizer : MonoBehaviour
{
    public float minBoard = 50.0f;
    public float maxBoard = 543.0f;

    public Board[] boards;
    public AudioClip audioClip; //����� �����Ŭ��
    public AudioSource audioSource; //����� ������ҽ�
    public AudioMixer audioMixer;

    //����Ʈ���� samples
    public int samples = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boards = GetComponentsInChildren<Board>();
        //GetComponentsInChildren<T>�� ������Ʈ ����� �ڽ� ������Ʈ���� �������� �ڵ�
        //���� �ڵ� �������δ� Board�� �迭

        if (audioSource == null)
        {
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();//���ӿ�����Ʈ�� ���� ������Ʈ�� ������ִ� �ڵ�
        }
        else
        { 
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        //������ͼ� �׷��߿��� "Master"�׷��� ã�� ����
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        //GetSpectrumData(samples, channel, FFTWindow);

        //samples = FFT(��ȣ�� ���� ���ļ� ����)�� ������ �迭, �� �迭���� 2�� �������� ǥ��
        //ä���� �ִ� 8���� ä���� �������� �Ϲ������� 0���
        //FFTWindow�� ���ø� �����Ҷ� ���� ��

        for (int i = 0; i < boards.Length; i++) //���� ������ ������ŭ �۾��� ������
        { 
           var size = boards[i].GetComponent<RectTransform>().rect.size;
            //���� ������ ������ �ִ� ����� �����ٴ�

            size.y = minBoard + (data[i] * (maxBoard - minBoard)); //���⼭ ũ�⸦ ���������� �� Ű��� ������ �� �ڿ� '~minBoard)* 3.0f)' ���� ������ ���ָ� ��
            boards[i].GetComponent<RectTransform>().sizeDelta = size; //sizeDelta�� �θ� �������� ũ�Ⱑ �󸶳� ū�� �������� ��Ÿ�� ��ġ
        }
    }
}
