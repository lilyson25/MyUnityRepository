/*using UnityEngine;
using System;

//����Ƽ���� �������ִ� ��������Ʈ : using System; �ʿ�

public class UnityDelegate : MonoBehaviour //c# å about 560p
{
    //Action delegate
    //1. ȯŸ���� ���� �ʿ���� void ������ �븮��
    //Action delegate��;
    Action action;

    //2. �Ű������� �ִ� ���
    // Action<T> delegate��
    Action<int> action2;
    Action<string, int> action2; //overloading������ ( , )������ �����ش�

    //3. Func delegate
    //��ȯ Ÿ��(���ϰ�)�� ������ ������ �븮�� : Fun<�Ű�����, �Ű�����, ���ϰ�>����
    Func<int> func01;
    Func<int, int, int> func02;   

    
    //�����ε� ����
    //�Ϲ������� �Լ����� �����ϰ� ������
    //but���� ������ ��ų��� ���� �̸��� �޼ҵ带 ����� �� �ִ�

    //�Ű������� ����, Ÿ��, ������ �ٸ��ٸ� �ٸ��޼ҵ�� �ν�

    //�����ε� ����� ���� �ణ�� ��Ȳ�� ���� �Ź� �޼ҵ��� �̸��� ����� �� �ʿ���� 
    //Ư�� ����� �����ϴ� ���� �̸��� �޼ҵ带 ����� �̸��� ������ �� �ִ�



    //�������̵�(Overriding)
    //�θ� Ŭ�����κ��� ��ӹ��� �޼ҵ带 �ڽ� Ŭ�������� �������ϴ� ����
    //�������̽�, abstract class���� ����(����)�� �Ǿ��ִ� �޼ҵ带 ���޹��� ��� -> ���������� �����ؾ� �մϴ�

    //���� Ŭ�������� ���ϴ� ��ɿ� ���� ����
    //�������̽�, abstrat class ��� �������� Ʋ�� ���� ������ �ڵ� ���� ����
    //�ϳ��� ��ü�� ���� ���¸� ǥ���ϴ� ���⼺ �������� ȿ����

   *//* void Start()
    {
        action = Sample;
        action();

        action2 = Sample1;

        //�븮���� ��� �ٷ� ����� �����ؼ� ����ϴ� �͵� ����
        func01 = () => 10;
        *//*
         Ǯ�����ִ� ���� ��)
        func01 = test;
        ---------------
        int Test()
        {
        return 10;
        }
         ---------- 
         *//*


        //����� ���
        //func<T> �̸� = (�Ű����� �ۼ� ��ġ) => ��;
        func01<int> test = () => 10;

        //�Ű������� �����ϴ� ���
        func02 = (a, b) => a + b;

        //���� ������ ����� �ϴ� ���
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
