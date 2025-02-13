# Back to the basics

## 클래스 선언 기본구조 
> 클래스이름은 대문자로 시작하며 뒤에 아무것도 붙지않는다   
> 부모클래스는 유니티의 경우 일반적으로 MonoBehaviour(유니티에서 제공하는 클래스)을 상속받는다
```
public class 클래스 이름 : 부모클래스 
{
변수선언
함수선언
}
```
### 유니티에서 만들 클래스 
* 1. MonoBehaviour
* 2. 일반클래스 
* 3. ScriptableObject가 연결되어있는 클래스 : Assets폴더 내부에 스크립트를 에셋으로 저장할 수 있는 클래스

### 접근제한자(Access modifier) : 프로그램 접근에 관련된 설정을 진행할 수 있는 키워드
 > public vs private 유니티 인스펙터에서 확인이 가능 혹은 불가능
 > [SerializeField]속성이 붙은 필드(변수)의 경우에는 인스펙터에서 공개됨
 > [Serializable]속성이 붙은 클래스를 변수로 사용할 경우 인스펙터에서 공개된다

## 변수 선언
> 데이터를 저장할 공간을 의미, 타입과 이름을 명시해야 변수를 선언할 수 있음   
> 변수이름은 보통 camelCase형식으로 사용   
> 타입 : int, float, string, bool 등의 변수 데이터 유형   
```
타입 변수이름 = 초기값;
```
## 함수(메서드) 선언
> 클래스 내부에서 특정 동작을 수행하는 코드 블록, 반환값(return type)과 매개변수(parameters)를 받을 수 있다   
> 반환타입 : 함수가 반환하는 값의 타입, 값을 반환하지 않는 함수는 void를사용   
> 함수이름은 소문자로 시작   
> 매개변수는 함수가 받을 수 있는 입력값, 없을수도 있음    
```
반환타입 함수이름(매개변수타입 매개변수이름)
{
//함수내용
return 반환값;//반환값을 있을경우
}

```
```
void Start() //게임이 시작될 때 한 번 호출
{
Debug.Log("게임시작");
}
void Update()//매 프레임마다 호출
{
transform.Translate(Vector3.forward * Time.deltaTime);
}
```
## 클래스의 전체구조
> 클래스는 변수와 메서드를 포함한 객체의 설계도. 이를 통해 유니티 오브젝트가 어떤 상태와 행동을 가지는지 정의함
```
//player클래스
public class Player : MonoBehaviour
{
//변수선언
public int health = 100; //공개변수(inspector에서 보임)
private float speed = 5f; //비공개변수(inspector에서 보이지않음)

//함수선언
void Start()
{
Debug.Log("게임이 시작됨");
}
void Update()
{
float move = speed + Time.deltaTime; //매프레임마다 플레이어 이동
transform.Translate(Vector3.forward * move);
}
public void Die()
{
Debug.Log("플레이어가 죽음")
}
}
```
## Delegate & Event
> 특정 메서드를 다른 클래스에서 콜백형식으로 호출하는 방법
> delegate - 특정 메서드를 참조할 수 있는 타입을 정의, PlayerDeathHandler라는 delegate를 선언하며 메서드가 매개변수없이 반환값도 없는 형태로 정
```
public delegate void PlayerDeathHandler(); //delegate정의
public event PlayerDeathHandler PlayerDied; //event선언

//이벤트호출
if (PlayerDied != null)
{
PlayerDied.Invoke(); //이벤트가 발생했을 때, 그에 구독된 메서드를 호출하는 코드
}

//구독
PlayerDied += OnPlayerDeath;

//이벤트 발생 시 호출될 메서드
void OnPlayerDeath()
{
Debug.Log("플레이어 사망처리");
}

//구독 해제
PlayerDied -= OnPlayerDeath;
```
### 왜 사용하는 걸까?
> 특정조건(버튼클릭, 플레이어사망등)에 반응하는 메서드를 자동으로 호출할 수 있도록해줌
> delegat는 이벤트가 발생햇을때 호출할 메서드를 정확히 지정하는 역할을 함
> delegate는 메서드를 연결해주는 역할을 하며 event는 그 연결된 메서드를 실행하는 역할
> delegate특정 시점에 실행할 메서드를 동적으로 연결하기 위한 타입

