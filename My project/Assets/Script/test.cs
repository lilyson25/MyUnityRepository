using UnityEngine;
//using은 다음에 적힌것을 

/// <summary>
/// 우리가 처음으로 만든 스크립트
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
        Debug.Log($"{count}좌우 반복 뛰기");
        count++;
    }
}
