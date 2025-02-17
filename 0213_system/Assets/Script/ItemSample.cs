using System;
using UnityEngine;

public class ItemSample : MonoBehaviour
{
    // ������ ���
    public Item item;
    
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ItemInfo();
        }
    }

    private void ItemInfo()
    {
        Debug.Log(item.name); //��Ʈ���ͺ� ������Ʈ�� ���� �� �ٿ��� �̸�      
        Debug.Log(item.id); //��ũ���ͺ� ������Ʈ���� ������ ����
        Debug.Log(item.price);
        Debug.Log(item.description);
    }
}
