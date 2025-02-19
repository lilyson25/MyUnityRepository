using System;
using UnityEngine;



public class Monster : Character
{
    // 
    public float monster_speed;
   
    public float rate = 0.5f;

    protected override void Start()
    {
        base.Start(); //base = 뼈대, character를 실행하라
    }
    //Action 테스트
    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // 
    void Update()
    {
        transform.LookAt(Vector3.zero);//영점기준으로 시선변경

        //간격설정
        float target_distance = Vector3.Distance(transform.position, Vector3.zero);

        if (target_distance <= rate) //간격 거리와 가까워지면 이동중지
        {
            SetMotionChange("isMOVE", false);
        }
        else//일반적인 경우에는 움직임을 진행한다
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, Time.deltaTime * monster_speed);
            //영점으로 몬스터의 속도만큼 앞으로 이동한다
            //중앙으로 모으기위해 값을 zero
            SetMotionChange("isMOVE", true);
        }
    }

  
}

