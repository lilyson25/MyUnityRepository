using UnityEngine;

public class GameManager : TSingletone<GameManager> //상속으로 연결했으니, 실행에 대한 코드만 넣어주면 된다
{
    public int score;
    public void ScorePlus() => score++;
}
