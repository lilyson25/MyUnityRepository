# 0226 ShootingGame
> 프로토 타입을 설계한다

> 셋팅 순서
  * 1. GameView> 해상도 설정 2.Othgraphic mode 3.Light비활성화 4. Window> Rendering> Lighting> Colormode로 전환해서 255로 색상변경
  * Ambient(환경광) color 빛이 없어도 물체의 색을 그대로 표현 (2D에서만 사용됨)
> 플레이어 구현

> 총알 발사 기능 구현
- Bullet객체생성
- 프리팹등록
- 스크립트 연결

> Enemy 구현
- (아래로 계속 이동, 실제 충돌이 발생한다면 서로 파괴 destroy)
- 충돌이 발생한다면, Rigidbody 컴포넌트를 연결할 필요가 생김
- 리지드바디 컴포넌트 연결
- 프리팹등록
- 스크립트 연결

> 스포너구현
-
> 영역 존 구현
- 영역 오브젝트 배치
  
> rigidbody에서 isKinematic체크하면 충돌만 감지하라고 
