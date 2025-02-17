/*using System;
using UnityEngine;

*//*
# event
> 개체에 작업 실행을 알리는 메시지
> 이벤트는 이벤트 가입자에게 특정 작업을 알려주는 기능

#### Event Handler 
> 이벤트가 발생할 때 어떤 명령을 실행할지 지정해주는 것

* 이벤트는 += 연산자를 통해 이벤트 핸드러를 이벤트에 추가할 수 있다
* -= 연산자를 통해 이벤트 핸들러를 삭제하는 것이 가능
* 하나의 이벤트에는 여러 개의 이벤트 핸들러를 추가하는 것이 가능
* 추가한 핸들러들은 순차적으로 호출

##### 이벤트 정의
   -  1. 이벤트명 변수명 = new 이벤트명(); 
   -  2. 이벤트 핸드러에 이벤트 연결 : ~~ += ~~ 
   -  3. 이벤트 진행을 위해 기능 진행
   -  4.이벤트가 발생했을때 실행될 코드
```    
public void OnKill()
 {
        CountPlus(); //킬 수 증가
        if (count == 5)
        {
            count = 0;//리셋 
            kill(this, EventArgs.Empty); //이벤트 핸들러들을 호출합니다
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
        CountPlus(); //킬 수 증가
        if (count == 5)
        {
            count = 0;//리셋 
            kill(this, EventArgs.Empty); //이벤트 핸들러들을 호출합니다
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