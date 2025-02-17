using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{

    public AudioEvent audioEvent;
    public Item item;
   
    void Start()
    {
        audioEvent.OnPlay += PlaySound;
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioEvent.Play("배경음");
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            DropItem();
        }
    }

    private void DropItem()
    {
       var item_Object = item.gameObject;
       Instantiate(item_Object, transform.position, Quaternion.identity);
       
    }

    public void PlaySound(string soundName)
    {
        Debug.Log(soundName + "재생중");
    }

}
