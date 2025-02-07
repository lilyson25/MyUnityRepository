using UnityEngine;

class Unit
{

    //클래스에는 해당 클래스로 만들 객체(object)의 정보를 작성
    public string unit_name;

    public static void UnitAction() //객체(object)의 동작, 기능을 작성할 수 있다(메소드)
    {
        Debug.Log("유닛이 동작");
    }
    public void Cry()
    {
        Debug.Log("유닛이 움");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit;//Unit 선언으로 만든 unit객체(object)

    
    void Start()
    {
        unit.unit_name = "MiniGun";
        //클래스변수명.필드를 통해 클래스가 가지고 있는 필드(변수)를 사용할 수 있다.
        unit.Cry();
        //인스턴스명.메소드()를 통해 클래스가 가지고 잇는 메소드(함수)를 사용할 수 있다.

        /************
         * 
         클래스 결과물에 대한 명칭

         객체(object) : 실제 데이터, 클래스는 객체(object)를 만들기 위한 템플릿
         ex)Animal cat; 선언만해도 객체
            Animal cat = new Animal();

         레퍼런스 : 객체의 메모리상에서의 위치를 가리키는 것, 클래스나 배열, 인터페이스 등에 해당
         인스턴스 : 객체를 소프트웨어에서 실체회한 것 (new를 통해 만들어짐) 
         ex)Animal cat = new Animal();
         
         Unit.UnitAction(); -> static이 붙은 변수나 함수는 객체를 생성하지 않고 클래스에서 바로 그 기능을 가져와 사용
         
        ***********/
    }


}
