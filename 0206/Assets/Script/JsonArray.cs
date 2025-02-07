using System;
using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Progress;

/*
 * 1.�迭/ List���·� ����Ǿ��ִ� json������ ����ϴ� ����
 * 2.Resources������ �̿��� ������ �ε� ���
 */
[SerializeField]
public class Item
{

    public string item_name;
    public int item_count;
}


[SerializeField]
public class Inventory
{

    public List<Item> inventory;
   // public Item[] inventory; ����Ƽ���� �迭�� ����Ʈ�� ���� �ǹ�

}

public class JsonArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        TextAsset textAsset = Resources.Load<TextAsset>("item_inventory"); //Resources��� ������ �ҷ��� ������ ã�Ƴ���
        Inventory inventory = JsonUtility.FromJson<Inventory>(textAsset.text);

        int total = 0;
        //foreach(Ÿ�� ���� in �迭/����Ʈ)
        //�迭�̳� ����Ʈ�� ������ �մ� ������ ������ŭ �ݺ��� �����ϴ� ���� ����
        //foreach(������_Ÿ�� ���� in �÷���)
        foreach (Item item in inventory.inventory)
        
        {
            total += item.item_count;
        }
        Debug.Log(total);

       /* //�迭�� ���
                for (int i = 0; i < inventory.inventory.Count; i++)
                 {
                      total += inventory.inventory[i].item_count;
                 }
             
       */
    }
}

