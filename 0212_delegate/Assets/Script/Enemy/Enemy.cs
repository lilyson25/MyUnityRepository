using UnityEngine;

// �������̽��� "I"�� ���̴� ���� �Ϲ����� ��� ��Ģ
public interface IEnemy
{
    void Action();
}

// Goblin Ŭ������ IEnemy �������̽��� ���� (�������̵�)
public class Goblin : IEnemy
{
    public void Action() // �����ݷ�(;) ����
    {
        Debug.Log("����� �����Ѵ�");
    }
}

// Slime Ŭ������ IEnemy �������̽��� ����
public class Slime : IEnemy
{
    public void Action()
    {
        Debug.Log("�������� �����Ѵ�");
    }
}

// Wolf Ŭ������ IEnemy �������̽��� ����
public class Wolf : IEnemy
{
    public void Action()
    {
        Debug.Log("���밡 �����Ѵ�");
    }
}
