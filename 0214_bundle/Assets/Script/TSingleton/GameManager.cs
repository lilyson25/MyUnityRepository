using UnityEngine;

public class GameManager : TSingletone<GameManager> //������� ����������, ���࿡ ���� �ڵ常 �־��ָ� �ȴ�
{
    public int score;
    public void ScorePlus() => score++;
}
