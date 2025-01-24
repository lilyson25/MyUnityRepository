using System;
using JetBrains.Annotations;
using UnityEngine;
//�÷��̾��� �̵�(������ٵ�)

//�ش� ����� ���� �� ��ũ��Ʈ�� ���۳�Ʈ�� ����� ���
//������� ������Ʈ�� �䱸�ϰ� �ȴ�.
//1.�ش� ������Ʈ�� ���� ������Ʈ�� ������ ��쿡�� �ڵ����� ������ �����Ѵ�.
//2. �� ��ũ��Ʈ�� ����� ���¶�� �׿�����Ʈ�� ����� ������Ʈ�� ������ �� �����ϴ�.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public int a = 10;

    public float speed = 2.0f; //�Ҽ����� �������� ������ f���
    //�Ҽ��� �� 6�ڸ����� ��Ȯ�� ���

    public double jump_force = 3.5; //double�� �Ǽ��� ǥ���ϴ� �ڷ���, f�� ������ �ʴ´�
    //�Ҽ��� �� 15�ڸ����� ��Ȯ�ϰ� ���

    public  bool isJump = false;

    private Rigidbody2D rigid; //���� �� ����

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()  
    {
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<0000> Genedics?
        //�ش� ������Ʈ�� ���� ������ ���
        //0000�κп��� ������Ʈ�� ���¸� �ۼ�
        //������Ʈ�� ���°� �ٸ��ٸ� ������ �߻� (0000���� ����� ��)
        //�ش� �����Ͱ� �������� ���� ����� null(���� ����)�� ��ȯ
       
    }

    // Update is called once per frame
    void Update()
    {
        //�ʼ� �ڵ���� �� �� ����
        Move();
        Jump();
    }
    private void Jump()
    {
        //����ڰ� Ű���� SpaceŰ�� �Է��Ѵٸ�
        //if(����)
        //{
        //������ �����Ҷ�, ������ ��ɹ�;
        //}
        if (Input.GetKeyDown(KeyCode.Space))
        {//!�� ������ ����� �ݴ�� ó���ϴ� ���  
            if (!isJump) //�������°� �ƴѰ��
            {
                isJump = true;//�������·� �����մϴ�
                rigid.AddForce(Vector3.up * (float)jump_force, ForceMode2D.Impulse);
                //type casting Ÿ��ĳ���� 
                //(Ÿ�� �̸�)������ ���� �ش� ������ ������ Ÿ������ ���氡��
                //�� ĳ������ ������ ���������� ���డ��

                //�ַ� int-> float���� ���� ����
                //������ Ÿ���� ���� ȣȯ���� �ʴ� ����� ��� �Ұ�
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
    //GetAxisRaw("Ű�̸�")�� ��ǲ �Ŵ����� Ű�� �����鼭
    //Ŭ���� ���� -1,0,1�� ��ġ�� ���� ����
    //Horizontal �����̵� a,dŰ�� Ű������ �� ������ Ű
    //Vertical �����̵� w,sŰ�� Ű������ ��, �Ʒ� Ű
    //�� �ڵ带 ���� ������ ������ ����մϴ�
    
        Vector3 velocity = new Vector3(x,y,0) * speed * Time.deltaTime;
        //�ӷ�=����*�ӵ�
        
        transform.position += velocity; //transform.position=transform.postion+velocity�� �ٿ��� ǥ��
    
    }

    private void OnTriggerEnter2D(Collider2D collision) //Ʈ���� üũ�ؼ� ���ø� �س��� 
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("����!");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����Ƽ���� ũ�⸦ ���ϴ� ������
        //a==b a�� b�� ũ�Ⱑ ����(���̰���)
        // a!=b a�� b�� ũ�Ⱑ �ٸ� ���(���� �ٸ���)
        

        //�浹ü�� ���� ������Ʈ�� �����̾ 7�� �������� ũ�Ⱑ ���ٸ�
        if(collision.gameObject.layer==7) //==�� ���ٶ�� �ǹ�
        {
            isJump=false;
        }
        Debug.Log("���� ��ҽ��ϴ�!)");
    }



}
