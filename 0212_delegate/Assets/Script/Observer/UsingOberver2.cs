/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Isubject�� ������� �����ϴ� ������ ��� ����
public class UsingObserver2 : MonoBehaviour
{
    List<UOberver> observers = new List<UObserver>(); //������ ���� ���� �����ϱ� ���� ������ ����Ʈ

    private void Add(UObserver observer)
    {
        observers.Add(observer);
    }

    private void Nofify()
    {
        foreach (var observer in observers)
        {
            observer.OnNotify();
        }

    }
    private void Remove(UObserver observer)
    {
        if (observers.Count > 0)
            observers.Remove(observer);
    }

    void Start()
    {
        var observer1 = new Observer1();
        var observer2 = new Observer2();

        Add(observer1);
        Add(observer2);

    }*/