using UnityEngine;
using UnityEngine.UI;

public class BasicCode : MonoBehaviour
{
    /* 
     #����Ƽ���� ���� Ŭ���� 

    ### MonoBehaviour
    ### �Ϲ�Ŭ���� 
    ### ScriptableObject�� ����Ǿ��ִ� Ŭ���� : Assets���� ���ο� ��ũ��Ʈ�� �������� ������ �� �ִ� Ŭ����
   
     ###void Start() ���� �����Ҷ� 1�� ����Ǵ� �ڵ带 �ۼ��ϴ� ��ġ, �ַ� ���� ���� ������ �����Ҷ� �ش���ġ���� �۾��� �����Ѵ�

    ### ����������(Access modifier) : ���α׷� ���ٿ� ���õ� ������ ������ �� �ִ� Ű����
    > public vs private ����Ƽ �ν����Ϳ��� Ȯ���� ���� Ȥ�� �Ұ���
    > [SerializeField]�Ӽ��� ���� �ʵ�(����)�� ��쿡�� �ν����Ϳ��� ������
    > [Serializable]�Ӽ��� ���� Ŭ������ ������ ����� ��� �ν����Ϳ��� �����ȴ�

    */
    public int number;
    private int count;
    [SerializeField] private bool able;

    public Text text;
    public GameObject cube;
    public SampleCode s;


    void Start()
    {
        cube = new GameObject(); //�����ʱ�ȭ
        s = GameObject.Find("GameObject (1)").GetComponent<SampleCode>();


        //�Լ����� : �Լ���(���ڰ�)
        //�Ű�����(parameter) �Լ� ����� ȣ���ϴ� �ʿ��� �޾��� �����Ϳ� ���� ǥ��
        //���ڰ�(Argment) �Լ� ȣ���� �� �־��ִ� ��

        Numfive();
        Debug.Log(number);

        SetNumber(10);
        Debug.Log(number);

        TextHello();
    }

  /*
  ### �޼ҵ� : Ŭ���� ���ο��� ��������� �Լ�
  > �Լ� : ��ɹ� ����ü(Ư�� �ϳ��� ����� �����ϱ� ����)
  * �Լ� ����� ���
    - ���������� ��ȯŸ�� �Լ���(�Ű�����){ ������ ��ɹ�; }
  * �Լ� ����
    - void������ �Լ� : ������ ��ɸ� �������      
    - void�̿��� �Լ� : ������ ������ �������� ���� ����ؼ� ����

  */

    public void Numfive() //void������ �Լ� : ������ ��ɸ� �������
    {
        number = 5;
    }
    public void SetNumber(int value) //�Ķ���Ϳ� ���޹޾� ���� ���ο��� �����Ѵ�
    {
        number = value;
    }
    public void TextHello()
    {
        text.text = "Hello";
    }

   
   

}
