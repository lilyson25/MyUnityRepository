using System;
using UnityEngine;
using UnityEngine.UI; // UI�� ����ϱ� ���� �߰�

/*
## Delegate�� �̿��� Event (�� ���� ���)
> �Լ��� �̸��� ã�Ƽ� ������ ����� �����ϴ� ��� 
 */

class MeetEvent
{
    // ��������Ʈ Ÿ�� ����
    public delegate void MeetEventHandler(string Msg);

    // �̺�Ʈ ����
    public event MeetEventHandler meethandler;

    public void Meet()
    {
        // �̺�Ʈ�� ������ ��쿡�� ȣ�� (null üũ)
        meethandler?.Invoke("asddsfdsfds");
    }
}

public class UnityDelegateSample : MonoBehaviour
{
    public Text messageUI; // UI Text ��Ҹ� ����Ƽ �ν����Ϳ��� �����ؾ� ��

    // MeetEvent �ν��Ͻ� ����
    MeetEvent meetEvent = new MeetEvent();

    void Start()
    {
        // �̺�Ʈ ����
        meetEvent.meethandler += EventMsg;
    }

    // �̺�Ʈ�� �߻��ϸ� ����� �Լ�
    private void EventMsg(string msg)
    {
        messageUI.text = msg; // UI�� �޽��� ���
    }

    // ��ư�� ���� �� ȣ���� �޼���
    public void OnMeetButtonEnter()
    {
        meetEvent.Meet(); // MeetEvent�� Meet() ����
    }
}
