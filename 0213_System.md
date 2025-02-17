# 유니티 시스템

## Scriptable Object  
> 클래스 인스턴스와는 별도로 대량의 데이터를 저장하는 데 사용할 수 있는 데이터 컨테이너(데이터 저장 객체)      
> https://docs.unity3d.com/kr/2022.3/Manual/class-ScriptableObject.html

* 장점
  - 동일한 적(오브젝트)의 정보등을 여러 오브젝트에서 공유해도 메모리는 한번만 차지함    
  - 데이터와 로직을 분리해서 사용가능 ex)캐릭터의 능력치 등을 SO로 관리할 경우에 스탯에 대한 수정을 쉽게 할 수 있다   
  - 런타임 중에 데이터의 수정이 가능하다   
* 단점
  - 복잡한 데이터 구조등에서는 직렬화[Serializable]가 되지않는 경우가 있어 데이터 손실 발생위험이 있다
  - 멀티 쓰레드 환경에서는 데이터 처리 시 충돌문제가 우려(DB활용이 낫다)
    
* 사용하기 좋은 예
 - 게임에 대한 기본 설정 값 (난이도 설정, 사운드 설정, 컨트롤 설정)
 - 행동 패턴이나 능력치 등에 대한 설정
 - 별도의 데이터베이스를 따로 구현하지 않는다는 전제로 아이템 데이터베이스를 만들기 좋다

* Scriptable Object만드는 방법
  - 스크립트로 빈오브젝트에 연결은 불가능하다   
  - 스크립트오브젝트를 선언해주면, 우클릭> 선언한명칭으로 선택해서 오브젝트를 생성할 수 있다
