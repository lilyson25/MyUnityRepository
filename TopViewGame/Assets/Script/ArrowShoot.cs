using System;
using UnityEngine;

public class ArrowShoot : MonoBehaviour
{
    public float speed = 12.0f;
    public float delay = 0.25f;
    public GameObject bowPrefab; //활
    public GameObject arrowPrefab;

    bool inAttack = false; //공격 모드인지 확인
    GameObject bowObject;
    GameObject arrowObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = transform.position;
        bowObject = Instantiate(bowPrefab, pos, Quaternion.identity);
        bowObject.transform.SetParent(transform);

        // 활의 SpriteRenderer 설정을 Start()에서 한 번만 실행!
        SpriteRenderer bowRenderer = bowObject.GetComponent<SpriteRenderer>();
        bowRenderer.sortingLayerName = "Foreground"; // 미리 설정 필요
        bowRenderer.sortingOrder = 10;
    }


    // Update is called once per frame
    void Update()
    {
        var player_controller = GetComponent<PlayerController>();
        float z = player_controller.z;

        

        float bowZ = -0.5f; // 기본적으로 캐릭터보다 앞 (활이 보이도록)
        float bowOffsetY = -0.3f; // 활을 캐릭터보다 아래로 배치

        // 캐릭터가 위쪽(Up) 방향일 때 활 숨기기
        if (z == 90)
        {
            bowObject.SetActive(false); // 활 숨기기
            return; // 이후 코드 실행하지 않음
        }
        else
        {
            bowObject.SetActive(true); // 활 보이기
        }

        // 활의 위치 및 회전 적용
        bowObject.transform.rotation = Quaternion.Euler(0, 0, z);
        bowObject.transform.position = new Vector3(transform.position.x, transform.position.y + bowOffsetY, bowZ);
    }



    private void Attack()
    {
        //화살을 가지고 있고, 공격 상태가 아닌 경우
        if (ItemKeeper.hasArrows > 0 && inAttack == false)
        {
            ItemKeeper.hasArrows--; //화살 1개 소모
            inAttack = true; //공격 모드로 전환

            var player_controller = GetComponent<PlayerController>();

            float z = player_controller.z; //회전 각

            var rotation = Quaternion.Euler(0, 0, z);

            //계산한 회전 각으로 오브젝트를 생성합니다.
            var arrow_object = Instantiate(arrowPrefab, transform.position, rotation);

            float x = Mathf.Cos(z * Mathf.Deg2Rad);
            float y = Mathf.Sin(z * Mathf.Deg2Rad);

            Vector3 vector = new Vector3(x, y) * speed;

            var rbody = arrow_object.GetComponent<Rigidbody2D>();

            rbody.AddForce(vector, ForceMode2D.Impulse);

            //발사 딜레이만큼 지연 시켜서 공격 모드를 해제합니다.
            Invoke("AttackChange", delay);
        }
    }

    public void AttackChange() => inAttack = false;
}