using UnityEngine;

[System.Serializable]//클래스에 대한 직렬화 : 데이터를 읽을 수 있는 형태로 바꾸는 것

public class UserData 
{
 

    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    /*
    [constructor 생성자]  클래스의 이름과 동일한 메소드를 의미
                          반환타입이 따로 없는 메소드
                          따로 설정하지 않을 경우에는 기본 생성자로 처리
     
                          기본 생성자 = 클래스의 이름과 동일한 메소드, 매개변수를 따로 받지않는다
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
     *데이터를 하나의 문자열로 return하는 코드
     *아이디 이름 비밀번호 이메일 순으로 처리
     */
    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail}";
    //void가 아니라, 값을 전달할 경우 : 1줄이면 {}대신 => 사용이 가능하다

    /*
     데이터에 대한 정보를 전달받고 UserData로 return하는 코드
     아이디 이름 비밀번호 이메일 순으로 작성된 데이터
    */

    public static UserData SetData(string data)
    {
        string[] data_values = data.Split(',');  //문자열.Split(",") 해당문자열을 ()안에 넣어준 ,를 기준으로 잘라서 배열
        return new UserData(data_values[0], data_values[1], data_values[2], data_values[3]); 
    }








}
