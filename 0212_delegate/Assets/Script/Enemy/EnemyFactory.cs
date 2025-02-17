using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE
    {
        Goblin,Slime,Wolf
    }

    public IEnemy Create(ENEMYTYPE type) //Factory에서 다루는 데이터 형태를 return하는 코드 : 생성할 객체의 형태표현 'type'
    {
        switch (type)
        {
            case ENEMYTYPE.Goblin: return new Goblin();
            case ENEMYTYPE.Slime: return new Slime();
            case ENEMYTYPE.Wolf: return new Wolf();
            default: throw new System.ArgumentException("생성실패"); //예회상황발생(생성이 제대로 안됨)


        }
    }
}
