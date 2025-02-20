using System;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    // --여기서부터 애니메이션 셋팅
    public enum ANIME_STATE
    {
        PlayerIDLE, PlayerClear, PlayerGameOver, PlayerRun, PlayerJump
        //애니메이션 이름으로 설정
    }

    Animator animator;
    public string current = ""; //현재 진행중인 애니메이션
    public string previous = ""; //기존 애니메이션
    // --여기까지 애니메이션 셋팅했으므로 

    Rigidbody2D rbody;
    float axisH = 0.0f;
    public float speed = 3.0f;

    public float jump = 7.0f;
    public LayerMask groundLayer;

    bool goJump = false;
    bool onGround = false;

    public static string state = "playing";//현재의 상태(플레이 중)

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        state = "playing";
    }

    // Update is called once per frame
    void Update()
    //이동에 대한 로직
    {
        if (state != "playing")
        {
            return; //이 리턴코드 : 종료한다
        }

        axisH = Input.GetAxisRaw("Horizontal"); 
        //보통 : GetAxisRaw수평이동 한칸씩 이동 vs 세세한 수치로 이동을 설정할때 GetAxis
        
        if (axisH > 0) // 오른쪽 이동
        {
            transform.localScale = new Vector2(1, 1);
        }
        else if (axisH < 0) // 왼쪽 이동
        {
            transform.localScale = new Vector2(-1, 1);
        }


        if (Input.GetButtonDown("Jump"))
        {
            Jump(); //셋팅된 값 'Jump'
        }


    }
    private void FixedUpdate() //점프에 대한 로직 (+플레이어의 현재 pivot은 bottom이라고 설정을 넣어줌)
    {
        if (state != "playing")
        {
            return; //이 리턴코드 : 종료한다
        }


        //Linecast문법
        onGround = Physics2D.Linecast(transform.position, transform.position - (transform.up * 0.1f), groundLayer);
        //지정한 두 점을 연결하는 가상의 선에 게임 오브젝트가 접촉하는지를 조사해 true또는 false로 return해주는 함수
        //updms vector기준 (0,1,0)

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
    }

    private void Jump()
    {
        goJump = true; //플래그 키는 작업
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            Goal();
        }
        else if (collision.gameObject.tag == "Dead")
        {

            GameOver();
        }
    }

    public void GameOver()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 2));
        state = "gameover";
        GameStop();
        GetComponent<CapsuleCollider2D>().enabled = false;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        //위로 살짝 뛰어오르는 연출
    }

    private void GameStop()
    {
        rbody.linearVelocity = new Vector2(0, 0); //속력을 0으로 만들어서 멈추게 만듦
    }

    private void Goal()
    {
        animator.Play(Enum.GetName(typeof(ANIME_STATE), 1));
        state = "gameclear";
        GameStop();
    }
}
