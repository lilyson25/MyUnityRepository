using UnityEngine;

public class Player : Character
{
    // character에 없는 값만 
    Vector3 start_pos;
    Quaternion rotation;
    protected override void Start()
    {
        //케릭터 클래스의 start시작
        base.Start();

        if (animator == null)
        {
            Debug.LogError("애니메이터 할당필요");
        }

        //시작값 설정
        start_pos = transform.position;//local position은 부모에서의 거리(상대적인 거리)
        rotation = transform.rotation;
    }

    // 
    void Update()
    {
        if (target == null)
        {
            //가까운 타겟을 조사한다
            TargetSearch(Spawner.monster_list.ToArray());
            //리스트명.ToArray()를 통해 List=> array로 변경

            float pos = Vector3.Distance(transform.position, start_pos);
            if (pos > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, start_pos, Time.deltaTime * 2.0f);
                transform.LookAt(start_pos);
                SetMotionChange("isMOVE", true);

            }
            else
            {
                transform.rotation = rotation;
                SetMotionChange("isMOVE", false);
            }
            return; //작업종료 후 아래 다른 if문 돌리기
        }

        float distance = Vector3.Distance(transform.position, target.position);
        //타겟 범위보다 작음녀서 공격 범위보다 높은경우
        if (distance <= target_range && distance > attack_range)
        {
            SetMotionChange("isMOVE", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }
        //공격 범위안에 들어온 경우
        else if (distance <= attack_range)
        {
            //공격 자세로 넘어간다
            SetMotionChange("isATTACK", true);
        }
    }
}
