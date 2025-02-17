using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class DelegateSample : MonoBehaviour
{

    /*
     * delegate
     * 함수를 대입할 수 있는 변수. 대리자라고 부른다
     * 해당변수에는 함수가 대입되어있으므로 해당변수를 실행하면 대입한 함수가 실행되는 방식
     * 
     * delegate 선언 방법 : 접근제한자 delegate 타입 델리게이트(매개변수)
       - delegate void DelegateTest2(int a, int b);
       - delegate string DelegateText(float x);
       - delegate int DelegateInt(int x, int y);
     */
    delegate void DelegateTest(); 
   



    
    void Start()
    {
        //델리게이트 변수처럼 사용
        //델리게이트 변수명 = new 델리게이트명(함수명);
        DelegateTest dt = new DelegateTest(Attack);

        //함수처럼 호출
        dt = Attack;
        dt();

        //내용변경: 변수명 = 함수명;
        dt();

        /*
         * delegate변수 만들어서 객체를 할당하는 이유?
           - 1. delegate는 함수가 아닌 타입이기 때문
              매개변수로도 활용이 가능, return타입으로 잡아주는 것도 가능
           
         * 델리게이트 체인
           - delegae는 +=를 통해 대리할 함수를 더 추가할 수 잇고 -=를 통해 대리한 함수를 제거도 가능
        ex1)
        void UseDelegate(DelegateTest dt)
        {
            dt();
        }
        ex2)
         DelegateTest Selection(int value)
        {
            if(value == 0) return Attack;
            else if (value == 1) return Guard; 
            else return MoveLeft;
        }

         */
        dt += Guard;
        dt += Guard;
        dt += Guard;
        dt();



    }
    void Attack() => Debug.Log("공격");
    void Guard() => Debug.Log("방어");
    void MoveLeft() => Debug.Log("왼쪽이동");

}
