# Audio Mixer
 > 오디오 소스에 대한 제어, 균형, 조정을 제공하는 도구

* 믹서만드는 법
  * Creat > Audio> AudioMixer를 통해 AudioGroup 생성
  * 최초 생성시 Master그룹이 존재
  * groups>생성된그룹> atenuation> 마우스 오른쪽눌러서 expose 해주고 맞춤설정
  * Exposed Parameters에서 rename을해서 생성한 그룹의 네이밍과 같이 설정
  * emptyO브젝트를 생성하고, 컴포넌트를 2개 생성해서 각각의 그룹과 각각의 음악으로 설정
 
# 자주사용되는 Mathf함수
* 1. Mathf.Deg2Rad
  degree(60분법)을 통해 radian(호도법)을 계산하는 코드 --> 각도 계산 코드
  PI/180 또는 pi*2 / 360
         
* 2. Mathf.Rad2Deg
  라디안 값을 디그리 값으로 바꿔줌
  360/ (pi*2)
  1라디안은 약 57도

* 3. Mathf.Abs
  절대값을 계산해주는 기능

* 4. Mathf.Athan
  아크 탄젠트 값을 계산

* 5. Mathf.ceil
  소수점 올림 계산

* 6. Mathf.Clamp(value, min, max) --> 가장자주사용됨
  value를 main과 max사이의 값으로 고정
 
* 7. Mathf.Log10
  베이스가 10으로 지정되어있는 수의 로그를 반환해주는 기능
  ex) Debug.Log(Mathf.Log10(100))

이번 예제에서는 오디오 믹서의 최소 ~ 최대 볼륨 값 때문에 로그 함수가 사용됨
최소가 -80, 최대가 0
수치변경시 Mathf.Log10(슬라이더 수치) * 20);을 통해 범위를 설정하고
슬라이더의 최소 값이 0.01일 경우 -80이 1일 경우 0이 계산됨


# 유니티 에디터에서 GUI를 보여주는 시스템
>using UnityEngine.UI / using UnityEngine.UIElements
* IMGUI 디버그에서 사용
* UGUI 일반적으로 사용되는 UI도구
* UIElements 에디터 기반으로 진행하는 도구

