using UnityEngine;
using System.Collections.Generic;//Queue를 사용할때 쓰는 using System.Collections.Generic;
using System;

/*
# Interface
> 오브젝트를 풀에 만들어두고, 필요할떄마다 객체를 꺼내서 사용하는 방식

> 매번 실시간으로 파괴하고 생성하는 것보다 CPU부담을 줄일수있따

> 대신 미리 할당해두는 방식이기때문에 메모리를 희생해서 성능을 높이는 방식 
 
 
 */
public interface IPool //디자인패턴코드 
{
    //Property
    Transform parent { get; set; } //d인터페이스에서는 값을 직접넣을 수 없기에, 프로퍼티로 진행한다 (get set)                                   
    Queue<GameObject> pool { get; set; } //'FIFO(선입선출) -> Queue' or 'List' 선택해서 쓰자

    //Function(함수)
    //default parameter 값을 따로 넣지 않앗을경우 지정한 값으로 자동처리
    //ex) var go = GetGameObject();
    //ex) var go = GetGameObject(action); 
    // 몬스터를 가져온다
    GameObject GetGameObject(Action<GameObject> action = null); //Action : 이벤트를 담을 수 있는 delegate

    //pool에 대한 리턴, 몬스터를 반납한다
    void ObjectReturn(GameObject ob, Action<GameObject> action = null);
}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>(); //Queue는 자료구조라서 붙는게 가능??
    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj = pool.Dequeue(); //pool에 있는 값 하나 빼오기
        obj.SetActive(true); //obj의 활성화 진행
        if (action != null)  //액션으로 전달 받은 값이 있다면?
        {
            action?.Invoke(obj); //전달받은 액션을 실행한다
                                 //?는 null에 대한 설정
        }
        return obj;
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;
        ob.SetActive(false);
        if (action != null)  //액션으로 전달 받은 값이 있다면?
        {
            action?.Invoke(ob); //전달받은 액션을 실행한다
                                //?는 null에 대한 설정 or  action != null확인햇으니 ?는 삭제해도 됨
        }
    }
}

public class PoolManager 
{

    public Dictionary<string, IPool> pool_dict = new Dictionary<string, IPool>();
    //key : string
    //value : IPool
    public IPool PoolObject(string path)
    {

        if (!pool_dict.ContainsKey(path)) //pool_dict가 전달받은 키를 가지고 있지않다면, 추가를 진행한다
        {
            Add(path);
        }
        

        //큐에 없는 경유 큐 추가
        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }
        return pool_dict[path];
        //pool_dict안에 키를 넣으면 값으로 처리;

    }

    public GameObject Add(string path)
    {
        var obj = new GameObject(path + "Pool");
        //전달받은 이름으로 풀 오브젝트 생성
        ObjectPool object_pool = new ObjectPool();
        //오브젝트 풀 생성

        pool_dict.Add(path, object_pool);
        //경로와 오브젝트 풀을 딕셔너리에 저장

        object_pool.parent = obj.transform;
        //transform설정

        return obj;
    }

    public void AddQ(string path) //경로기반으로 enqueue하는 기능
    {
        var go = BaseManager.instance.CreatFromPath(path);
        go.transform.parent = pool_dict[path].parent;

        pool_dict[path].ObjectReturn(go);
    }

}
