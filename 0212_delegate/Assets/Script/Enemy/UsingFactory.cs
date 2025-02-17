using UnityEngine;

public class UsingFactory : MonoBehaviour
{
    
    EnemyFactory enemyFactory = new EnemyFactory();
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IEnemy enemy = enemyFactory.Create(EnemyFactory.ENEMYTYPE.Goblin);
        enemy.Action();
        IEnemy enemy2 = enemyFactory.Create(EnemyFactory.ENEMYTYPE.Slime);
        enemy.Action();
        IEnemy enemy3 = enemyFactory.Create(EnemyFactory.ENEMYTYPE.Wolf);
        enemy.Action();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
