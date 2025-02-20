# 플랫포머 게임
> 1 .모든 씬에 사용될 해상도를 잡는다
> 2. 에셋으로 사용할 이미지의 sprite mode를 single로 바꿔준다(추가 작업을 위한 초기화 의미..)
> > 2-1. 애니메이션에 사용할 이미지들은 그룹별로 pivot값을 동일하게 설정해준다. ex)player:bottom
> 3. 에셋을 씬에 배치하고 설정이 마무리되면, 다른씬에 사용할 수 있게 프리팹으로 등록한다
> 4. Canvas안에 그룹으로 관리하고 싶을때는 panel을 이용해 투명도를 0으로 빼고 그룹핑한다
> 5.  
---
### 2D기본설정 
> Rigidbody2D> constrains> Freeze Rotation> Z체크

> Assets> create> 2d> Physics Material 2D 마찰력과 튕김정도 조절

> Animation> Samples 값 설정은 애니메이션할 컷 수랑 비슷하게 조절하는 것이 보통
> 
### PlayerController.cs
> 우선 [RequireComponent(typeof(Rigidbody2D))]부터 설정한다

> start()에서 getcomponenet를 불러오고, 현재 상태를 playing으로 설정

> update()에서 현재상태, plater의 이동로직, 점프값 설정
```
//플레이어의 방향을 바꾸기
//보통 : GetAxisRaw수평이동 한칸씩 이동 vs 세세한 수치로 이동을 설정할때 GetAxis
 axisH = Input.GetAxisRaw("Horizontal"); 
if (axisH > 0) // 오른쪽 이동하면 localScale.x = 1
     transform.localScale = new Vector2(1, 1);
 else if (axisH < 0) // 왼쪽 이동 localScale.x = -1
     transform.localScale = new Vector2(-1, 1);
```
> FixedUpdate() : 점프에대한 로직

> Physics2D.Linecast(): start에서 end까지 가상의 선을 그어 충돌 여부를 검사하는 함수
```
//Physics2D.Linecast(start, end, layerMask) 문법
onGround = Physics2D.Linecast(
    transform.position,                      // 시작점 (플레이어의 현재 위치)
    transform.position - (transform.up * 0.1f), // 끝점 (플레이어 위치 아래쪽으로 0.1 유닛 이동)
    groundLayer                              // 충돌을 감지할 레이어 (Ground)
);
 if (onGround || axisH != 0) //지면 위에 있는 상태에서 점프키가 눌린 상황 -> || 또는 
 {
     rbody.linearVelocity = new Vector2(speed * axisH, rbody.linearVelocityY);
 }
 if (onGround && goJump)
 {
     Vector2 jumpPw = new Vector2(0, jump); //플레이어가 가진 점프수치만큼 벡터 설계
     rbody.AddForce(jumpPw, ForceMode2D.Impulse); //해당 위치로 힘을 가한다
     goJump = false;
 }

 if (onGround)
 {
     if (axisH == 0)
     {
         current = Enum.GetName(typeof(ANIME_STATE), 0);
         //Enum.GetName(typeof(enum명, 값);
         //해당 enum에 있는 그 값의 이름을 얻어오는 기능
     }
     else
     {
         current = Enum.GetName(typeof(ANIME_STATE), 3);
     }
 }
 else// 공중인 경우
 {
     current = Enum.GetName(typeof(ANIME_STATE), 4);
 }
 //현재의 모션이 이전의 모션과 다른경우(애니메이션이 바뀐경우)
 if (current != previous)
 {
     previous = current;//이전 동작에 대한 세이브
     animator.Play(current);//현재의 모션 플레이
 }
```
>  OnTriggerEnter2D(Collider2D collision)/ GameOver()/ GameStop()/ Goal() 
 
### 씬 연결: changeScene.cs
> 씬 추가 : build Profiles> scene list> open scenes로 추가하는 씬 만들고 추가> 작동될 순서로 바꾸기
```
public string sceneName;
public void Load()
{
    SceneManager.LoadScene(sceneName);
}
```

### CameraManager.cs
> Render mode> main camera로 연결

> UI> image> 넣을 이미지를 소스이미지에 연결> 

### -중요- 컴포넌트창에서 onclickevent를 연결할때는 항상 오브젝트에 연결된 스크립트를 드래그해서 넣는다
### -중요- tag연결코드와 맞게 tag설정 

> 프리팹> canvas안에 두 스크립트를 넣고 설정할 수 있다.
https://media.discordapp.net/attachments/1329684212747599924/1342031410546081802/image.png?ex=67b827a6&is=67b6d626&hm=10b601d093faaaad76485f31f3fd2e9dd792ef2784df19682eb68fc53e3108cd&=&format=webp&quality=lossless
> 
### FixedUpdate 
> 주로 물리계산을 다루는 코드에 대한 실행할때 사용, 일정시간 간격에 맞춰 호출됨 

> 기본적으로 초당 50회 호출정도로 잡혀있어 안정적으로 시뮬레이션을 유지하는 것이 가능

> Fixed Timestep 이라는 속성으로 값을 조절할 수 있다
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
 
