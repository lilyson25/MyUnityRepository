using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSample : MonoBehaviour
{


    public AudioSource audioSourceBGM;
    public AudioClip bgm; //오디오클립에 대한 연결



    // private AudioSource own_audioSource;
    public AudioSource audioSourceSFX;   // 씬에서 찾아서 연결하는 경우

    //Resources.Load()기능을 이용해 리소스 폴더에 있는 오디오소스 받아온다



    void Start()
    {
        // own_audioSource = GetComponent<AudioSource>();

        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();// GameObject.Find()씬에서 찾은 gameObject를 return하는 기능을 가지고 있어, 이 값은 gameObject다
                                                                            //GameObject이기에 GetComponent<T>를 이어 작성함으로 오브젝트가 가진 컴포넌트의 값을 return함

        audioSourceBGM.clip = bgm;
        //오디오소스의 클립을 bgm으로 설정

        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resources폴더내 오브젝트를 찾아 로드
        //받아오는 값은 Object이므로 'as 클래스명'을 통해 데이터 형태 표현

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //리소스 로드시 경로가 정해져있다면 '폴더명/파일명'으로 작성, 확장자 필요없음


        StartCoroutine("GetAudioClip"); //UnityWebRequest의 GetAudioClip기능 활용



        audioSourceBGM.Play(); //클립실행
        /*  audioSourceSFX.Pause();
          audioSourceBGM.UnPause();
          audioSourceSFX.PlayOneShot(bgm); //클립하나를 한순간 플레이
          audioSourceBGM.Stop(); //재생중지
          audioSourceBGM.PlayDelayed(1.0f); //1초뒤 실행
          */
    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest umr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/"+"Explosion"+".wav", AudioType.WAV);
        yield return umr.SendWebRequest(); //전달

        var new_clip = DownloadHandlerAudioClip.GetContent(umr);
        audioSourceBGM.clip = new_clip;
        audioSourceBGM.Play();

    }//작업이 끝나면 값 사라짐
}
