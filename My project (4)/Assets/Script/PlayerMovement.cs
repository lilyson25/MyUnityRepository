using System;
using UnityEngine;
//�÷��̾��� �̵�(������ٵ�)

//�ش� ����� ���� �� ��ũ��Ʈ�� ���۳�Ʈ�� ����� ���
//������� ������Ʈ�� �䱸�ϰ� �ȴ�.
//1.�ش� ������Ʈ�� ���� ������Ʈ�� ������ ��쿡�� �ڵ����� ������ �����Ѵ�.
//2. �� ��ũ��Ʈ�� ����� ���¶�� �׿�����Ʈ�� ����� ������Ʈ�� ������ �� �����ϴ�.
//[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Rigidbody2D))]


//public class PlayerMovement : MonoBehaviour
public class PlayerMovement : MonoBehaviour
{
    //public float speed = 5.0f; //�Ҽ����� ���� ���� �������� f ��ȣ�� ����մϴ�. �Ҽ��� �� 6�ڸ����� ��Ȯ�ϰ� ���
    public float speed = 10.0f;

    //public float jump_force = 3.5f; //double�� �Ǽ��� ǥ���ϴ� �ڷ����̸� �� ��쿡�� f�� ������ �ʽ��ϴ�. �Ҽ��� �� 15�ڸ����� ��Ȯ�ϰ� ���
    public float jump_force = 3.5f;

    //    public bool isJump = false;
    public bool isJump = false;

    // private Rigidbody2D rigid;
    private Rigidbody2D rigid;
    void Start()
    {
        //rigid = GetComponent<Rigidbody2D>();
        rigid = GetComponent<Rigidbody2D>();
        //GetComponent<T>
        //�ش� ������Ʈ�� ������ ������ ���
        //<T> �κп��� ������Ʈ�� ���¸� �ۼ����ݴϴ�.
        //������Ʈ�� ���°� �ٸ��ٸ� ���� �߻� : ��) private Rigidbody2D rigid; > void Start() { rigid = GetComponent<Camera>(); <Rigidbody2D�� �־����>
        //�ش� �����Ͱ� �������� ���� ����� null(���� ����)�� ��ȯ�ϰ� �˴ϴ�.

    }

    void Update()
    {
        Move();
        Jump();
        //Update()�� �� �����Ӹ��� ȣ��Ǹ� move�� jump����(�Ű������� ���� �ʴ� �Լ�) �ٸ��Լ����� ȣ���Ѵ�
    }

    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw("Ű �̸�");�� ��ǲ�Ŵ����� Ű�� �����鼭
        //Ŭ���� ���� -1, 0 ,1�� ��ġ�� ���� ���ɴϴ�.
        //Horizontal : ���� �̵� (��, �� - A,D Ű������ ����, ������ ȭ��ǥ)
        //Vertical : ���� �̵� (��, �Ʒ� - W,S Ű������ ��,�Ʒ� ȭ��ǥ)

        //���� �ڵ带 ���� ������ ������ ����մϴ�.
        Vector3 velocity = new Vector3(x, y, 0) * speed * Time.deltaTime;
        //�ӷ� = ���� * �ӵ�;
        transform.position += velocity;
    }

    private void Jump()
    {
        //����ڰ� Ű���� Space Ű�� �Է��Ѵٸ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isJump)
            {
                //!�� ������ �ݴ�� ó���ϴ� ���
                //������ ����� true�� ��� false
                //������ ����� false�� ��� true
                isJump = true;//���� ���·� �����մϴ�.
                rigid.AddForce(Vector3.up * jump_force, ForceMode2D.Impulse);
                //type casting(Ÿ�� ĳ����)
                //(Ÿ�� �̸�) ������ ���� �ش� ������ ������ Ÿ������ ���氡�� -> double a = 3.5 / (float)a
                //�ַ� int -> flaot ���� ���� ����
                //������ Ÿ���� ���� ȣȯ���� �ʴ� ����� ��� �Ұ�

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("�������~��");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //����Ƽ���� ũ�⸦ ���ϴ� ������
        // a == b : a�� b�� ũ�Ⱑ �����ϴ�.(���� ����)
        // a != b : a�� b�� ũ�Ⱑ �ٸ��ϴ�.(���� �ٸ��ϴ�.)
        // > , < , >= , <=  �ʰ� �̸� �̻� ����
        //�浹ü�� ���� ������Ʈ�� ���̾ 7�� ������ �� ũ�Ⱑ ���ٸ�
        if (collision.gameObject.layer == 7)
        {
            isJump = false;
        }
        Debug.Log("���� ��ҽ��ϴ�!");
    }

}