using System.Threading.Tasks;
using UnityEngine;

/*
## 동기(Synchronous)
> Task(작업)을 순차적으로 실행하는 방식
> 하나의 작업이 완료될때까지 다음 작업은 대기상태로 유지

## 비동기(Asynchornous)
> 여러개의 작업(task)를 동시에 처리하는 방식
> 

*/

public class AsyncSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("작업 시작");
        Sample();
        Debug.Log("Process A");

    }

    /*
  ## async 키워드 :
   > 비동기 메소드를 선언할 때 사용하는 키워드
    //메소드의 실행 방식으로 비동기적 설정

    //해당 키워드는 메소드, 람다식 등에 사용될 수 있다
    //해당 키워드가 붙은 메소드는 Task, Task<T> 또는 void를 return하게 된다

    //Task는 비동기작업을 나타내는 클래스로, (using)System Threading Tasks영역에 존재한다    

    ```
     private async void Sample()
    {
        Debug.Log("Process B");
        
        await Task.Delay(10000);
        //await는 비동기 메소드내에서 사용되는 키워드 (시간을 벌어주는 키워드, Coroutine과 비슷한 개념)
        //해당 키워드는 Task나 Task<T>를 return하는 메소드나 표현식 앞에 사용할 수 있다
        //해당 비동기 작업이 완료될 때까지 현재의 메소드를 중지시킨다
        //작업이 완료되면 다시 해당 메소드를 계속 진행시킨다


        Debug.Log("Process C");
    }
    ```
    */
    private async void Sample()
    {
        Debug.Log("Process B");
        
        await Task.Delay(10000);
        //await는 비동기 메소드내에서 사용되는 키워드 (시간을 벌어주는 키워드, Coroutine과 비슷한 개념)
        //해당 키워드는 Task나 Task<T>를 return하는 메소드나 표현식 앞에 사용할 수 있다
        //해당 비동기 작업이 완료될 때까지 현재의 메소드를 중지시킨다
        //작업이 완료되면 다시 해당 메소드를 계속 진행시킨다


        Debug.Log("Process C");
    }

}
