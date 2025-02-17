using UnityEngine;
/*
### T singleton
> <T>부분에 타입을 넣어서 해당 형태로 만들어주는 싱글톤 
 
* 1. <T>는 사용자가 타입을 적는 위치
* 2. whrere 는 해당 작업에 대한 제약 조건을 의미
* ex) T : MonoBehaviour라면 T는 MonoBehaviour이거나 또는 상속된 클래스여야 함

 
 */
public class TSingletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {

        get
        {
            if (instance == null)//인스턴스가 비어있다면
            {
                instance = (T)FindAnyObjectByType(typeof(T));
                //instance = FindAnyObjectByType<T>(); 
                //게임씬내에서 해당 타입을 가지고 있는 오브젝트를 찾아냄
                //<T>를 적는 이유는 해당 데이터의 형태로 변형하기 위해서

                if (instance != null)//씬에서 조사했는데도 비어있다면 
                {
                    var manager = new GameObject(typeof(T).Name);
                    //해당 타입의 이름으로 게임오브젝트를 생성한다
                    //ex)만들려는 데이터가 GameManager라면 이름도 GameManager로 지어질것이다.
                    instance = manager.AddComponent<T>();
                    //매니저에 해당타입을 컴포넌트로써 연결해준다
                }

            }
            return instance;
        }

    }
    protected void Awake() //이벤트 함수 - protected : 상속범위까지적용  -> protected은 public으로도 써도 되나...
    {
        if (instance == null)
        {
            instance = this as T;
            //as T는 해당 값을 T로 취급하겠다는 코드
            //T로써 가지고 있는 나 자신(this)의 값을 가진다
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }


}
