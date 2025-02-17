using System;
using UnityEngine;

/*
## 퀘스트 시스템 만들기
> 게임내에서 특정상황에서 맞춰서 시작하게 하는 조건 또는 요구 사항등을 의미합니다
> 변경될 일이 없기에 데이터의 경우 SO로 저장하면 편리함 

* 퀘스트를 구현할 때 필요한 최소한의 것들
  - 1. 퀘스트 진행조건
    - ex)플레이어의 레벨/ 특정아이템을 가지고 있을 것/ 다른 특정 퀘스트를 진행했을경우 진행가능

  - 2. 퀘스트를 진행하는 방식
    - ex)특정 NPC와 대화를 진행한다/ 특정아이템을 획득한다(보석10개를 수집)/ 

  - 3. 퀘스트의 보상
    - ex)돈, 아이템..

## 퀘스트 유형
> 일반퀘스트 : 클리어하면 더이상 깰 수 없다
> 데일리 퀘스트 : 매일을 기준으로 퀘스트가 갱신됨
> 위클리 퀘스트 : 주를 기준으로 퀘스트가 갱신됨

 */


public enum QuestType //enum으로 사용하면 편리한 점?
{
    normal,daily,weekly

}
[CreateAssetMenu(fileName = "Quest", menuName = "Quest/quest")]
public class Quest : ScriptableObject 
{
   
    public QuestType 퀘스트유형;
    public Reward 보상;
    public Requirement 요구조건;

    [Header("퀘스트 정보")]
    public string 제목;
    public string 목표;
    [TextArea] 
    public string 설명;

    public bool 성공;
    public bool 진행상태;
}
//요구조건에 대한 스크립터블 오브젝트 생성
[CreateAssetMenu(fileName ="Requirement", menuName ="Quest/Requirment")]
public class Requirement : ScriptableObject
{
    public int 목표몬스터;
    public int 현재잡은몬스터의수;
}

[Serializable]
[CreateAssetMenu(fileName = "Reward", menuName = "Quest/Reward")]
public class Reward : ScriptableObject
{
    public int money;
    public int exp;
}