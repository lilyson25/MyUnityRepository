using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. 유니티 데이터의 저장
    //   게임내부의 데이터 : 가장 핵심
    //   PlayerPrefs 클래스 : 플레이어에 대한 환경 설정을 저장할때 사용되는 클래스
    //   해당클래스는 문자열, 실수, 정수를 사용자의 플랫폼 레지스트리에 저장할 수 있다
    //   PlayerPrefs는 Key와 Value로 구성되어 있는 데이터 (C#의 Dicionary)
    //   key는 value에 접근하기 위한 데이터 (실제 데이터)
    //   value는 key를 통해 접근할 수 있는 실질적인 값

    //   userID : current147 되어있다면, userID는 key. current147이 value에 해당

    public UserData userData;
    


    private void Start()
    {
        /*  
          1. 유니티 에디터에서 따로 userData에 대한 정보를 다 작성  
          PlayerPrefs.SetString("ID", userData.UserID);
          PlayerPrefs.SetString("UserName", userData.UserName);
          PlayerPrefs.SetString("Password", userData.UserPassword);
          PlayerPrefs.SetString("Email", userData.UserEmail);
        */


        /*
        2. 레이지스트리 키값을 검색하자 
        Debug.Log(PlayerPrefs.GetString("ID"));
        */

        /* PlayerPrefs.DeleteAll();//전체삭제
         Debug.Log("mission clear");


        Debug.Log("데이터 저장됨");*/

    }



}
