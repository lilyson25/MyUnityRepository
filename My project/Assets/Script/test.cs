using UnityEngine;
//using�� ������ �������� 

/// <summary>
/// �츮�� ó������ ���� ��ũ��Ʈ
/// 
/// </summary>
public class test : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("'Hello'");
    }
    int count= 0;

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"{count}�¿� �ݺ� �ٱ�");
        count++;
    }
}
