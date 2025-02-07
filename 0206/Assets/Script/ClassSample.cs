using UnityEngine;

class Unit
{

    //Ŭ�������� �ش� Ŭ������ ���� ��ü(object)�� ������ �ۼ�
    public string unit_name;

    public static void UnitAction() //��ü(object)�� ����, ����� �ۼ��� �� �ִ�(�޼ҵ�)
    {
        Debug.Log("������ ����");
    }
    public void Cry()
    {
        Debug.Log("������ ��");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit;//Unit �������� ���� unit��ü(object)

    
    void Start()
    {
        unit.unit_name = "MiniGun";
        //Ŭ����������.�ʵ带 ���� Ŭ������ ������ �ִ� �ʵ�(����)�� ����� �� �ִ�.
        unit.Cry();
        //�ν��Ͻ���.�޼ҵ�()�� ���� Ŭ������ ������ �մ� �޼ҵ�(�Լ�)�� ����� �� �ִ�.

        /************
         * 
         Ŭ���� ������� ���� ��Ī

         ��ü(object) : ���� ������, Ŭ������ ��ü(object)�� ����� ���� ���ø�
         ex)Animal cat; �����ص� ��ü
            Animal cat = new Animal();

         ���۷��� : ��ü�� �޸𸮻󿡼��� ��ġ�� ����Ű�� ��, Ŭ������ �迭, �������̽� � �ش�
         �ν��Ͻ� : ��ü�� ����Ʈ����� ��üȸ�� �� (new�� ���� �������) 
         ex)Animal cat = new Animal();
         
         Unit.UnitAction(); -> static�� ���� ������ �Լ��� ��ü�� �������� �ʰ� Ŭ�������� �ٷ� �� ����� ������ ���
         
        ***********/
    }


}
