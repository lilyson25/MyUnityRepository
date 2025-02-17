using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    //관리할 게임오브젝트를 등록
    //아이템 데이터가 가지고 있는 게임오브젝트
    public GameObject gameObject;



    //아이템의 정보를 적어준다
    public int id; 
    public int price;
    public string description;
 
}
