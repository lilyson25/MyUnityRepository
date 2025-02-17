using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    public enum ENEMYTYPE
    {
        Goblin,Slime,Wolf
    }

    public IEnemy Create(ENEMYTYPE type) //Factory���� �ٷ�� ������ ���¸� return�ϴ� �ڵ� : ������ ��ü�� ����ǥ�� 'type'
    {
        switch (type)
        {
            case ENEMYTYPE.Goblin: return new Goblin();
            case ENEMYTYPE.Slime: return new Slime();
            case ENEMYTYPE.Wolf: return new Wolf();
            default: throw new System.ArgumentException("��������"); //��ȸ��Ȳ�߻�(������ ����� �ȵ�)


        }
    }
}
