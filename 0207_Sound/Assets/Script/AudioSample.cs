using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSample : MonoBehaviour
{


    public AudioSource audioSourceBGM;
    public AudioClip bgm; //�����Ŭ���� ���� ����



    // private AudioSource own_audioSource;
    public AudioSource audioSourceSFX;   // ������ ã�Ƽ� �����ϴ� ���

    //Resources.Load()����� �̿��� ���ҽ� ������ �ִ� ������ҽ� �޾ƿ´�



    void Start()
    {
        // own_audioSource = GetComponent<AudioSource>();

        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>();// GameObject.Find()������ ã�� gameObject�� return�ϴ� ����� ������ �־�, �� ���� gameObject��
                                                                            //GameObject�̱⿡ GetComponent<T>�� �̾� �ۼ������� ������Ʈ�� ���� ������Ʈ�� ���� return��

        audioSourceBGM.clip = bgm;
        //������ҽ��� Ŭ���� bgm���� ����

        audioSourceSFX.clip = Resources.Load("Explosion") as AudioClip;
        //Resources������ ������Ʈ�� ã�� �ε�
        //�޾ƿ��� ���� Object�̹Ƿ� 'as Ŭ������'�� ���� ������ ���� ǥ��

        audioSourceSFX.clip = Resources.Load("Audio/BombCharge") as AudioClip;
        //���ҽ� �ε�� ��ΰ� �������ִٸ� '������/���ϸ�'���� �ۼ�, Ȯ���� �ʿ����


        StartCoroutine("GetAudioClip"); //UnityWebRequest�� GetAudioClip��� Ȱ��



        audioSourceBGM.Play(); //Ŭ������
        /*  audioSourceSFX.Pause();
          audioSourceBGM.UnPause();
          audioSourceSFX.PlayOneShot(bgm); //Ŭ���ϳ��� �Ѽ��� �÷���
          audioSourceBGM.Stop(); //�������
          audioSourceBGM.PlayDelayed(1.0f); //1�ʵ� ����
          */
    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest umr = UnityWebRequestMultimedia.GetAudioClip("file:///" + Application.dataPath + "/Audio/"+"Explosion"+".wav", AudioType.WAV);
        yield return umr.SendWebRequest(); //����

        var new_clip = DownloadHandlerAudioClip.GetContent(umr);
        audioSourceBGM.clip = new_clip;
        audioSourceBGM.Play();

    }//�۾��� ������ �� �����
}
