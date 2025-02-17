using UnityEngine;
/*
### T singleton
> <T>�κп� Ÿ���� �־ �ش� ���·� ������ִ� �̱��� 
 
* 1. <T>�� ����ڰ� Ÿ���� ���� ��ġ
* 2. whrere �� �ش� �۾��� ���� ���� ������ �ǹ�
* ex) T : MonoBehaviour��� T�� MonoBehaviour�̰ų� �Ǵ� ��ӵ� Ŭ�������� ��

 
 */
public class TSingletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {

        get
        {
            if (instance == null)//�ν��Ͻ��� ����ִٸ�
            {
                instance = (T)FindAnyObjectByType(typeof(T));
                //instance = FindAnyObjectByType<T>(); 
                //���Ӿ������� �ش� Ÿ���� ������ �ִ� ������Ʈ�� ã�Ƴ�
                //<T>�� ���� ������ �ش� �������� ���·� �����ϱ� ���ؼ�

                if (instance != null)//������ �����ߴµ��� ����ִٸ� 
                {
                    var manager = new GameObject(typeof(T).Name);
                    //�ش� Ÿ���� �̸����� ���ӿ�����Ʈ�� �����Ѵ�
                    //ex)������� �����Ͱ� GameManager��� �̸��� GameManager�� ���������̴�.
                    instance = manager.AddComponent<T>();
                    //�Ŵ����� �ش�Ÿ���� ������Ʈ�ν� �������ش�
                }

            }
            return instance;
        }

    }
    protected void Awake() //�̺�Ʈ �Լ� - protected : ��ӹ�����������  -> protected�� public���ε� �ᵵ �ǳ�...
    {
        if (instance == null)
        {
            instance = this as T;
            //as T�� �ش� ���� T�� ����ϰڴٴ� �ڵ�
            //T�ν� ������ �ִ� �� �ڽ�(this)�� ���� ������
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject);
    }


}
