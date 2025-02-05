using System.Runtime.Serialization;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class ObjectShooter : MonoBehaviour
{
    //�߻����� �������ִ� Ŭ����
    //�浹 �� ������Ʈ�� ���������ִ� ���ҵ� ����
    
    GameObject creatObject;
    void Start()
    {
        creatObject = GameObject.Find("CreatObject");
        //������Ʈ Ž�����
        // ������ �ش社�̸��� ���� ���ӿ�����Ʈ�� ã�� �� ���� ������ GameObject.Find()���
        // creatObject = GameObject.FindWithTag("GG"); //GG�±׸� ���� ������Ʈ Ž��
        // obg = FindObjectofType<CreatObject>(); <>�ȿ� �־��� Ÿ�Կ� �´� ������Ʈ�� Ž��/ ���� ���� CreatObject obj; ��� �����������

        //���� ���� �� Find()
        //�˻� ������ �ʹ� �ľ����� ���ʿ��ϰ� �������ϰ� �߻��� �� ����
        //���� �׋����� Tag  Type������ �˻������� �����ؼ� ã�� ����� ���

        //.���� �ش簪�� ������ null

    }
    //�߻��� �Լ�
    /// <summary>
    /// ��ü�� �߻��ϴ� ����� �����Լ�(�޼ҵ�)
    /// </summary>
   // ��ü�� �߻����
    //

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce (direction,ForceMode.Impulse);
        Debug.Log("�¾Ҵ�");

    }


    //�浹�� ���߱�kinematic
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if (collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else// �����ϰ��
        {
            creatObject.GetComponent<CreatObject>().ScorePlus(10);
                      
        }
    }
}
