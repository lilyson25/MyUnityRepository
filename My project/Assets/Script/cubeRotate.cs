using UnityEngine;
/// <summary>
/// cube rotate class
/// </summary>
public class cubeRotate : MonoBehaviour
{
    #region 필기내용
    //자료형(type)>> 프로그램이 데이터를 판단하는 기준
    //   int : 정수integer(소수점 없는 숫자, 0을 포함함)
    // float : 실수 (소수점이포함된 숫자)
    //  bool : 논리(boolean) - true, false
    //string : 문자의 집합(묶음)
    
    //변수variable>> 특정값 하나를 저장하기위해 이름을 붙인 저장 공간
    //형식 : 자료형 변수형;

    //변수의 값 설정(초기화)>> 변수에 값을 적용시키는 작업
    //변수형 = 값;


    #endregion

    #region 변수
    public float x; //유니티 에디터에서 공개되는 변수
    private int sample; //유니티 에디터에서 공개가 안되는 변수
    public float y;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    #region 함수
    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(x*Time.deltaTime, y*Time.deltaTime, 0));
        //FPS(frame per second 초당프레임)
        //deltaframe 전 프레임이 완료되기까지 걸리는 시간
    }
    #endregion
} 
