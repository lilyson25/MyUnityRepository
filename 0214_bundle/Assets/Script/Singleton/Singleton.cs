using UnityEngine;

/*
 
## ����Ƽ�� �����������ڵ� : Singleton
> ���������� ���Ǵ� �����͸� �ϳ��� ��ü(�ν��Ͻ�)�� ��������
> �̱��� ������ ������ ������ ������ �ʿ���� �ٷ� ����� �� �ִ�
> ���, �̱��� �������� ������ �ν��Ͻ��� �ʹ� ���� �����͸� �����ϴ� ���, ������ ��ư� �׽�Ʈ�� ��ٷӴ�

*/
public class Tester : MonoBehaviour
{
    int point = 0;
    private void Start()
    {
       point = Singleton.Instance.point; //�̱��濡 �ִ� ������Ƽ
       Singleton.Instance.PointPlus(); //�Ǵ� �޼ҵ带 ���� Ŭ���� ������ ��ü�� �����ؼ� ��ü�� ������ �մ� ������ ��� �� �� �ִ�        
    }
}



public class Singleton : MonoBehaviour
{
    // 1. �ν��Ͻ��̸鼭 �������� ���� �� �� �ְ� ����
    private static Singleton _instance;

    //2. Ŭ���� ���ο� ǥ���� ���� ����
    public int point = 0;
    public void PointPlus()
    {
        point++;
    }

    public void ViewPoint()
    {
        Debug.Log("���� ����Ʈ : " + point);
    }


    public Singleton GetInstance()//1-1 : �޼ҵ带 ���ؼ� ����
    {
        if (_instance == null)//���簪�� ����ִٸ�
            _instance = new Singleton(); //���Ӱ� �Ҵ�
        return _instance; //�Ϲ����� ����� ������ �ν��Ͻ��� return�Ѵ�
    }

    //1-2: ������Ƽ�� �����ϴ� �͵� ����
    public static Singleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new Singleton();
            return _instance;
        }
    }

}
