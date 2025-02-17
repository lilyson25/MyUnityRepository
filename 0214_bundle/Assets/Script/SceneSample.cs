using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    /*
     * Life Cycle
     * 시작단계부터 종료단계까지를 함수로 제공
     */
    private void OnEnable() //활성화 되었을 경우
    { 
        Debug.Log("씬 로드됨");
        SceneManager.sceneLoaded += OnScreenLoaded;
    }
    private void OnDisable() //비활성화 되었을 경우
    {
        Debug.Log("씬로드 해제됨");
        SceneManager.sceneLoaded -= OnScreenLoaded;
    }

    private void OnScreenLoaded(Scene scene, LoadSceneMode mode)
    {
      Debug.Log($"현재 로드된 씬의 이름은 {scene.name}입니다");
    }

    // 
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("BRP Sample Scene");
            //코드작성 중 번개표시로 자동으로 뜨는 부분 : 이벤트
            //따로 씬 모드를 설정하지 않으면, ("바뀔씬이름", LoadSceneMode.Single)로 처리됨

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("BRP Sample Scene", LoadSceneMode.Additive);
            //LoadSceneMode.Additive일경우에는 기존씬위에 새로운 씬을 중복해서 로드하는 설정
            //기본 오브젝트들(maincamera, directionlight등)도 다 로드되게때문에 주의해야함

        }
        if(Input.GetKeyDown(KeyCode.O))
        {

            StartCoroutine("LoadSceneC"); // StartCoroutine(타입으로 표현해줘야함)

            //SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
            //비동기적(async) 로드 : 로딩과 동시에 작업진행을 위한 방법 -> 지속적인 로딩작업이라 코루틴활용이 필요함
            //일반적인 씬 로딩작업은 동기적으로 처리됨 : 씬이 로딩완료전까지는 다른요소들은 작동하지 않음
        }   
    }
    IEnumerator LoadSceneC()
    {

        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
    }
}
