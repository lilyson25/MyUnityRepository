using UnityEngine;
/// <summary>
/// ����Ƽ ��Ʈ����Ʈ unity attribute
/// �����Ϳ� �°� ��ũ��Ʈ�� Ŀ�����ϴ� ���� ����
/// </summary>
/// 
[AddComponentMenu("customUtil/scriptex")]
public class scriptex : MonoBehaviour {
    [Range(1, 99)]
    public int level;

    [Range(0, 100)]
    public int volum;

    [Header("�÷��̾��� �̸�")]
    public string player_name;

    [TextArea]
    public string talk01;

    [TextArea(1,3)] 
    public string talk02;

    [TextArea(5,7)]
    public string talk03;

    [Tooltip("üũ�Ǹ� ���� �������� �ǹ�")]
    public bool isDead = true;

    //�Լ�(function) C#������ Ŭ���� ���ο��� ����Ǵ� �Լ��� �޼ҵ�method��� �θ�
    //�Լ��� Ư�� �ϳ��� ����� �����ϱ� ���� �ۼ��� ��ɹ� ����ü
    //�ڵ峻���� ����� �Լ��� ���ϴ� ��ġ���� ���ϴ� ��ġ���� ȣ���� ���� ����Ҽ��ִ�
    //�Լ��� ������>>
    //�ڷ��� �Լ��̸�(�Ű�����)
    //{
    //�Լ��� ȣ�������� ������ ��ɹ��� �ۼ��ϴ� �ڸ�;
    //}
    //�Լ�ȣ����
    //�Լ��̸�(����);

[ContextMenu("HelloEveryone")]
    void HelloEveryone()
    {
        Debug.Log("�ȳ�");
    }
    void HelloSomeone(string who)
    {

        Debug.Log($"{who}�� �ȳ�");
    }

}
