using System;
using JetBrains.Annotations;
using UnityEngine;

//멀티체크가 가능할때만 flags를 사용함
//enum에서는 대문자로만 적어주는 걸 선호

public enum Rainbow
{
    빨, 주, 노, 초, 파, 남, 보
}

[AddComponentMenu("SON/Sample01")]
public class Sample01 : MonoBehaviour
{
    public bool Jumping;
    public string[] basket; //[]가 들어가는 이유:add가 가능하게 할때
    public int money; 
    [Range(1,99)] public int FOV;
    public Rainbow rainbow;
    //위에 선언된 enum변수등록필요
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
