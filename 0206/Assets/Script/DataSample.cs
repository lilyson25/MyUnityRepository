using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. ����Ƽ �������� ����
    //   ���ӳ����� ������ : ���� �ٽ�
    //   PlayerPrefs Ŭ���� : �÷��̾ ���� ȯ�� ������ �����Ҷ� ���Ǵ� Ŭ����
    //   �ش�Ŭ������ ���ڿ�, �Ǽ�, ������ ������� �÷��� ������Ʈ���� ������ �� �ִ�
    //   PlayerPrefs�� Key�� Value�� �����Ǿ� �ִ� ������ (C#�� Dicionary)
    //   key�� value�� �����ϱ� ���� ������ (���� ������)
    //   value�� key�� ���� ������ �� �ִ� �������� ��

    //   userID : current147 �Ǿ��ִٸ�, userID�� key. current147�� value�� �ش�

    public UserData userData;
    


    private void Start()
    {
        /*  
          1. ����Ƽ �����Ϳ��� ���� userData�� ���� ������ �� �ۼ�  
          PlayerPrefs.SetString("ID", userData.UserID);
          PlayerPrefs.SetString("UserName", userData.UserName);
          PlayerPrefs.SetString("Password", userData.UserPassword);
          PlayerPrefs.SetString("Email", userData.UserEmail);
        */


        /*
        2. ��������Ʈ�� Ű���� �˻����� 
        Debug.Log(PlayerPrefs.GetString("ID"));
        */

        /* PlayerPrefs.DeleteAll();//��ü����
         Debug.Log("mission clear");


        Debug.Log("������ �����");*/

    }



}
