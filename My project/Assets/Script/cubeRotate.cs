using UnityEngine;
/// <summary>
/// cube rotate class
/// </summary>
public class cubeRotate : MonoBehaviour
{
    #region �ʱ⳻��
    //�ڷ���(type)>> ���α׷��� �����͸� �Ǵ��ϴ� ����
    //   int : ����integer(�Ҽ��� ���� ����, 0�� ������)
    // float : �Ǽ� (�Ҽ��������Ե� ����)
    //  bool : ��(boolean) - true, false
    //string : ������ ����(����)
    
    //����variable>> Ư���� �ϳ��� �����ϱ����� �̸��� ���� ���� ����
    //���� : �ڷ��� ������;

    //������ �� ����(�ʱ�ȭ)>> ������ ���� �����Ű�� �۾�
    //������ = ��;


    #endregion

    #region ����
    public float x; //����Ƽ �����Ϳ��� �����Ǵ� ����
    private int sample; //����Ƽ �����Ϳ��� ������ �ȵǴ� ����
    public float y;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region �Լ�
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x*Time.deltaTime, y*Time.deltaTime, 0));
        //FPS(frame per second �ʴ�������)
        //deltaframe �� �������� �Ϸ�Ǳ���� �ɸ��� �ð�
    }
    #endregion
} 
