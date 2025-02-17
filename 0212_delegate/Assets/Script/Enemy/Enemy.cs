using UnityEngine;

// 인터페이스는 "I"를 붙이는 것이 일반적인 명명 규칙
public interface IEnemy
{
    void Action();
}

// Goblin 클래스는 IEnemy 인터페이스를 구현 (오버라이드)
public class Goblin : IEnemy
{
    public void Action() // 세미콜론(;) 제거
    {
        Debug.Log("고블린이 공격한다");
    }
}

// Slime 클래스도 IEnemy 인터페이스를 구현
public class Slime : IEnemy
{
    public void Action()
    {
        Debug.Log("슬라임이 공격한다");
    }
}

// Wolf 클래스도 IEnemy 인터페이스를 구현
public class Wolf : IEnemy
{
    public void Action()
    {
        Debug.Log("늑대가 공격한다");
    }
}
