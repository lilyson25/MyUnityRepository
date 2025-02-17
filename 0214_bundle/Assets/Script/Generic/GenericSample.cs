using UnityEngine;

/*
### C# �Ϲ�ȭ ���α׷�(Generic Programming) 
> ������ ���Ŀ� ���� �Ϲ�ȭ�� �����ϴ� ���
> <T> �� �̟G�ؼ� �����ϴ� ���


 */

public class GenericSample : MonoBehaviour
{
    // �迭�� ���޹޾Ƽ� �迭�� ��Ҹ� ������� ����ϴ� �ڵ�
    public static void printIArray(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Debug.Log(numbers[i]);
        }
    }
    public static void printFArray(float[] words)
    {
        for (int i = 0; i < words.Length; i++)
        {
            Debug.Log(words[i]);
        }
    }
    public static void printGArray<T>(T[] values)//T�� Ÿ���� ����ش�
    {
        for (int i = 0; i < values.Length; i++)
        {
            Debug.Log(values[i]);
        }
    }

    void Start()
    {
        int[] numbers = {1, 2, 3, 4, 5};
        float[] numbers2 = {1.1f, 2, 2f, 3.3f, 4.4f, 5.5f};
        string[] words = {"hello", "sdfds", "sdfd", "sdf"};
        printGArray<int>(numbers);
        printGArray(numbers2);
        printGArray(words);

    }



}
