# 오늘의 수업 : Event
> 유니티 인터페이스 interface
 * 공통적인 특징에 대한 관리 구현 시 효과적
 * 함수나 프로퍼티 등의 정의를 구현없이 진행할 수 잇도록 도와주는 기능
 * 인터페이스는 명시만 하기 때문에, 사용하기위해서는 상속을 통한 재구현으로 진행

### ClassDiagram 생성방법
> 마우스우클릭 classDiagram> add 빈공간 클릭> class 생성> 
- class Potion : Item 을 넣어주면 화살표 생성
- 오류 발생시, 선생성 후 다이어그램에 드래그해서 추가가능
- 공백클릭> 우클릭> export관련 메뉴 클릭> Diagram을 이미지로 export할 수 있다

---
### 유니티에서 제공해주는 Event, Ipointer
- Ipointer Interface : 기본제공되는 인터페이스
- 다음과 같은 조건이 필요함
    - 클릭, 터피, 드래그 등의 이벤트를 구현할때 사용 
    - 1. UI 오브젝트에는 Graphic Raycaster 컴포넌트가 추가되어있어야 하고, Raycast Target이 체크된 상태여야 함
    - 2. Scene에는 Event System 컴포넌트가 존재해야 한다
    - 3. 오브젝트에 대한 작업시에는 Collider 컴포넌트가 추가되어야 한다
    - 4. Main camera에 Physics Raycaster 컴포넌트가 추가되어야 한다
      
#### 지원되는 이벤트
- IPointerEnterHandler - OnPointerEnter - 포인터가 오브젝트에 들어갈 때 호출됩니다.
- IPointerExitHandler - OnPointerExit - 포인터가 오브젝트에서 나올 때 호출됩니다.
- IPointerDownHandler - OnPointerDown - 포인터가 오브젝트 위에서 눌렸을 때 호출됩니다.
- IPointerUpHandler - OnPointerUp - 포인터를 뗄 때 호출됩니다(눌려 있던 오브젝트에서 호출됩니다).
- IPointerClickHandler - OnPointerClick - 동일 오브젝트에서 포인터를 누르고 뗄 때 호출됩니다.
- IInitializePotentialDragHandler - OnInitializePotentialDrag - 드래그 타겟이 발견되었을 때 호출됩니다. 값을 초기화하는 데 사용할 수 있습니다.
- IBeginDragHandler - OnBeginDrag - 드래그가 시작되는 시점에 드래그 대상 오브젝트에서 호출됩니다.
- IDragHandler - OnDrag - 드래그 오브젝트가 드래그되는 동안 호출됩니다.
- IEndDragHandler - OnEndDrag - 드래그가 종료됐을 때 드래그 오브젝트에서 호출됩니다.
- IDropHandler - OnDrop - 드래그를 멈췄을 때 해당 오브젝트에서 호출됩니다.
- IScrollHandler - OnScroll - 마우스 휠을 스크롤했을 때 호출됩니다.
- IUpdateSelectedHandler - OnUpdateSelected - 선택한 오브젝트에서 매 틱마다 호출됩니다.
- ISelectHandler - OnSelect - 오브젝트를 선택하는 순간 호출됩니다.
- IDeselectHandler - OnDeselect - 선택한 오브젝트를 선택 해제할 때 호출됩니다.
- IMoveHandler - OnMove - 이동 이벤트(왼쪽, 오른쪽, 위쪽, 아래쪽 등)가 발생했을 때 호출됩니다.
- ISubmitHandler - OnSubmit - 전송 버튼이 눌렸을 때 호출됩니다.
- ICancelHandler - OnCancel - 취소 버튼이 눌렸을 때 호출됩니다.
---
## Delegate(델리게이트), Factory(팩토리), Observer(옵저버) 패턴 (비교해서 편리한것으로 선택가능)
### Delegate 
> 함수를 대입할 수 있는 변수. 대리자라고 부른다, 콜백(Callback) 기능을 제공하는 패턴으로 특정 이벤트가 발생하면 미리 등록된 함수(메서드)가 자동으로 실행

* 해당변수에는 함수가 대입되어있으므로 해당변수를 실행하면 대입한 함수가 실행되는 방식
* delegate 선언 방법 : 접근제한자 delegate 타입 델리게이트(매개변수)
  - delegate void DelegateTest2(int a, int b);
  - delegate string DelegateText(float x);
  - delegate int DelegateInt(int x, int y);
* delegate변수 만들어서 객체를 할당하는 이유?
  - delegate는 함수가 아닌 타입이기 때문
  - 매개변수로도 활용이 가능, return타입으로 잡아주는 것도 가능
* 델리게이트 변수처럼 사용 -> 델리게이트 변수명 = new 델리게이트명(함수명); ex)DelegateTest dt = new DelegateTest(Attack);
* 델리게이트 체인
  - delegae는 +=를 통해 대리할 함수를 더 추가할 수 잇고 -=를 통해 대리한 함수를 제거도 가능
```
//ex1)
void UseDelegate(DelegateTest dt)
{
    dt();
}

//ex2)
 DelegateTest Selection(int value)
{
    if(value == 0) return Attack;
    else if (value == 1) return Guard; 
    else return MoveLeft;
}
```

### Observer
>
---
## Event
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

### Delegate를 이용한 Event (더 쉬운 방법)
> 함수의 이름을 찾아서 내부의 기능을 추적하는 기능 


# 과제 : class 다이아그램 만들어서 캡쳐해서 올리기
