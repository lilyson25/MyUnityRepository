using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddresableManager : MonoBehaviour
{
    /*
     ### AssetReference는 특정 타입을 지정하지 않고 어드레서블의 리소를 참조
    > AssetReferenceGameObject는 어드레서블 리소스중에서 GameObject에 해당하는 값을 참조
    > AssetReferenceT는 제네릭을 이용해 특정 형태의 어드레서블 리소스를 참조 
      >> public AssetReferenceT<GameObject> manager;
     */

    public AssetReferenceGameObject capsule;


    public GameObject go = new GameObject();

    private void Start()
    {
        StartCoroutine("Init"); //함수가 아닐때 보통("")
    }
    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync(); // Addressables에 있는 값을 비동기화 
        yield return init; //완료될때까지 대기
    }

    public void OnCreateButtonEnter()
    {
        capsule.InstantiateAsync().Completed += (obj) =>
        {
            go = obj.Result;
        };

    }

    public void OnReleaseButtonEnter()
    {
        Addressables.ReleaseInstance(go); //해제
    }
}
