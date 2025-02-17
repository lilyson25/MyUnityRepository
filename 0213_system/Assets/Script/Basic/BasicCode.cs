using UnityEngine;
using UnityEngine.UI;

public class BasicCode : MonoBehaviour
{
    /* 
     #유니티에서 만들 클래스 

    ### MonoBehaviour
    ### 일반클래스 
    ### ScriptableObject가 연결되어있는 클래스 : Assets폴더 내부에 스크립트를 에셋으로 저장할 수 있는 클래스
   
     ###void Start() 씬을 시작할때 1번 실행되는 코드를 작성하는 위치, 주로 값에 대한 설정을 진행할때 해당위치에서 작업을 진행한다

    ### 접근제한자(Access modifier) : 프로그램 접근에 관련된 설정을 진행할 수 있는 키워드
    > public vs private 유니티 인스펙터에서 확인이 가능 혹은 불가능
    > [SerializeField]속성이 붙은 필드(변수)의 경우에는 인스펙터에서 공개됨
    > [Serializable]속성이 붙은 클래스를 변수로 사용할 경우 인스펙터에서 공개된다

    */
    public int number;
    private int count;
    [SerializeField] private bool able;

    public Text text;
    public GameObject cube;
    public SampleCode s;


    void Start()
    {
        cube = new GameObject(); //생성초기화
        s = GameObject.Find("GameObject (1)").GetComponent<SampleCode>();


        //함수사용법 : 함수명(인자값)
        //매개변수(parameter) 함수 설계시 호출하는 쪽에서 받아줄 데이터에 대한 표현
        //인자값(Argment) 함수 호출할 때 넣어주는 값

        Numfive();
        Debug.Log(number);

        SetNumber(10);
        Debug.Log(number);

        TextHello();
    }

  /*
  ### 메소드 : 클래스 내부에서 만들어지는 함수
  > 함수 : 명령문 집합체(특정 하나의 기능을 수행하기 위한)
  * 함수 만드는 방법
    - 접근제한자 반환타입 함수명(매개변수){ 실행할 명령문; }
  * 함수 형태
    - void형태의 함수 : 실행할 기능만 만들어줌      
    - void이외의 함수 : 실행이 끝나고 전달해줄 값을 고려해서 설계

  */

    public void Numfive() //void형태의 함수 : 실행할 기능만 만들어줌
    {
        number = 5;
    }
    public void SetNumber(int value) //파라미터에 전달받아 값을 내부에서 진행한다
    {
        number = value;
    }
    public void TextHello()
    {
        text.text = "Hello";
    }

   
   

}
