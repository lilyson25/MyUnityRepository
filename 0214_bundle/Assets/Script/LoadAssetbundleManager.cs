using System.Collections;
using System.IO;//추가
using UnityEngine;

public class LoadAssetbundleManager : MonoBehaviour
{
    //Load는 대부분 코르틴과 함께한다

    //경로작성
    string path = "Assets/Bundle/asset01";
   
    void Start()
    {
        StartCoroutine(LoadAsync(path)); //비동기로 로드하는 코드
    }
    IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path)); //Load Memory이기때문에 bytes를 불러들인다
        yield return request; //request가 끝날때까지 대기

        AssetBundle bundle = request.assetBundle; //request를 통해 받아온 에셋 번들의 정보를 적용한다

        //전달받은 번들을 통해 에셋을 로드
        GameObject prefab = bundle.LoadAsset<GameObject>("RedS");
        
        
        Instantiate(prefab);
       
    }
}
