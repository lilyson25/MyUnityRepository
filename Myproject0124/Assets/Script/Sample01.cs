using System;
using JetBrains.Annotations;
using UnityEngine;

//��Ƽüũ�� �����Ҷ��� flags�� �����
//enum������ �빮�ڷθ� �����ִ� �� ��ȣ

public enum Rainbow
{
    ��, ��, ��, ��, ��, ��, ��
}

[AddComponentMenu("SON/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool Jumping;
    public string[] basket; //[]�� ���� ����:add�� �����ϰ� �Ҷ�
    public int money; 
    [Range(1,99)] public int FOV;
    public Rainbow rainbow;
    //���� ����� enum��������ʿ�
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
