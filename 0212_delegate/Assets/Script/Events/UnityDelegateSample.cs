using System;
using UnityEngine;
using UnityEngine.UI; // UI를 사용하기 위해 추가

/*
## Delegate를 이용한 Event (더 쉬운 방법)
> 함수의 이름을 찾아서 내부의 기능을 추적하는 기능 
 */

class MeetEvent
{
    // 델리게이트 타입 선언
    public delegate void MeetEventHandler(string Msg);

    // 이벤트 선언
    public event MeetEventHandler meethandler;

    public void Meet()
    {
        // 이벤트가 구독된 경우에만 호출 (null 체크)
        meethandler?.Invoke("asddsfdsfds");
    }
}

public class UnityDelegateSample : MonoBehaviour
{
    public Text messageUI; // UI Text 요소를 유니티 인스펙터에서 연결해야 함

    // MeetEvent 인스턴스 생성
    MeetEvent meetEvent = new MeetEvent();

    void Start()
    {
        // 이벤트 구독
        meetEvent.meethandler += EventMsg;
    }

    // 이벤트가 발생하면 실행될 함수
    private void EventMsg(string msg)
    {
        messageUI.text = msg; // UI에 메시지 출력
    }

    // 버튼을 누를 때 호출할 메서드
    public void OnMeetButtonEnter()
    {
        meetEvent.Meet(); // MeetEvent의 Meet() 실행
    }
}
