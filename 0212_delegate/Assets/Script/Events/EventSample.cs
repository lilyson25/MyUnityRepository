/*using System;
using UnityEngine;

*//*
# event
> ��ü�� �۾� ������ �˸��� �޽���
> �̺�Ʈ�� �̺�Ʈ �����ڿ��� Ư�� �۾��� �˷��ִ� ���

#### Event Handler 
> �̺�Ʈ�� �߻��� �� � ����� �������� �������ִ� ��

* �̺�Ʈ�� += �����ڸ� ���� �̺�Ʈ �ڵ巯�� �̺�Ʈ�� �߰��� �� �ִ�
* -= �����ڸ� ���� �̺�Ʈ �ڵ鷯�� �����ϴ� ���� ����
* �ϳ��� �̺�Ʈ���� ���� ���� �̺�Ʈ �ڵ鷯�� �߰��ϴ� ���� ����
* �߰��� �ڵ鷯���� ���������� ȣ��

##### �̺�Ʈ ����
   -  1. �̺�Ʈ�� ������ = new �̺�Ʈ��(); 
   -  2. �̺�Ʈ �ڵ巯�� �̺�Ʈ ���� : ~~ += ~~ 
   -  3. �̺�Ʈ ������ ���� ��� ����
   -  4.�̺�Ʈ�� �߻������� ����� �ڵ�
```    
public void OnKill()
 {
        CountPlus(); //ų �� ����
        if (count == 5)
        {
            count = 0;//���� 
            kill(this, EventArgs.Empty); //�̺�Ʈ �ڵ鷯���� ȣ���մϴ�
        }
        else
        {
            Debug.Log($"fdfsfsdf");
        }
}
```
 *//*

class SpecialPortalEvent
{
    public event EventHandler kill;

    int count = 0;

    public void OnKill()
    {
        CountPlus(); //ų �� ����
        if (count == 5)
        {
            count = 0;//���� 
            kill(this, EventArgs.Empty); //�̺�Ʈ �ڵ鷯���� ȣ���մϴ�
        }
        else
        {
            Debug.Log($"fdfsfsdf");
        }
    }
public void CountPlus() => count++;

}

public class EventSample : MonoBehaviour
{

 
    SpecialPortalEvent specialPortalEvent = new SpecialPortalEvent();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        specialPortalEvent.kill += new EventHandler(Monsterkill);    
    }

}
*/