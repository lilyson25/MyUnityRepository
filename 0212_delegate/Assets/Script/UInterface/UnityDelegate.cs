/*using UnityEngine;
using System;

//유니티에서 제공해주는 델리게이트 : using System; 필요

public class UnityDelegate : MonoBehaviour //c# 책 about 560p
{
    //Action delegate
    //1. 환타입이 따로 필요없는 void 형태의 대리자
    //Action delegate명;
    Action action;

    //2. 매개변수가 있는 경우
    // Action<T> delegate형
    Action<int> action2;
    Action<string, int> action2; //overloading에서는 ( , )순서를 맞춰준다

    //3. Func delegate
    //반환 타입(리턴값)을 가지는 형태의 대리자 : Fun<매개변수, 매개변수, 리턴값>형태
    Func<int> func01;
    Func<int, int, int> func02;   

    
    //오버로드 개념
    //일반적으로 함수명은 고유하게 존재함
    //but다음 조건을 지킬경우 같은 이름의 메소드를 사용할 수 있다

    //매개변수의 개수, 타입, 순서가 다르다면 다른메소드로 인식

    //오버로딩 사용을 통해 약간의 상황에 따라 매번 메소드의 이름을 만들어 줄 필요없이 
    //특정 기능을 진행하는 같은 이름의 메소드를 만들어 이름을 절약할 수 있다



    //오버라이딩(Overriding)
    //부모 클래스로부터 상속받은 메소드를 자식 클래스에서 재정의하는 행의
    //인터페이스, abstract class에서 선언(정의)만 되어있는 메소드를 전달받은 경우 -> 강제적으로 구현해야 합니다

    //하위 클래스에서 원하는 기능에 대한 구현
    //인터페이스, abstrat class 등에서 제공받은 틀에 맞춰 정돈된 코드 설계 가능
    //하나의 객체로 여러 형태를 표현하는 다향성 구현에도 효과적

   *//* void Start()
    {
        action = Sample;
        action();

        action2 = Sample1;

        //대리자의 경우 바로 기능을 구현해서 사용하는 것도 가능
        func01 = () => 10;
        *//*
         풀어져있는 상태 예)
        func01 = test;
        ---------------
        int Test()
        {
        return 10;
        }
         ---------- 
         *//*


        //만드는 방법
        //func<T> 이름 = (매개변수 작성 위치) => 값;
        func01<int> test = () => 10;

        //매개변수가 존재하는 경우
        func02 = (a, b) => a + b;

        //식을 여러개 적어야 하는 경우
        func02 = (a, b) =>
        {
            if (a > b)
            {
                a = b;
            }
            return a + b;
        };
    
    }

    // Update is called once per frame
    
    public void Sample() 
    { 
    }
    public void Sample(int a)
    {

    }
    public void Sample(string s, int a) 
    { 
    }
    public int Sample3() 
    { 
        return 0; 
    }
}*/
