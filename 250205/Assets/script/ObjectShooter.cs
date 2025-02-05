using System.Runtime.Serialization;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]

public class ObjectShooter : MonoBehaviour
{
    //발사기능을 제공해주는 클래스
    //충돌 시 오브젝트를 고정시켜주는 역할도 진행
    
    GameObject creatObject;
    void Start()
    {
        creatObject = GameObject.Find("CreatObject");
        //오브젝트 탐색기능
        // 씬에서 해당ㅎ이름을 가진 게임오브젝트를 찾아 그 값을 얻어오는 GameObject.Find()기능
        // creatObject = GameObject.FindWithTag("GG"); //GG태그를 가진 오브젝트 탐색
        // obg = FindObjectofType<CreatObject>(); <>안에 넣어준 타입에 맞는 오브젝트를 탐색/ 위에 따로 CreatObject obj; 라고 선언해줘야함

        //가장 쉬운 건 Find()
        //검색 범위가 너무 맣아지면 불필요하게 성능저하게 발생할 수 있음
        //따라서 그떄부터 Tag  Type등으로 검색범위를 제한해서 찾는 방식을 사용

        //.씬에 해당값이 없으면 null

    }
    //발사기능 함수
    /// <summary>
    /// 물체를 발사하는 기능을 가진함수(메소드)
    /// </summary>
   // 물체의 발사방향
    //

    public void Shoot(Vector3 direction)
    {
        GetComponent<Rigidbody>().AddForce (direction,ForceMode.Impulse);
        Debug.Log("맞았다");

    }


    //충돌시 멈추기kinematic
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if (collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else// 과녁일경우
        {
            creatObject.GetComponent<CreatObject>().ScorePlus(10);
                      
        }
    }
}
