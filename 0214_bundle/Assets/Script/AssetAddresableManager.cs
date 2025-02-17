using System.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class AssetAddresableManager : MonoBehaviour
{
    /*
     ### AssetReference�� Ư�� Ÿ���� �������� �ʰ� ��巹������ ���Ҹ� ����
    > AssetReferenceGameObject�� ��巹���� ���ҽ��߿��� GameObject�� �ش��ϴ� ���� ����
    > AssetReferenceT�� ���׸��� �̿��� Ư�� ������ ��巹���� ���ҽ��� ���� 
      >> public AssetReferenceT<GameObject> manager;
     */

    public AssetReferenceGameObject capsule;


    public GameObject go = new GameObject();

    private void Start()
    {
        StartCoroutine("Init"); //�Լ��� �ƴҶ� ����("")
    }
    private IEnumerator Init()
    {
        var init = Addressables.InitializeAsync(); // Addressables�� �ִ� ���� �񵿱�ȭ 
        yield return init; //�Ϸ�ɶ����� ���
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
        Addressables.ReleaseInstance(go); //����
    }
}
