using UnityEngine;

public class UserDataSystem : MonoBehaviour 

{
    public UserData data01;
    public UserData data02;

    /*
    [PlayerPrefs기능]

    DeleteAll() 삭제
    DeleteKey(키 이름) 해당 키와 해당하는 값을 삭제
    GetFloat/ Int/ String(키 이름) 키에 해당하는 값을 return,e데이터 타입에 맞춰사용
    SetFloat/ Int/ String(키 이름, 값) 해당키값을 생성, 기존에 같은 키가 있다면 값만 생성됨
    Haskey(키 이름) 해당키가 존재하는지 확인
    */

    private void Start()
    {
        data01 = new UserData();
        //클래스 생성방법 : 클래스변수(레퍼런스 혹은 인스턴스)명 = new 생성자();

        data02 = new UserData("test","son2", "0249", "S2@hotmail.com");


        //data02의 데이터를 아이디, 이름, 비번, 이메일순으로 가져옴
        string data_value = data02.GetData();
        Debug.Log(data_value);

        PlayerPrefs.SetString("Data01", data_value); //가져온 데이터로 Data01에 저장
        PlayerPrefs.Save();

        data01 = UserData.SetData(data_value); //data01을 전달받은 데이터로 설정
        Debug.Log(data01.GetData()); //data01에 제대로 전달받았는지 확인

    }


}

