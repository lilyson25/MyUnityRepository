# 0220 플랫포머 게임

### FixedUpdate 
> 주로 물리계산을 다루는 코드에 대한 실행할때 사용, 일정시간 간격에 맞춰 호출됨 

> 기본적으로 초당 50회 호출정도로 잡혀있어 안정적으로 시뮬레이션을 유지하는 것이 가능

> Fixed Timestep 이라는 속성으로 값을 조절할 수 있다

### 2D기본설정 
> Rigidbody2D> constrains> Freeze Rotation> Z체크

> Assets> creat> 2d> Physics Material 2D 마찰력과 튕김정도 조절

> Animation> Samples 는 보통 애니메이션할 컷 수랑 비슷하게 조절

# 씬 추가 
> build Profiles> scene list> open scenes로 추가하는 씬 만들고 추가> 순서 바꾸기

### 타이틀 
> Render mode> main camera로 연결

> UI> image> 넣을 이미지를 소스이미지에 연결> 

### 컴포넌트창에서 onclickevent를 연결할때는 항상 오브젝트에 연결된 스크립트를 드래그해서 넣는다
