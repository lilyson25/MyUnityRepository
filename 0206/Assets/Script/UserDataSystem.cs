using UnityEngine;

public class UserDataSystem : MonoBehaviour 

{
    public UserData data01;
    public UserData data02;

    /*
    [PlayerPrefs���]

    DeleteAll() ����
    DeleteKey(Ű �̸�) �ش� Ű�� �ش��ϴ� ���� ����
    GetFloat/ Int/ String(Ű �̸�) Ű�� �ش��ϴ� ���� return,e������ Ÿ�Կ� ������
    SetFloat/ Int/ String(Ű �̸�, ��) �ش�Ű���� ����, ������ ���� Ű�� �ִٸ� ���� ������
    Haskey(Ű �̸�) �ش�Ű�� �����ϴ��� Ȯ��
    */

    private void Start()
    {
        data01 = new UserData();
        //Ŭ���� ������� : Ŭ��������(���۷��� Ȥ�� �ν��Ͻ�)�� = new ������();

        data02 = new UserData("test","son2", "0249", "S2@hotmail.com");


        //data02�� �����͸� ���̵�, �̸�, ���, �̸��ϼ����� ������
        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("Data01", data_value); //������ �����ͷ� Data01�� ����
        PlayerPrefs.Save();

        data01 = UserData.SetData(data_value); //data01�� ���޹��� �����ͷ� ����
        Debug.Log(data01.GetData()); //data01�� ����� ���޹޾Ҵ��� Ȯ��

    }


}

