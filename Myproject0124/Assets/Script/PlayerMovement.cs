using System;
using JetBrains.Annotations;
using UnityEngine;
//플레이어의 이동(리지드바디)

//해당 기능을 통해 이 스크립트를 컴퍼넌트로 사용할 경우
//적어놓은 컴포넌트를 요구하게 된다.
//1.해당 컴포넌트가 없는 오브젝트에 연결할 경우에는 자동으로 연결을 진행한다.
//2. 이 스크립트가 연결된 상태라면 그오브젝트는 대상의 컴포넌트를 제거할 수 없습니다.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public int a = 10;

    public float speed = 2.0f; //소수점을 적을떄는 마지막 f사용
    //소수점 약 6자리까지 정확히 계산

    public double jump_force = 3.5; //double도 실수를 표현하는 자료형, f를 붙이지 않는다
    //소수점 약 15자리까지 정확하게 계싼

    public  bool isJump = false;

    private Rigidbody2D rigid; //선언만 한 상태

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<0000> Genedics?
        //해당 컴포넌트의 값을 얻어오는 기능
        //0000부분에는 컴포넌트의 형태를 작성
        //콤포넌트의 형태가 다르다면 오류가 발생 (0000값과 선언된 값)
        //해당 데이터가 존재하지 않을 경우라면 null(답이 없음)을 반환
       
    }

    // Update is called once per frame
    void Update()
    {
        //필수 코드들이 들어갈 수 있음
        Move();
        Jump();
    }
    private void Jump()
    {
        //사용자가 키보드 Space키를 입력한다면
        //if(조건)
        //{
        //조건이 만족할때, 실행할 명령문;
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {//!는 조건의 결과가 반대로 처리하는 기능  
            if (!isJump) //점프상태가 아닌경우
            {
                isJump = true;//점프상태로 변경합니다
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
                //type casting 타입캐스팅 
                //(타입 이름)변수를 통해 해당 변수를 설정한 타입으로 변경가능
                //단 캐스팅이 가능한 범위에서만 진행가능

                //주로 int-> float같은 경우는 가능
                //데이터 타입이 서로 호환되지 않는 경우라면 사용 불가
            }
            else
            {
                isJump = false;
            }
        }

    }
    private void Move()
    {
    float x = Input.GetAxisRaw("Horizontal");
    float y = Input.GetAxisRaw("Vertical");
    //GetAxisRaw("키이름")은 인풋 매니저의 키를 얻어오면서
    //클릭에 따라 -1,0,1의 수치로 값을 얻어옴
    //Horizontal 수평이동 a,d키나 키보드의 왼 오른쪽 키
    //Vertical 수직이동 w,s키나 키보드의 위, 아래 키
    //위 코드를 통해 움직일 방향을 계산합니다
    
        Vector3 velocity = new Vector3(x,y,0) * speed * Time.deltaTime;
        //속력=방향*속도
        
        transform.position += velocity; //transform.position=transform.postion+velocity를 줄여서 표현
    
    }

    private void OnTriggerEnter2D(Collider2D collision) //트리거 체크해서 셋팅만 해놓고 
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("골인!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //유니티에서 크기를 비교하는 연산자
        //a==b a는 b와 크기가 같다(값이같다)
        // a!=b a가 b와 크기가 다를 경우(값이 다르다)
        

        //충돌체의 게임 오브젝트의 레어이어가 7과 비교했을때 크기가 같다면
        if(collision.gameObject.layer==7) //==은 같다라는 의미
        {
            isJump=false;
        }
        Debug.Log("땅을 밟았습니다!)");
    }



}
