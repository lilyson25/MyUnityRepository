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
        //해당 주소를 통해 텍스처를 리퀘스트 요청 (request = 가져오는 역할)
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(imageFileURL);

        yield return www.SendWebRequest();   //리퀘스트가 완료될때까지 대기합니다

        if (www.result == UnityWebRequest.Result.Success)
        {
            var texture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 1.0f); //이미지변환용 코드, Texture 2D를 UI에서 sprite형태로 변경
            Debug.Log("성공");

            image.sprite = sprite;
        }
        else
        {
            Debug.LogError("ㅇㅔ러");

        }
    }
}
