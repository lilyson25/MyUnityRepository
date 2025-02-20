using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject main_image;
    public Sprite game_over_sprite;
    public Sprite game_clear_sprite;
    public GameObject panel;
    public GameObject restartButton;
    public GameObject nextButton;

    Image image;

    //timecontroller에서 가져오는 값
    public GameObject time_bar;
    public GameObject timeText;
    TimeController timeController;


    void Start()
    {
        timeController = GetComponent<TimeController>(); //타임 컨트롤러 연결 및 설정

        if (timeController != null)
        {
            if (timeController.game_time == 0.0f)
            {
                time_bar.SetActive(false);//시간 제한이 없다면 숨기겠습니다

            }
        }
        //내용 텍스트와 패널에 대한 설정


        Invoke("InactiveImage", 1.0f); //1초 뒤 함수호출
        panel.SetActive(false);
        //함수를 지연시키는 코드 Invoke 활용

    }
    void InactiveImage()
    {
        main_image.SetActive(false);
    }



    void Update()
    {
        if (PlayerController.state == "gameclear")
        {
            main_image.SetActive(true); //이미지 활성화
            panel.SetActive(true);//판넬 "
            //다시 시작 버튼에 대한 비활성화(게임을 클리어했으니까)
            restartButton.GetComponent<Button>().interactable = false;
            //메인이미지를 게임클리어 이미지로 변경한다
            main_image.GetComponent<Image>().sprite = game_clear_sprite;
            //플레이어 컨트롤러의 상태를 end로 변경한다
            PlayerController.state = "end";


            //타임바 관련
            if(timeController !=  null)
            {
                timeController.is_timeover = true;
            }
        }
        else if (PlayerController.state == "gameover")
        {
            main_image.SetActive(true); //이미지 활성화
            panel.SetActive(true);

            nextButton.GetComponent<Button>().interactable = false;
            main_image.GetComponent<Image>().sprite = game_over_sprite;
            PlayerController.state = "end";

            if (timeController != null)
            {
                timeController.is_timeover = true;
            }
        }
        else if (PlayerController.state == "playing")
        {
            //게임 진행 시에 대한 추가 처리를 구현하는 자리
            GameObject player = GameObject.FindWithTag("Player");
            PlayerController playerController = player.GetComponent<PlayerController>();
            if (playerController != null)
            {
                if(timeController.game_time > 0.0f)
                {
                    
                    int time = (int)timeController.display_time; //표기상에 정수로 보이게 int로 바꿔서 소수점 버리는 작업
                    timeText.GetComponent<Text>().text = time.ToString(); //문자열 넣을거면, ToString()괄호안에

                    if(time == 0)
                    {
                        playerController.GameOver();

                    }
                }
            }
        }
    }
}
