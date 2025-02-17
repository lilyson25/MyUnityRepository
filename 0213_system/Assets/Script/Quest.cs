using System;
using UnityEngine;

/*
## ����Ʈ �ý��� �����
> ���ӳ����� Ư����Ȳ���� ���缭 �����ϰ� �ϴ� ���� �Ǵ� �䱸 ���׵��� �ǹ��մϴ�
> ����� ���� ���⿡ �������� ��� SO�� �����ϸ� ���� 

* ����Ʈ�� ������ �� �ʿ��� �ּ����� �͵�
  - 1. ����Ʈ ��������
    - ex)�÷��̾��� ����/ Ư���������� ������ ���� ��/ �ٸ� Ư�� ����Ʈ�� ����������� ���డ��

  - 2. ����Ʈ�� �����ϴ� ���
    - ex)Ư�� NPC�� ��ȭ�� �����Ѵ�/ Ư���������� ȹ���Ѵ�(����10���� ����)/ 

  - 3. ����Ʈ�� ����
    - ex)��, ������..

## ����Ʈ ����
> �Ϲ�����Ʈ : Ŭ�����ϸ� ���̻� �� �� ����
> ���ϸ� ����Ʈ : ������ �������� ����Ʈ�� ���ŵ�
> ��Ŭ�� ����Ʈ : �ָ� �������� ����Ʈ�� ���ŵ�

 */


public enum QuestType //enum���� ����ϸ� ���� ��?
{
    normal,daily,weekly

}
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/quest")]
public class Quest : ScriptableObject 
{
   
    public QuestType ����Ʈ����;
    public Reward ����;
    public Requirement �䱸����;

    [Header("����Ʈ ����")]
    public string ����;
    public string ��ǥ;
    [TextArea] 
    public string ����;

    public bool ����;
    public bool �������;
}
//�䱸���ǿ� ���� ��ũ���ͺ� ������Ʈ ����
[CreateAssetMenu(fileName ="Requirement", menuName ="Quest/Requirment")]
public class Requirement : ScriptableObject
{
    public int ��ǥ����;
    public int �������������Ǽ�;
}

[Serializable]
[CreateAssetMenu(fileName = "Reward", menuName = "Quest/Reward")]
public class Reward : ScriptableObject
{
    public int money;
    public int exp;
}