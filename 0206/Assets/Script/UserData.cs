using UnityEngine;

[System.Serializable]//Ŭ������ ���� ����ȭ : �����͸� ���� �� �ִ� ���·� �ٲٴ� ��

public class UserData 
{
 

    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    /*
    [constructor ������]  Ŭ������ �̸��� ������ �޼ҵ带 �ǹ�
                          ��ȯŸ���� ���� ���� �޼ҵ�
                          ���� �������� ���� ��쿡�� �⺻ �����ڷ� ó��
     
                          �⺻ ������ = Ŭ������ �̸��� ������ �޼ҵ�, �Ű������� ���� �����ʴ´�
        public UserPhone)
            {

            }
    */

    public UserData()
    {

    }

    public UserData(string userID, string userName, string userPassword, string userEmail)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }
    /*
     *�����͸� �ϳ��� ���ڿ��� return�ϴ� �ڵ�
     *���̵� �̸� ��й�ȣ �̸��� ������ ó��
     */
    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail}";
    //void�� �ƴ϶�, ���� ������ ��� : 1���̸� {}��� => ����� �����ϴ�

    /*
     �����Ϳ� ���� ������ ���޹ް� UserData�� return�ϴ� �ڵ�
     ���̵� �̸� ��й�ȣ �̸��� ������ �ۼ��� ������
    */

    public static UserData SetData(string data)
    {
        string[] data_values = data.Split(',');  //���ڿ�.Split(",") �ش繮�ڿ��� ()�ȿ� �־��� ,�� �������� �߶� �迭
        return new UserData(data_values[0], data_values[1], data_values[2], data_values[3]); 
    }








}
