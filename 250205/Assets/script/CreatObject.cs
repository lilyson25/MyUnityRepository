using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SocialPlatforms.Impl;

public class CreatObject : MonoBehaviour
{
    //1. �� Ŭ������ ������Ʈ�� �����ϴ� ����� ������ �ֽ��ϴ�
    //2. ���콺 ��ư�� ��������, ī�޶��� ��ũ�������� ���� 
    //   ��ü�� ������ ���Ѵ�
    //3. ��ü�� ���⿡ ���� �߻��ϴ� ����� ȣ���ؿ´�
 
    public GameObject prefab; //������Ʈ ������ ���
    GameObject scoreText; //����ǥ��: UI>TextMeshPro ���)
    public float power = 500f;
    public int score = 0;

    private void Start()
    {
        scoreText = GameObject.Find("score"); //���Ӿ����� score�� ã�Ƽ� ���
        scoreText.GetComponent<TextMeshProUGUI>().text = $"���� : 0";
    }

    //������ ������Ű�� 
    //value = ��ġ
    public void ScorePlus(int value)
    {
        score += value;
        SetScoreText();

    }

    //�� ������ ���� ���
    
    void SetScoreText()
    {
      scoreText.GetComponent<TextMeshProUGUI>().text = $"���� : {score}"; 

    }


    void Update()
    {
        //mouse 0�� ��ư�� ��������
        // ���콺��ư 0����/ 1������/ 2��
        // ~~down Ŭ���� 1��/ ~up ��ư�� �������� 1��/  : Ŭ���ϴ� ���� ����
        if (Input.GetMouseButtonDown(0))
        { 
            var thrown = Instantiate(prefab); //Instantiate()�� ����Ƽ���� ������Ʈ�� �������� ����(����)�ϴ� �Լ�
            // as GameObject�� instantiate�� ���� ����ϸ� ���ӿ�����Ʈ�μ� �����϶�� �ǹ�
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*  //ray
            //������ ������������ �߻��ϴ� ���������� ������ ������ �ִ�.
            
            //�Ϲ����� ray�� vector3 (ray2d�� vector2)
            // �����͸� ������ �ִ� ����ü, �������̳� Raycast�� �̿��� ������Ʈ �浹������� Ȱ��
            Vector3 orogin = new Vector3(0,0,0);
            Vector3 vect_dir = Vector3.forward;
            Ray newRay = new Ray(ray.origin, vect_dir);
        */

            var direction = ray.direction; //���⼳��
            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power); //normalized �����Ѽӵ� ����ȭ�� ������ ������ �����ϸ鼭 ���̸� 1�� ���ߴ� ��
        }
    }

}
