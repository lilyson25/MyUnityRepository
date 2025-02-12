# to the 베이직 

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
반환타입 함수이름(매개변수 타입 매개변수이름)
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
```
