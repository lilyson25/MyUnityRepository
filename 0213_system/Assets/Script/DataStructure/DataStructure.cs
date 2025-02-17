using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 ### 자료구조 Datastructure (데이터 값의 모임)
> 유니티에서 특정  데이터 또는 기능을 구현하기 귀해 적압한 자료형을 고르는 건 필수
> 기본 자료형 이외에 ㅡㄱ정기능, 작업을 진행할 수 있는 데이터 집합체를 자료구조라 부른다.

* 자주 활용되는 자료구조
  - List : 순서대로 저장할 수 있고, 저장데이터를 추가 삭제 검색할 수있는 변경이 가능한 배열 
  - Dictionary : 키 - 값으로 묶어 저장할 수 있는 형태(json 파일에서도 확인가능)
  - Queue : 자료를 선입선출(FIFO)로 관리할 때 사용할 자료구조
  - stack : 자료를 후입선출(LIFO)로 관리할 때 사용할 자료구조
  - HashSet : 데이터의 중복을 전혀 허락하지 않는 경우, 정렬 순서가 필요없는 경우
 
* Queue
  - 제공해주는 기능 : 삽입, 삭제, 첫번째 값 조회가능
  - 단점 : 중간에 있는 데이터를 접근하는 부분에선 매우 비효율적임
 */
public class DataStructure : MonoBehaviour
{
    //string 형태의 값만 저장할 수 있는 큐
   public Queue<string> stringQueue = new Queue<string>() ;

    private void Start()
    {
        //1. Queue에 데이터 추가
        stringQueue.Enqueue("uno");
        stringQueue.Enqueue("dos");
        stringQueue.Enqueue("tres");
        stringQueue.Enqueue("quatro");
        stringQueue.Enqueue("cinco");

        //2. 첫번째 데이터 조회
        foreach(string dialog in stringQueue) //stringQueue에서 대화를 하나하나 가져오겟다
        {
            Debug.Log(stringQueue.Peek()); //queue에 저장된 맨 앞의 값을 return

        }
        //3. Queue에 데이터 삭제
      
        Debug.Log(stringQueue.Dequeue()); //queue에 저장된 맨 앞의 값을 return, 추가적으로 맨앞의 값을 제거 
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());


    }
}

