using System.Collections;
using System.IO;//�߰�
using UnityEngine;

public class LoadAssetbundleManager : MonoBehaviour
{
    //Load�� ��κ� �ڸ�ƾ�� �Բ��Ѵ�

    //����ۼ�
    string path = "Assets/Bundle/asset01";
   
    void Start()
    {
        StartCoroutine(LoadAsync(path)); //�񵿱�� �ε��ϴ� �ڵ�
    }
    IEnumerator LoadAsync(string path)
    {
        AssetBundleCreateRequest request = AssetBundle.LoadFromMemoryAsync(File.ReadAllBytes(path)); //Load Memory�̱⶧���� bytes�� �ҷ����δ�
        yield return request; //request�� ���������� ���

        AssetBundle bundle = request.assetBundle; //request�� ���� �޾ƿ� ���� ������ ������ �����Ѵ�

        //���޹��� ������ ���� ������ �ε�
        GameObject prefab = bundle.LoadAsset<GameObject>("RedS");
        
        
        Instantiate(prefab);
       
    }
}
