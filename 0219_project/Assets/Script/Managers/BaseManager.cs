using UnityEditor;
using UnityEngine;


//프로젝트에서 개발할 매니저(종합)
public class BaseManager : MonoBehaviour
{
    //매니저의 뼈대 -> 싱글톤 개발
    //
    public static BaseManager instance;
    private static PoolManager pool_manager = new PoolManager();
    public static PoolManager POOL //생성자와 get 프로퍼티?
    {
        get
        {
            return pool_manager;
        }
    }
    public void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);



        }
        else
        {
            Destroy(gameObject);
        }
    }
   // Resources
    public GameObject CreatFromPath(string path) //풀매니저에서 경로 받아서 수정
    { 
        return Instantiate(Resources.Load<GameObject>(path));
    }
}      
