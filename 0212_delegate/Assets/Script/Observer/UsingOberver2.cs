/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Isubject를 기반으로 설계하는 옵저버 사용 예제
public class UsingObserver2 : MonoBehaviour
{
    List<UOberver> observers = new List<UObserver>(); //옵저버 여러 개를 관리하기 위한 옵저버 리스트

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