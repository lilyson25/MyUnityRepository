using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{

    public Button playMusicBt;
    public Button stopMusicBt;
    public AudioClip bgm;
   public AudioSource audioSourceBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playMusicBt.onClick.AddListener(PlayMusic);//�Լ�����
        stopMusicBt.onClick.AddListener(StopMusic);

    }
    void PlayMusic()
    {
         audioSourceBGM.clip = bgm;
         bgm = GameObject.Find("BGM").GetComponent<AudioClip>();
         audioSourceBGM.Play(); //Ŭ������
        Debug.Log("start");
    }
    void StopMusic()
    {
        audioSourceBGM.clip = bgm;
        bgm = GameObject.Find("BGM").GetComponent<AudioClip>();
        audioSourceBGM.Stop(); 
        Debug.Log("stop");

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
