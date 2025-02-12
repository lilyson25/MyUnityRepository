# 유니티 이벤트(Event)와 인터페이스(Interface) 

## 하나) 유니티 인터페이스 interface 
 * 설계도 역할, 구현해야할 함수의 이름을 미리 정해두고 내용은 각 클래스에서 직접 작성
 * 상속받은 클래스는 반드시 해당 인터페이스에서 정의한 함수를 구현해야한다
 * 공통적인 특징에 대한 관리 구현 시 효과적
 * 함수나 프로퍼티 등의 정의를 구현없이 진행할 수 잇도록 도와주는 기능
 * 인터페이스는 명시만 하기 때문에, 사용하기위해서는 상속을 통한 재구현으로 진행
 * 예시 : 각 클래스가 "반드시" Use() 함수를 구현해야 한다는 규칙을 만들 수 있습니다!


```
public interface IUsable
{
    void Use(); // 아이템을 사용할 때 실행되는 함수
}

public class Potion : IUsable
{
    public void Use()
    {
        Debug.Log("포션을 사용했습니다!");
    }
}

public class Bomb : IUsable
{
    public void Use()
    {
        Debug.Log("폭탄을 던졌습니다!");
    }
}

// 사용 예제
IUsable potion = new Potion();
potion.Use();  // "포션을 사용했습니다!" 출력

IUsable bomb = new Bomb();
bomb.Use();  // "폭탄을 던졌습니다!" 출력
```


### ClassDiagram 생성방법
> 마우스우클릭 classDiagram> add 빈공간 클릭> class 생성> 
- class Potion : Item 을 넣어주면 화살표 생성
- 오류 발생시, 선생성 후 다이어그램에 드래그해서 추가가능
- 공백클릭> 우클릭> export관련 메뉴 클릭> Diagram을 이미지로 export할 수 있다

---
## 두울) 유니티에서 제공해주는 기본 Event, Ipointer Interface
> 유니티의 UI 이벤트 처리를 도와주는 인터페이스-> 마우스 클릭, 터치, 드래그 등의 이벤트를 쉽게 구현할 수 있음

* 🔹UI 이벤트가 동작하기 위한 필수 조건🔹 
  ✅ UI 오브젝트 설정
  - Graphic Raycaster 컴포넌트 추가 (UI에서 Ray를 감지하기 위해 필요)
  - Raycast Target 체크해야 함
  - 
  ✅ 씬(Scene) 설정   
  - Event System 컴포넌트가 존재해야 함 (자동으로 추가됨)
  - 
  ✅ 3D 오브젝트 설정 (클릭 가능하게 하려면)   
  - Collider 컴포넌트 추가 (예: BoxCollider)
  - 
  ✅ 카메라 설정   
  - Physics Raycaster 컴포넌트 추가 (3D 오브젝트의 클릭 이벤트 처리)
      
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
## 세엣) Delegate : Delegate (델리게이트), Factory(팩토리), Observer(옵저버) 패턴 (비교해서 편리한것으로 선택가능)
> 함수를 변수처럼 저장하고 실행할 수 있는 기능, 콜백 함수 (Callback Function) 역할을 할 수 있음
> 보통 함수를 실행하려면 직접 호출해야 하지만, 델리게이트를 사용하면 특정 시점에 자동으로 실행되도록 등록할 수 있습니다.

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
using System;
using UnityEngine;

public class DelegateExample : MonoBehaviour
{
    // 1. 델리게이트 선언 (두 개의 int를 받아서 int를 반환하는 함수)
    public delegate int Operation(int a, int b);

    void Start()
    {
        // 2. 델리게이트 변수 선언 및 함수 할당
        Operation operation = Add;
        Debug.Log(operation(10, 5)); // "15" 출력

        // 3. 델리게이트를 다른 함수로 변경 가능!
        operation = Multiply;
        Debug.Log(operation(10, 5)); // "50" 출력
    }

    int Add(int x, int y) => x + y;
    int Multiply(int x, int y) => x * y;
}
```

### Observer
*
*
*



---
## Event
> 개체에 작업 실행을 알리는 메시지
> 이벤트는 이벤트 가입자에게 특정 작업을 알려주는 기능
> 델리게이트를 이용하여 이벤트를 생성
> 이벤트 핸들러(Event Handler)를 통해 이벤트 발생 시 실행할 동작을 지정

#### Event Handler : 이벤트가 발생할 때 어떤 명령을 실행할지 지정해주는 것

* 이벤트는 += 연산자를 통해 이벤트 핸드러를 이벤트에 추가할 수 있다
* -= 연산자를 통해 이벤트 핸들러를 삭제하는 것이 가능
* 하나의 이벤트에는 여러 개의 이벤트 핸들러를 추가하는 것이 가능
* 추가한 핸들러들은 순차적으로 호출

##### 이벤트 정의
   -  1.델리게이트 선언 : 이벤트는 특정 함수와 연결되므로, 이벤트 핸들러(즉 델리게이트)를 선언
      ```
      public delegate void MyEventHandler(); // 이벤트 핸들러(델리게이트) 선언
      ```
      2. 이벤트 선언 : 델리게이트를 기반으로 선언하되, event 키워드를 붙이면 외부에서 직접 호출할 수 없고, 오직 이벤트를 발생시키는 코드에서만 실행됨
      ```
      public event MyEventHandler OnEventTriggered; // 이벤트 선언
      ```
      3. 이벤트 구독 (이벤트 핸들러 연결) : 이벤트가 발생되었을때 실행될 함수를 += 혹은 -=연산자로 연결하거나 제거함
      ```
      OnEventTriggered += EventFunction; // 이벤트 핸들러 연결 (구독)
      ```
      4. 이벤트 발생 : 조건을 넣고 충족되었을때 이벤트 실행 null을 체크한 후 호출하면 오류가 안나는 팁 
      ```
        if (OnEventTriggered != null) 
        {
            OnEventTriggered(); // 이벤트 발생
        }

 
      ```
## C# 이벤트 구현 순서
| 단계  | 설명                                  | 코드 예시                                   |
|------|-------------------------------------|-------------------------------------------|
| 1️⃣ 델리게이트 선언 | 이벤트에 사용할 함수 타입 정의 | `public delegate void MyEventHandler();` |
| 2️⃣ 이벤트 선언 | 이벤트 생성 (델리게이트 기반) | `public event MyEventHandler OnEventTriggered;` |
| 3️⃣ 이벤트 핸들러 연결 | 이벤트가 발생할 때 실행


---
#### 이벤트 예제
> 플레이어가 3번 공격하면 OnAttack 이벤트가 발생
```    
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 1️⃣ 델리게이트 선언 (이벤트 핸들러)
    public delegate void AttackEventHandler();
    
    // 2️⃣ 이벤트 선언
    public event AttackEventHandler OnAttack;

    private int attackCount = 0;

    void Start()
    {
        // 3️⃣ 이벤트 핸들러(구독자) 등록
        OnAttack += AttackMessage;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바 누르면 공격
        {
            attackCount++;
            Debug.Log("플레이어가 공격했다! 현재 공격 횟수: " + attackCount);

            if (attackCount >= 3)
            {
                // 4️⃣ 이벤트 발생
                if (OnAttack != null)
                {
                    OnAttack(); 
                }
                attackCount = 0; // 카운트 초기화
            }
        }
    }

    void AttackMessage()
    {
        Debug.Log("💥 이벤트 발생! 공격을 3번 하면 특수 효과 발동!");
    }
}

```



# 과제 : class 다이아그램 만들어서 캡쳐해서 올리기
