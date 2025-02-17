using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DelegateSample : MonoBehaviour
{

    /*
     * delegate
     * �Լ��� ������ �� �ִ� ����. �븮�ڶ�� �θ���
     * �ش纯������ �Լ��� ���ԵǾ������Ƿ� �ش纯���� �����ϸ� ������ �Լ��� ����Ǵ� ���
     * 
     * delegate ���� ��� : ���������� delegate Ÿ�� ��������Ʈ(�Ű�����)
       - delegate void DelegateTest2(int a, int b);
       - delegate string DelegateText(float x);
       - delegate int DelegateInt(int x, int y);
     */
    delegate void DelegateTest(); 
   



    
    void Start()
    {
        //��������Ʈ ����ó�� ���
        //��������Ʈ ������ = new ��������Ʈ��(�Լ���);
        DelegateTest dt = new DelegateTest(Attack);

        //�Լ�ó�� ȣ��
        dt = Attack;
        dt();

        //���뺯��: ������ = �Լ���;
        dt();

        /*
         * delegate���� ���� ��ü�� �Ҵ��ϴ� ����?
           - 1. delegate�� �Լ��� �ƴ� Ÿ���̱� ����
              �Ű������ε� Ȱ���� ����, returnŸ������ ����ִ� �͵� ����
           
         * ��������Ʈ ü��
           - delegae�� +=�� ���� �븮�� �Լ��� �� �߰��� �� �հ� -=�� ���� �븮�� �Լ��� ���ŵ� ����
        ex1)
        void UseDelegate(DelegateTest dt)
        {
            dt();
        }
        ex2)
         DelegateTest Selection(int value)
        {
            if(value == 0) return Attack;
            else if (value == 1) return Guard; 
            else return MoveLeft;
        }

         */
        dt += Guard;
        dt += Guard;
        dt += Guard;
        dt();



    }
    void Attack() => Debug.Log("����");
    void Guard() => Debug.Log("���");
    void MoveLeft() => Debug.Log("�����̵�");

}
