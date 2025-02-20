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

### -중요- 컴포넌트창에서 onclickevent를 연결할때는 항상 오브젝트에 연결된 스크립트를 드래그해서 넣는다
### -중요- tag연결코드와 맞게 tag설정 

> 프리팹> canvas안에 두 스크립트를 넣고 설정할 수 있다.
https://media.discordapp.net/attachments/1329684212747599924/1342031410546081802/image.png?ex=67b827a6&is=67b6d626&hm=10b601d093faaaad76485f31f3fd2e9dd792ef2784df19682eb68fc53e3108cd&=&format=webp&quality=lossless

-----
### 추가작업정리
```
[아이템]
파란 아이템을 먹으면 얼음이 된다
빨간 아이템을 먹으면 속도가 빨라진다

[허들]
needle은 아래,위에서 움직인다
cannon은 shell을 계속 발사하는 애니메이션을 통해 shell을 만난 player는 사망하고 게임오버

[lever]
끊어진 길에서 lever를 만나면 lever의 sprite가 on으로 바뀌고 고정키를 이용해서 디딤돌을 움직여 발판을 만든다

[scoreborad]
Scoreboard에 아이템수치를 보여준다 (scoremanager가 필요???)
```
 
