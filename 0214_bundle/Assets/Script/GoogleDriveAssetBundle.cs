using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GoogleDriveAssetBundle : MonoBehaviour
{

    private string imageFileURL = "https://docs.google.com/uc?export=download&id=12uSZCSTLhRFVkrRmD0YWRPheSwFBIQ7s";
    public Image image;
    public Button button;
    // 
    void Start()
    {
       
        button.onClick.AddListener(() => StartCoroutine("DownLoadImage"));
    }

    // Update is called once per frame
    IEnumerator DownLoadImage()
    {
        //�ش� �ּҸ� ���� �ؽ�ó�� ������Ʈ ��û (request = �������� ����)
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        yield return www.SendWebRequest();   //������Ʈ�� �Ϸ�ɶ����� ����մϴ�

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f); //�̹�����ȯ�� �ڵ�, Texture 2D�� UI���� sprite���·� ����
            Debug.Log("����");

            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("���ķ�");

        }
    }
}
