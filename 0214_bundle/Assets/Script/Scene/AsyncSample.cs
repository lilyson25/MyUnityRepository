using System.Threading.Tasks;
using UnityEngine;

/*
## ����(Synchronous)
> Task(�۾�)�� ���������� �����ϴ� ���
> �ϳ��� �۾��� �Ϸ�ɶ����� ���� �۾��� �����·� ����

## �񵿱�(Asynchornous)
> �������� �۾�(task)�� ���ÿ� ó���ϴ� ���
> 

*/

public class AsyncSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("�۾� ����");
        Sample();
        Debug.Log("Process A");

    }

    /*
  ## async Ű���� :
   > �񵿱� �޼ҵ带 ������ �� ����ϴ� Ű����
    //�޼ҵ��� ���� ������� �񵿱��� ����

    //�ش� Ű����� �޼ҵ�, ���ٽ� � ���� �� �ִ�
    //�ش� Ű���尡 ���� �޼ҵ�� Task, Task<T> �Ǵ� void�� return�ϰ� �ȴ�

    //Task�� �񵿱��۾��� ��Ÿ���� Ŭ������, (using)System Threading Tasks������ �����Ѵ�    

    ```
     private async void Sample()
    {
        Debug.Log("Process B");
        
        await Task.Delay(10000);
        //await�� �񵿱� �޼ҵ峻���� ���Ǵ� Ű���� (�ð��� �����ִ� Ű����, Coroutine�� ����� ����)
        //�ش� Ű����� Task�� Task<T>�� return�ϴ� �޼ҵ峪 ǥ���� �տ� ����� �� �ִ�
        //�ش� �񵿱� �۾��� �Ϸ�� ������ ������ �޼ҵ带 ������Ų��
        //�۾��� �Ϸ�Ǹ� �ٽ� �ش� �޼ҵ带 ��� �����Ų��


        Debug.Log("Process C");
    }
    ```
    */
    private async void Sample()
    {
        Debug.Log("Process B");
        
        await Task.Delay(10000);
        //await�� �񵿱� �޼ҵ峻���� ���Ǵ� Ű���� (�ð��� �����ִ� Ű����, Coroutine�� ����� ����)
        //�ش� Ű����� Task�� Task<T>�� return�ϴ� �޼ҵ峪 ǥ���� �տ� ����� �� �ִ�
        //�ش� �񵿱� �۾��� �Ϸ�� ������ ������ �޼ҵ带 ������Ų��
        //�۾��� �Ϸ�Ǹ� �ٽ� �ش� �޼ҵ带 ��� �����Ų��


        Debug.Log("Process C");
    }

}