```
using UnityEngine;

[CreateAssetMent]
public Class 클래스명 : ScriptableObject
{
필드
메소드
프로퍼티
}
```
- 게임 오브젝트에 직접적으로 연결할 수 없는대신, Create를 통해 만든 클래스명으로 등록이 되는 것을 볼 수 있다
![image](https://github.com/user-attachments/assets/842ff2dd-710d-450f-9363-b96157cd730f)
![image](https://github.com/user-attachments/assets/0fbaa6ab-f399-44bc-b5c4-fd0109d2fcbe)
---
### CreateAssetMenu
* (  )에 filename, menuname, order를 설정할 수 잇음
* filename : 생성되는 에셋의 이름
* menuname : create를 통해 만들어지는 메뉴의 이름을 설정, /를 넣을 경우 경로가 추가됨
* order : 메뉴중에서 몇번째 위치에 존재할 지 표시할때 설정하는 값, 값이 클수록 마지막에 표기
```
using UnityEngine;

//CreateAssetMenu(생성되는 에셋의 이름, create를 통해 만들어지는 메뉴의 이름, 메뉴중에 몇번째 위치에 존재할 지 표시하는데 값이 클수록 마지막에 표기됨)
[CreateAssetMenu(fileName = "파일명", menuName = "경로/메뉴", order = 숫자)
public class 클래스명 : ScriptableObject
{
}
```
---
### using System을 사용하면서 유니티의 랜덤을 사용하고 싶은경우
> using Random = UnityEngine.Random;
---
## 자료구조 Datastructure (데이터 값의 모임)
> 유니티에서 특정  데이터 또는 기능을 구현하기 귀해 적압한 자료형을 고르는 건 필수
> 기본 자료형 이외에 ㅡㄱ정기능, 작업을 진행할 수 있는 데이터 집합체를 자료구조라 부른다.

* 자주 활용되는 자료구조
  - List : 순서대로 저장할 수 있고, 저장데이터를 추가 삭제 검색할 수있는 변경이 가능한 배열 
  - Dictionary : 키 - 값으로 묶어 저장할 수 있는 형태(json 파일에서도 확인가능)
  - Queue : 자료를 선입선출(FIFO)로 관리할 때 사용할 자료구조
  - stack : 자료를 후입선출(LIFO)로 관리할 때 사용할 자료구조
  - HashSet : 데이터의 중복을 전혀 허락하지 않는 경우, 정렬 순서가 필요없는 경우
 
### Queue
> C# 자료구조 컬렉션 중 하나이며, 선입선출(First in First Out) 구조를 구현할 때 효과적입니다.
  - 제공해주는 기능 : 삽입, 삭제, 첫번째 값 조회가능
  - 단점 : 중간에 있는 데이터를 접근하는 부분에선 매우 비효율적임
    
|   이름|                               내용|  형태|
|큐 생성|접근제한자 Queue 큐 이름 = new Queue();|  -|
|큐에 데이터 추가|큐 이름.Enqueue(값)|-|
|첫번째 데이터 조회|큐 이름.Peek|return|
|큐 데이터 제거|큐 이름.Dequeue()|return|


  - [적용하기 좋은 시스템 만드는 방법]
    - 대화시스템
      - 대화에 대한 데이터의 묶음을 따로 가지고 있다(클래스 or 스크립터블 오브젝트)
      - 큐에 해당 데이터들을 순서대로 Enqueue한다
      - 버튼이나 키를 누른다음 대화로 이동하는 기능을 추가 : 전달받은 Queue를 Dequeue한다
      - 화면상에 UI>Text에 전달받은 받은 값을 적용하면 대화기능처럼 보임
      - add) Text가 텍스트처럼 타이핑되는 효과(코루틴설계)와 함께 한다면 보기 좋음
      
  - 타이핑 텍스트 만드는 방법
    - 문장 길이만큼 반복해서 ui 텍스트에 단어 하나하나를 +=로 추가한다. 1초나 0.1초마다 한번씩 딜레이를 부여한다(코루틴)
 
```
public class DataStructure : MonoBehaviour
{
    //string 형태의 값만 저장할 수 있는 큐
   public Queue<string> stringQueue = new Queue<string>() ;

    private void Start()
    {
        //1. Queue에 데이터 추가
        stringQueue.Enqueue("uno");
        stringQueue.Enqueue("dos");
        stringQueue.Enqueue("tres");
        stringQueue.Enqueue("quatro");
        stringQueue.Enqueue("cinco");

        //2. 첫번째 데이터 조회
        foreach(string dialog in stringQueue) //stringQueue에서 대화를 하나하나 가져오겟다
        {
            Debug.Log(stringQueue.Peek()); //queue에 저장된 맨 앞의 값을 return

        }
        //3. Queue에 데이터 삭제
      
        Debug.Log(stringQueue.Dequeue()); //queue에 저장된 맨 앞의 값을 return, 추가적으로 맨앞의 값을 제거 
```
---
## 퀘스트 시스템 만들기
> 게임내에서 특정상황에서 맞춰서 시작하게 하는 조건 또는 요구 사항등을 의미합니다
> 변경될 일이 없기에 데이터의 경우 SO로 저장하면 편리함 

## 퀘스트 유형
> 일반퀘스트 : 클리어하면 더이상 깰 수 없다
> 데일리 퀘스트 : 매일을 기준으로 퀘스트가 갱신됨
> 위클리 퀘스트 : 주를 기준으로 퀘스트가 갱신됨
---
# 과제 (버튼으로 제어해서 inputtext가 진행되는 scriptable~로 작성된 과제 + 큐를 이용해서 만들기 괜찮은 시스템 
```
큐를 이용해서 만들기 괜찮은 시스템

조건 Assets/Scripts/Dialog 폴더 위치에서 작업할 것

1. 대화 시스템
IEnumerator, StartCoroutine, Queue, List 등을 활용해
구현할 수 있습니다.

만드는 방법
대화에 대한 데이터의 묶음을 따로 가지고 있습니다.
(클래스 or 스크립터블 오브젝트)

대화를 시작할 경우
큐에 해당 데이터들을 순서대로 Enqueue 합니다.

버튼이나 키를 눌러 다음 대화로 이동하는 기능을 추가합니다.
>> 전달받은 큐를 Dequeue합니다.

화면 상에 UI의 텍스트에 전달받은 값을 적용한다면
대화 기능처럼 보이게 될 것입니다.

추가적으로 텍스트가 타이핑되는 효과(코루틴 설계)와 함께한다면
더 실감나는 기능을 구현해볼 수 있습니다.


타이핑 텍스트?
화면상에서 텍스트를 타이핑하듯이 출력하는 것을 의미합니다.

만드는 방법
문장 길이만큼 반복해서 ui 텍스트에 단어 하나하나를 +=로 추가합니다.
1초나 0.1초 마다 한번씩 딜레이를 부여합니다.(코루틴)
```
```
퀘스트 시스템 만들기

퀘스트란?
게임 내에서 특정 상황에 맞춰서 시작하게 하는
조건 또는 요구 사항 등을 의미합니다.

퀘스트를 구현할 때 필요한 최소한의 것들

1.  퀘스트 진행 조건
  ex) 플레이어의 레벨
       특정 아이템을 가지고 있을 것
       다른 특정 퀘스트를 진행했을 경우 진행 가능

2.  퀘스트를 진행하는 방식
    ex) 특정 NPC와 대화를 진행한다.
        특정 아이템을 획득한다.(ex) 보석 10개를 수집합니다.)

3. 퀘스트의 보상
    ex) 돈, 아이템...
```