- 델리게이트 정의) "체력 변화"라는 이벤트가 발생했을 때 실행할 메서드를 델리게이트로 연결
- **HealthChangedHandler**는 매개변수로 **int**를 받는 메서드를 참조할 수 있는 타입
```
// 델리게이트 정의: 매개변수로 체력을 받는 메서드를 참조할 수 있는 타입
public delegate void HealthChangedHandler(int currentHealth);
```
- 이벤트 정의) 이벤트는 특정 일이 발생했을 때 그에 대응하는 메서드를 자동으로 실행할수있게 함
```
public class Player
{
    // 이벤트 정의: 체력 변화가 있을 때 발생하는 이벤트
    public event HealthChangedHandler OnHealthChanged;

    private int health;
    
    public int Health
    {
        get { return health; }
        set
        {
            // 체력이 변할 때마다 이벤트 호출
            health = value;
            OnHealthChanged?.Invoke(health);  // 이벤트가 구독되어 있으면 호출
        }
    }
}

```
* 이 방식을 사용하면 플레이어의 체력처럼 다양한 상황에서 일어나는 변화를 다른 객체에 쉽게 전달할 수 있습니다. 구독과 해제를 통해 필요한 시점에만 메서드를 실행하도록 할 수 있죠
---
## AddListener
> 이벤트(Event)에 함수를 연결하는 기능, 특정 이벤트가 발생했을 때 실행할 함수를 등록하는 역할을 한다.
* 기본구조
  ```
  이벤트이름.AddListener(실행할함수);
  //예: onClick(버튼이 클릭될때), onValueChanged(UI 슬라이더, 토글등의 값이 변경될때 실행), OnEndEdit(입력필드의 입력이 끝났을때)
  ```
#### AddListener를 사용한 코드와 사용하지 않은 코드 비교
```
//AddListener를 사용한 코드

using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Button myButton; // UI 버튼

    void Start()
    {
        // 버튼 클릭 시 ClickAction 함수 실행
        myButton.onClick.AddListener(ClickAction);
    }

    void ClickAction()
    {
        Debug.Log("버튼이 클릭됨!");
    }
}
```
* ✅ AddListener(ClickAction)를 사용하여 버튼 클릭 이벤트를 등록
* ✅ 버튼을 클릭하면 ClickAction() 함수가 실행됨
* ✅ Debug.Log("버튼이 클릭됨!");이 출력됨
  
```
//AddListener를 사용하지 않은 코드(이벤트 등록X)
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Button myButton; // UI 버튼

    void Start()
    {
        // 아무것도 안 함 (이벤트 미등록)
    }

    void ClickAction()
    {
        Debug.Log("버튼이 클릭됨!");
    }
}
```
```
//AddListener 없이 직접 연결하는 방법
using UnityEngine;
using UnityEngine.UI;

public class Example : MonoBehaviour
{
    public Button myButton; // UI 버튼

    void Start()
    {
        // 버튼의 onClick 이벤트에 직접 함수 할당
        myButton.onClick = new Button.ButtonClickedEvent();
        myButton.onClick.AddListener(ClickAction);
    }

    void ClickAction()
    {
        Debug.Log("버튼이 클릭됨!");
    }
}
```
* 💡 myButton.onClick = new Button.ButtonClickedEvent();를 사용하면 기존 리스너를 모두 제거하고 새로 등록
* 💡 AddListener(ClickAction)을 사용하여 이벤트 등록
* 💡 기존 이벤트를 제거한 후 새로운 이벤트만 실행되도록 하고 싶을 때 사용
