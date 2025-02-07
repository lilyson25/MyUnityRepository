using UnityEngine;

[System.Serializable]//Ŭ������ ���� ����ȭ : �����͸� ���� �� �ִ� ���·� �ٲٴ� ��

public class InputData
{


    public string ItemsName;
    public string ItemsInfo;
   
    /*
    [constructor ������]  Ŭ������ �̸��� ������ �޼ҵ带 �ǹ�
                          ��ȯŸ���� ���� ���� �޼ҵ�
                          ���� �������� ���� ��쿡�� �⺻ �����ڷ� ó��
     
                          �⺻ ������ = Ŭ������ �̸��� ������ �޼ҵ�, �Ű������� ���� �����ʴ´�
        public UserPhone)
            {

            }
    */

    public InputData()
    {

    }

    public InputData(string itemsName, string itemsInfo)
    {
        ItemsName = itemsName;
        ItemsInfo = itemsInfo;
     
    }
    /*
     *�����͸� �ϳ��� ���ڿ��� return�ϴ� �ڵ�
     *���̵� �̸� ��й�ȣ �̸��� ������ ó��
     */
    public string GetData() => $"{ItemsName},{ItemsInfo}";
    //void�� �ƴ϶�, ���� ������ ��� : 1���̸� {}��� => ����� �����ϴ�

    /*
     �����Ϳ� ���� ������ ���޹ް� UserData�� return�ϴ� �ڵ�
     ���̵� �̸� ��й�ȣ �̸��� ������ �ۼ��� ������
 

    public static UserData SetData(string data)
    {
        string[] data_values = data.Split(',');  //���ڿ�.Split(",") �ش繮�ڿ��� ()�ȿ� �־��� ,�� �������� �߶� �迭
        return new UserData(data_values[0], data_values[1], data_values[2], data_values[3]);
    }

       */






}
