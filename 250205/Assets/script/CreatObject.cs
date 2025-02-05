
using TMPro;
using UnityEngine;


public class CreatObject : MonoBehaviour
{
    //1. 이 클래스는 오브젝트를 생성하는 기능을 가지고 있습니다
    //2. 마우스 버튼을 눌렀을때, 카메라의 스크린지점을 통해 
    //   물체의 방향을 정한다
    //3. 물체를 방향에 맞춰 발사하는 기능을 호출해온다
 
    public GameObject prefab; //오브젝트 프리팹 등록
    GameObject scoreText; //점수표시: UI>TextMeshPro 사용)
    public float power = 500f;
    public int score = 0;
    
    public Material newSkyboxMaterial;//30점 이상일때 변경될 newSkyboxMaterial

    private MaterialChange materialChange;

    private void Start()
    {
        scoreText = GameObject.Find("score"); //게임씬에서 score를 찾아서 등록
        scoreText.GetComponent<TextMeshProUGUI>().text = $"점수 : 0";

        materialChange = FindObjectOfType<MaterialChange>(); // MaterialChange 스크립트 찾기
        if (materialChange == null)
        {
            Debug.LogError("MaterialChange xx");
        }
        else
        {
            Debug.Log("MaterialChange OO");
        }
    }

    //점수를 증가시키는 
    //value = 수치
    public void ScorePlus(int value)
    {
        score += value;
        SetScoreText();

        if (score >=30 && materialChange != null && newSkyboxMaterial != null)
        {
            Debug.Log("ok");
            materialChange.ChangeSkybox(newSkyboxMaterial);
        }

    }

    //현 점수에 대한 출력
    
    void SetScoreText()
    {
      scoreText.GetComponent<TextMeshProUGUI>().text = $"점수 : {score}"; 

    }


    void Update()
    {
        //mouse 0번 버튼을 눌렀을때
        // 마우스버튼 0왼쪽/ 1오른쪽/ 2휠
        // ~~down 클릭시 1번/ ~up 버튼을 놓았을때 1번/  : 클릭하는 동안 지속
        if (Input.GetMouseButtonDown(0))
        { 
            var thrown = Instantiate(prefab); //Instantiate()는 유니티에서 오브젝트를 동적으로 복제(생성)하는 함수
            // as GameObject는 instantiate와 같이 사용하면 게임오브젝트로서 생성하라는 의미
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*  //ray
            //가상의 레이저선으로 발사하는 시작지점과 방향을 가지고 있다.
            
            //일반적인 ray는 vector3 (ray2d는 vector2)
            // 데이터만 가지고 있는 구조체, 방향계산이나 Raycast를 이용해 오브젝트 충돌기능으로 활용
            Vector3 orogin = new Vector3(0,0,0);
            Vector3 vect_dir = Vector3.forward;
            Ray newRay = new Ray(ray.origin, vect_dir);
        */

            var direction = ray.direction; //방향설정
            thrown.GetComponent<ObjectShooter>().Shoot(direction.normalized * power); //normalized 동일한속도 정규화는 벡터의 방향을 유지하면서 길이를 1로 맞추는 것
        }
    }

}
