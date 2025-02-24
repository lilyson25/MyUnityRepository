using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float speed = 3.0f;

    public static int hp = 3; //플레이어의 체력, 공유변수, 여러곳에서 접근가능
    public static string state;
    bool inDamage = false; //데미지를 받는 중인지 여부

    public List<string> anime_list = new List<string>//플레이어의 애니메이션 리스트(각방향 및 죽음 애니)
      { "PlayerDown", "PlayerUp", "PlayerLeft", "PlayerRight", "PlayerDead" };

    //현재 애니메이션 상태
    string current = "";
    string previous = "";

    float h, v; // 입력된 수평(h), 수직(v) 방향 값

    public float z = -90.0f;// 회전 각도 (기본 -90도로 설정)

    Rigidbody2D rbody;

    bool isMove = false; //움직이는 상태인지 확인

    Animator animator;



    void Start()
    {
        state = "playing"; //게임 시작시 상태를 playing으로 설정
        
        rbody = GetComponent<Rigidbody2D>();//Rigidbody2D 가져오기
        animator = GetComponent<Animator>();
        previous = anime_list[0]; //처음에는 아래방향 애니메이션 사용
    }


    void Update() //키입력으로 방향을 정하고 애니메이션을 결정
    {
        if (state != "playing" || inDamage) //게임이 진행중이 아니거나, 데미지를 받는 중이라면 조작 불가능
        {
            return;
        }
        if (isMove == false) //움직이지 않는 상태라면 키 입력을 받음
        {
            h = Input.GetAxisRaw("Horizontal"); //왼쪽-1 오른쪽 1
            v = Input.GetAxisRaw("Vertical"); // 아래 -1 위 1  

        }
        Vector2 from = transform.position; //현재 위치 가져옴
        Vector2 to = new Vector2(from.x + h, from.y + v); //이동할 목표 위치 계산
        z = GetAngle(from, to);

        if (z >= -45 && z < 45) //이동방향에 따른 애니메이션 설정
            current = anime_list[3]; //오른쪽
        else if (z >= 45 && z <= 135)
            current = anime_list[1]; //위
        else if (z >= -135 && z <= -45)
            current = anime_list[0]; //아래
        else
            current = anime_list[2]; //왼

        if (current != previous) //현재 애니메이션과 다르면 변경
        {
            previous = current;
            animator.Play(current); //애니메이션 재생
        }

    }

    private void FixedUpdate()
    {
        if (state != "playing" || inDamage)
            return;

        if (inDamage) //데미지를 받는 중일때 깜박거리는 효과 적용, 플레이어가 데미지를 받으면 빠르게 깜빡이면서 무적 시간을 표시하는 기능
        {
            float value = Mathf.Sin(Time.time * 50);
            //Mathf.Sin(x)은 사인 함수로, x 값이 변함에 따라 -1 ~1 사이의 값을 반복적으로 만듦.
            //Time.time은 **게임이 시작된 후의 시간(초)**이야.
            //Time.time * 50은 시간을 빠르게 변화시키는 역할을 해서, 사인 함수가 빠르게 오르락내리락하도록 만듦
            //Mathf.Sin(Time.time * 50)은 아주 짧은 간격으로 -1에서 1까지 변하는 값을 출력
            GetComponent<SpriteRenderer>().enabled = value > 0; // 0보다 크면 보이고, 아니면 안 보이게 함
            /*깜빡거리는 원리
            value > 0이면 true, 즉 SpriteRenderer.enabled = true; (보임)
            value <= 0이면 false, 즉 SpriteRenderer.enabled = false; (안 보임)
            이 과정이 50Hz(1초에 50번)로 반복되니까 깜빡이는 효과가 나옴.*/
            return;
        }
        rbody.linearVelocity = new Vector2(h, v) * speed;
    }
    //플레이어에게 물리적인 충돌이 발생할 경우
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetDamage(collision.gameObject);
        }
    }

    private void GetDamage(GameObject enemy)//적한테 부딪혔을 때, 적이 있는 방향의 반대쪽으로 밀려나는 효과를 추가
    {
        if (state == "playing")
        {
            hp--;// 플레이어가 적과 부딪히면 체력이 1 줄어듦.

            if (hp > 0)
            {
                rbody.linearVelocity = Vector2.zero;//이동정지

                Vector3 to = (transform.position - enemy.transform.position).normalized;
                //밀려나는 효과(넉백(Knockback))
                //적과의 위치 차이를 구해서, 밀려날 방향을 결정하는 역할
                //(플레이어의위치 - 적의위치)를 정규화해서 방향만 남긴다
                //적이 왼쪽에 있으면 → 플레이어를 오른쪽으로 밀어냄
                //적이 위쪽에 있으면 → 플레이어를 아래쪽으로 밀어냄
                //방향만 남기고 크기는 1로 고정!

                rbody.AddForce(new Vector2(to.x * 4, to.y * 4), ForceMode2D.Impulse);
                //AddForce()를 사용할 때, 짧고 강한 힘을 순간적으로 적용하는 옵션



                inDamage = true; // 데미지 상태 활성화

                Invoke("OnDamageExit", 0.25f);
                //무적 시간 설정 (0.25초 후 해제)
                // 0.25초(250ms) 후에 OnDamageExit() 함수가 실행됨.다시 공격을 받을 수 있는 상태가 됨.
                //Invoke() 함수는 일정 시간이 지나면 특정 함수를 실행하는 기능
                // 0.25초 동안 다시 공격을 받지 않도록 막아주는 거야!
            }
            else
                GameOver();// 체력이 0이 되면 게임 종료
        }
    }
    private void OnDamageExit()
    {
        inDamage = false;//데미지 안받는 상태로 전환
        GetComponent<SpriteRenderer>().enabled = true; //이미지 다시 키기
    }
    private void GameOver()
    {
        state = "gameover";
        GetComponent<CircleCollider2D>().enabled = false;
        rbody.linearVelocity = Vector2.zero;

        rbody.gravityScale = 1;
        rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
        GetComponent<Animator>().Play(anime_list[4]);
        Destroy(gameObject, 1.0f);
    }


    private float GetAngle(Vector2 from, Vector2 to) //두점사이의 방향을 구하는 과정
    {
        float angle;// 최종적으로 반환할 각도

        if (h != 0 || v != 0) //플레이어가 이동하고 있을때만 실행
        {
            float dx = to.x - from.x; //x축 밯양거리차이
            float dy = to.y - from.y; //y축 방향거리차이

            float radian = Mathf.Atan2(dy, dx); //라디안단위로 각도 계산
            angle = radian * Mathf.Rad2Deg;// 라디안을 도 단위로 변환
        }
        else
        {
            angle = z; //이동하지 않을때 기존각도 유지
        }
        return angle;

    }
}
