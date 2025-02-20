using UnityEngine;

public class TimeController : MonoBehaviour
{

    public bool is_countdown = true; //true : 카운트 다운 진행
    public float game_time = 0; //실제 진행할 게임 시간(최대시간)
    public bool is_timeover = false; //false 타이머 작동 중 , true 타이머정지
    public float display_time = 0; //화면에 표시하기 위한 시간

    float times = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //카운트 다운이 진행중이라면, 표기된 시간을 게임시간으로 설정합니다
        if(is_countdown)
        {
            display_time = game_time;

        }
    }

    // Update is called once per frame
    void Update()
    {

        if(is_timeover == false)
        {
            times += Time.deltaTime;

            if (is_countdown)
            {
                display_time = game_time - times;

                if (display_time <= 0.0f)
                {
                    display_time = 0.0f;
                    is_timeover = true;
                }
            }
            else
            {
                display_time = times;
                if (display_time >= game_time)
                {
                    display_time = game_time;
                    is_timeover = true;
                }

            }
        }
    }
}
