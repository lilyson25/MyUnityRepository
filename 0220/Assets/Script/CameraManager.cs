using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //카메라의 스크롤 제한값
    public float left_limit = 0.0f;
    public float right_limit = 0.0f; //컴포넌트 창에서 18.3값을 넣어주면 그 값까지 이동함
    public float top_limit = 0.0f;
    public float bottom_limit = 0.0f;


    //서브스크린
    public GameObject sub_screen;

    //강제 스크롤 기능 처리 (옵션으로 설정가능하게)
    public bool isForceScrollX = false;
    public bool isForceScrollY = false;
    public float forceScrollSpeedX = 0.5f; //1초간 움직일 X 방향의 거리
    public float forceScrollSpeedY = 0.5f; //1초간 움직일 Y 방향의 거리


    void Update()
    {
        //GameObject player = GameObject.FindGameObjectsWithTag("Player");
        GameObject player = GameObject.FindWithTag("Player");

        float x = player.transform.position.x;
        float y = player.transform.position.y;
        float z = transform.position.z; //카메라 좌표기준

        //가로 강제 스크롤
        if (isForceScrollX)
        {
            x = transform.position.x + (forceScrollSpeedX * Time.deltaTime);
        }


        //가로 방향에 대한 동기화
        if (x < left_limit) x = left_limit;
        else if (x > right_limit) x = right_limit;



        //새로 강제 스크롤
        if (isForceScrollX)
        {
            y = transform.position.y + (forceScrollSpeedY * Time.deltaTime);
        }

        //세로 방향에 대한 동기화
        if (y < bottom_limit) y = bottom_limit;
        else if (y > top_limit) y = top_limit;

        Vector3 vector3 = new Vector3(x, y, z);
        transform.position = vector3;

        //서브스크린작동
        if (sub_screen != null)
        {
            y = sub_screen.transform.position.y;
            z = sub_screen.transform.position.z;
            Vector3 v = new Vector3(x * 0.5f, y, z);
            sub_screen.transform.position = v;
        }
    }
}
