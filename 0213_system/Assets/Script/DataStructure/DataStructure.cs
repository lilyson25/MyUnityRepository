using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/*
 ### �ڷᱸ�� Datastructure (������ ���� ����)
> ����Ƽ���� Ư��  ������ �Ǵ� ����� �����ϱ� ���� ������ �ڷ����� ���� �� �ʼ�
> �⺻ �ڷ��� �̿ܿ� �Ѥ������, �۾��� ������ �� �ִ� ������ ����ü�� �ڷᱸ���� �θ���.

* ���� Ȱ��Ǵ� �ڷᱸ��
  - List : ������� ������ �� �ְ�, ���嵥���͸� �߰� ���� �˻��� ���ִ� ������ ������ �迭 
  - Dictionary : Ű - ������ ���� ������ �� �ִ� ����(json ���Ͽ����� Ȯ�ΰ���)
  - Queue : �ڷḦ ���Լ���(FIFO)�� ������ �� ����� �ڷᱸ��
  - stack : �ڷḦ ���Լ���(LIFO)�� ������ �� ����� �ڷᱸ��
  - HashSet : �������� �ߺ��� ���� ������� �ʴ� ���, ���� ������ �ʿ���� ���
 
* Queue
  - �������ִ� ��� : ����, ����, ù��° �� ��ȸ����
  - ���� : �߰��� �ִ� �����͸� �����ϴ� �κп��� �ſ� ��ȿ������
 */
public class DataStructure : MonoBehaviour
{
    //string ������ ���� ������ �� �ִ� ť
   public Queue<string> stringQueue = new Queue<string>() ;

    private void Start()
    {
        //1. Queue�� ������ �߰�
        stringQueue.Enqueue("uno");
        stringQueue.Enqueue("dos");
        stringQueue.Enqueue("tres");
        stringQueue.Enqueue("quatro");
        stringQueue.Enqueue("cinco");

        //2. ù��° ������ ��ȸ
        foreach(string dialog in stringQueue) //stringQueue���� ��ȭ�� �ϳ��ϳ� �������ٴ�
        {
            Debug.Log(stringQueue.Peek()); //queue�� ����� �� ���� ���� return

        }
        //3. Queue�� ������ ����
      
        Debug.Log(stringQueue.Dequeue()); //queue�� ����� �� ���� ���� return, �߰������� �Ǿ��� ���� ���� 
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());
        Debug.Log(stringQueue.Dequeue());


    }
}

