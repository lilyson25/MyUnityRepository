# 개인프로젝트 로드맵
> https://artsandculture.google.com/experiment/don-t-touch-the-art/EwElh6DBf5inTA
>
> http://youtube.com/post/UgkxrDosMlSBdz5fv_OjE-GuB1aIrF8CFvwY?si=C7nRH9GzPf_p6Hqg

> 예술 조각품을 망치지 않고 플레이어가 작품을 학습하도록 유도하는 미니게임

### 1. 아이디어 구체화 및 기획
- 게임의 목표 정의:
  - 사용자가 예술 작품(조각품)을 망치지 않고 안전하게 유지하고, 멈추면 학습하면서 점수를 얻는 식

- 게임 메커니즘 정의:
  - 미술관에 작품 안내 가이드처럼 작품에 손이 닿으면 게임 오버가 되는 방식
    
- 타겟 플랫폼: 웹
  
### 2. 디자인 및 아트워크
- 비주얼 스타일 결정:
  - 게임의 비주얼 스타일은 예술 작품을 직접 모델링하되, 실사화가 아닌 모던하고 유머러스한 비쥬얼로 컨셉을 잡는다
    
- UI/UX 디자인:
  - 게임의 UI(예: 점수판, 타이머, 게임 시작 버튼 등)와 UX(게임 흐름)를 설계???????? 
    
- 애니메이션 및 효과:
  - 작품에 손을 대면 시각적 효과로 작품이 빨개지면서? 부서지는 이펙트를 넣어 게임의 긴장감을 준다
    
### 3. 기술 설계 및 구현
- 게임 엔진 선택:
  - Unity엔진을 사용할 경우, 기본적인 2D 게임 요소부터 타이밍 및 충돌 처리 기능을 구현
    
- 게임 로직 구현:
  - 작품을 손대면 게임 오버/ 작품에 닿지않고 작품에 하트등의 반응을 하고 다음 작품으로 넘어가면 단계별로 '지식점수'가 쌓이는 시스템
    
- 타이머 및 점수 시스템:
  - 타이머를 구현하여 일정 시간 내에 과제를 수행하게 하거나, 타이머가 끝나면 게임이 종료
    
- 충돌 검사:
  - 작품과 사용자의 body(또는 마우스, 클릭 위치) 간의 충돌 검사 기능을 구현, body가 닿으면 게임 오버
    
### 4. 게임 인터페이스 및 세팅
- 게임 시작 및 종료 화면:
  - 게임을 시작하기 전 : 게임안내
  - 게임종료시 : 점수안내
    
- 게임 진행 화면:
  - 게임 중에 나타날 미술 작품, 점수판, 타이머

--------------------
---

# 3D 게임 시스템 구현 로드맵

## 1. 유니티 프로젝트 설정
- Unity 실행 후 새로운 **3D 프로젝트** 생성
- 프로젝트 폴더 구조 생성: 
  - `Assets`, `Scripts`, `Scenes` 폴더

## 2. 기본적인 3D 환경 설정
- **게임 맵 구성**:
  - **큐브**, **평면** 등으로 기본 맵 구성
  - **3D Terrain** 또는 **프리팹**을 사용하여 벽, 바닥, 장애물 배치
- **카메라 설정**:
  - **카메라** 추가 후 시점 설정 (Third-Person View 등)
  - 카메라가 **플레이어를 따라가게** 설정

## 3. 플레이어 이동 및 조작 시스템 구현
- **플레이어 모델**: 
  - **3D Capsule** 등을 사용하여 플레이어 모델 대체
- **플레이어 이동**:
  - `CharacterController` 또는 `Rigidbody`를 이용한 이동 시스템 구현
  - **WASD 키**나 **마우스**로 플레이어 제어

  예시 코드:
  ```csharp
  using UnityEngine;

  public class PlayerMovement : MonoBehaviour
  {
      public float speed = 5f;

      void Update()
      {
          float horizontal = Input.GetAxis("Horizontal");
          float vertical = Input.GetAxis("Vertical");

          Vector3 move = new Vector3(horizontal, 0f, vertical);
          transform.Translate(move * speed * Time.deltaTime);
      }
  }
  ```

## 4. 조각품(작품) 배치 및 충돌 시스템 설정
- **조각품 모델 배치**:
  - **3D 모델** 또는 **프리팹**으로 작품 배치
- **충돌 감지**:
  - `Collider` 추가 후, **작품**과 **플레이어** 간 충돌 검사

  예시 코드:
  ```csharp
  using UnityEngine;

  public class ArtworkCollision : MonoBehaviour
  {
      void OnCollisionEnter(Collision collision)
      {
          if (collision.gameObject.CompareTag("Player"))
          {
              // 게임 오버 처리
              Debug.Log("게임 오버: 작품에 손이 닿았습니다.");
          }
      }
  }
  ```

## 5. 게임 오버 및 점수 시스템
- **게임 오버 처리**:
  - 작품에 손이 닿을 경우 **게임 오버 화면** 표시
- **점수 시스템**:
  - 점수 **UI** 텍스트로 표시
  - 점수 업데이트 및 저장

  예시 코드:
  ```csharp
  using UnityEngine;
  using UnityEngine.UI;

  public class GameController : MonoBehaviour
  {
      public Text scoreText;
      private int score = 0;

      void Start()
      {
          UpdateScore();
      }

      public void IncreaseScore()
      {
          score++;
          UpdateScore();
      }

      void UpdateScore()
      {
          scoreText.text = "Score: " + score.ToString();
      }
  }
  ```

## 6. UI/UX 설계
- **게임 시작 화면**:
  - **시작 버튼** 구현
- **게임 진행 화면**:
  - **점수판**, **타이머**, **작품 이미지** 등 표시
- **게임 오버 화면**:
  - 게임 종료 후 **게임 오버 메시지**와 **점수** 표시

## 7. 애니메이션 및 시각적 효과 추가
- **충돌 효과**:
  - 작품에 손이 닿으면 **파괴 이펙트**나 **빨갛게 변하는 효과** 추가
- **애니메이션**:
  - 플레이어 이동 애니메이션 또는 **게임 오버 시 애니메이션** 추가

## 8. 게임 빌드 및 테스트
- **기능 테스트**:
  - **플레이어 이동**, **충돌 감지**, **점수 시스템** 점검
- **버그 수정 및 디버깅**:
  - 게임 기능 점검 후 버그 수정

---

이 로드맵을 따라 기본적인 3D 게임 시스템을 구현할 수 있습니다. **기능적인 부분**부터 차근차근 구현하고, 비주얼 요소는 나중에 추가하면 됩니다. 도움이 필요하면 언제든지 질문해 주세요!
