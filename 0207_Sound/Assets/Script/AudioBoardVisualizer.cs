using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioBoardVisualizer : MonoBehaviour
{
    public float minBoard = 50.0f;
    public float maxBoard = 543.0f;

    public Board[] boards;
    public AudioClip audioClip; //사용할 오디오클립
    public AudioSource audioSource; //사용할 오디오소스
    public AudioMixer audioMixer;

    //스펙트럼용 samples
    public int samples = 64;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boards = GetComponentsInChildren<Board>();
        //GetComponentsInChildren<T>는 오브젝트 연결된 자식 컴포넌트들을 가져오는 코드
        //현재 코드 기준으로는 Board의 배열

        if (audioSource == null)
        {
            audioSource = new GameObject("AudioSource").AddComponent<AudioSource>();//게임오브젝트를 만들어서 컴포넌트를 등록해주는 코드
        }
        else
        { 
            audioSource = GameObject.Find("AudioSource").GetComponent<AudioSource>();
        }
        audioSource.clip = audioClip;
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        //오디오믹서 그룹중에서 "Master"그룹을 찾아 적용
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples, 0, FFTWindow.Rectangular);
        //GetSpectrumData(samples, channel, FFTWindow);

        //samples = FFT(신호에 대한 주파수 영역)를 저장할 배열, 이 배열값은 2의 제곱수로 표현
        //채널은 최대 8개의 채널을 지원해줌 일반적으로 0사용
        //FFTWindow는 샘플링 진행할때 쓰는 값

        for (int i = 0; i < boards.Length; i++) //보드 각각의 개수만큼 작업을 진행함
        { 
           var size = boards[i].GetComponent<RectTransform>().rect.size;
            //보드 각각이 가지고 있는 사이즈를 얻어오겟다

            size.y = minBoard + (data[i] * (maxBoard - minBoard)); //여기서 크기를 고정값으로 더 키우고 싶으면 맨 뒤에 '~minBoard)* 3.0f)' 등의 식으로 해주면 됨
            boards[i].GetComponent<RectTransform>().sizeDelta = size; //sizeDelta는 부모를 기준으로 크기가 얼마나 큰지 작은지를 나타낸 수치
        }
    }
}
