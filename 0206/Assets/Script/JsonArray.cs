using System;
using UnityEngine;
using System.Collections.Generic;
using static UnityEditor.Progress;

/*
 * 1.배열/ List형태로 저장되어있는 json파일을 사용하는 예제
 * 2.Resources폴더를 이용한 데이터 로드 방법
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
   // public Item[] inventory; 유니티에서 배열과 리스트는 같은 의미

}

public class JsonArray : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        TextAsset textAsset = Resources.Load<TextAsset>("item_inventory"); //Resources라는 폴더를 불러서 파일을 찾아내라
        Inventory inventory = JsonUtility.FromJson<Inventory>(textAsset.text);

        int total = 0;
        //foreach(타입 변수 in 배열/리스트)
        //배열이나 리스트가 가지고 잇는 데이터 개수만큼 반복을 진행하는 전용 문법
        //foreach(데이터_타입 변수 in 컬렉션)
        foreach (Item item in inventory.inventory)
        
        {
            total += item.item_count;
        }
        Debug.Log(total);

       /* //배열식 계산
                for (int i = 0; i < inventory.inventory.Count; i++)
                 {
                      total += inventory.inventory[i].item_count;
                 }
             
       */
    }
}

