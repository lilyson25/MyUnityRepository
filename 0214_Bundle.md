# 오늘 수업 정리 
```
1. Scene> Sync/Async -> Task에 대한 작업
2. Async, await
3. DontdestroyOnLoad
4. Manager코드
5. Singleton
```
## Scene등록방법
> File> Build Profiles-> Scene list에 씬을 드래그해서 등록

> 씬로드설정   
>> 1. Single : 다른씬으로 이동할 경우 기존씬이 파괴
>> 2. Additive : 게임내 씬이 동시에 켜짐(기존씬에 새로운 씬이 들어오는 형태)
>> 3. 주의사항 : Audio Listner중복조심/ 카메라기준으로 작업하는 코드를 짰을때 기존의 설정으로 동작이 제대로 안될 가능성이 있음/ Additive로 씬을 불러올 경우에 기존씬의 actuve Scene으로 유지되어있음
>> Active씬은 간단하게 오브젝트에 대한 생성 진행할때 귀속되는 씬을 의미, 이 경우에는 SceneManager의 Setactivescene을 통해 설정을 변경해서 사용가능 


```
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
```
---
### Unity Life cycle
> https://docs.unity3d.com/kr/2019.4/Manual/ExecutionOrder.html

---
## async 키워드 :
> 비동기 메소드를 선언할 때 사용하는 키워드

> 메소드의 실행 방식으로 비동기적 설정

> 해당 키워드는 메소드, 람다식 등에 사용될 수 있다

> 해당 키워드가 붙은 메소드는 Task, Task<T> 또는 void를 return하게 된다

> Task는 비동기작업을 나타내는 클래스로, (using)System Threading Tasks영역에 존재한다    
  ```
   private async void Sample()
  {
      Debug.Log("Process B");
      
      await Task.Delay(10000);
      //await는 비동기 메소드내에서 사용되는 키워드 (시간을 벌어주는 키워드, Coroutine과 비슷한 개념)
      //해당 키워드는 Task나 Task<T>를 return하는 메소드나 표현식 앞에 사용할 수 있다
      //해당 비동기 작업이 완료될 때까지 현재의 메소드를 중지시킨다
      //작업이 완료되면 다시 해당 메소드를 계속 진행시킨다


      Debug.Log("Process C");
  }
  ```
---
## 유니티의 디자인패턴코드 : Singleton
https://unity.com/kr/resources/level-up-your-code-with-game-programming-patterns

> 공통적으로 사용되는 데이터를 하나의 객체(인스턴스)로 돌려쓴다

> 싱글톤 패턴의 장점은 별도로 가져올 필요없이 바로 사용할 수 있다

> 대신, 싱글톤 패턴으로 설계한 인스턴스가 너무 많은 데이터를 공유하는 경우, 수정이 어렵고 테스트도 까다롭다

---
## C# 일반화 프로그램(Generic Programming) 
> 데이터 형식에 대한 일반화를 진행하는 기법

> <T> 를 이욯해서 설계하는 방식
---
### visual studio 코드작성 중 번개표시로 자동으로 뜨는 부분 : 이벤트
---
### Asset Bundle
> https://docs.unity3d.com/kr/current/Manual/AssetBundlesIntro.html

> 에셋을 묶은 아카이브 파일

> Asset : 유니티에서 쓸 수 있는 데이터(model, texture, audioClip, Material...)
  
> 사용하는 이유? : Application에 다운로드를 진행하기 편하기위함 -> 런타임환경에서 에셋을 불러서 사용할 수 있따

> DLC제공/ 컨텐츠패치/ 모바일게임등에서 초기 인스톨 사이즈 감소(구글 플레이어에 등록할 수 있는 앱의 사이즈가 정해져있어서 내부에서 추가 다운로드 해결)
---
### Asset등록방법
> 에셋등록방법> 프리팹 하단에 AssetBundle> new로 생성(.으로 폴더화 가능)

 > 번들 빌드방법 : 에셋폴더에 Editor폴더를 생성해 스크립트를 작성한다
---
### Addressables
> 패키지매니저> Addressables찾아서 인스톨



