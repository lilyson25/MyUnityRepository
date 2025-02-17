/*
using UnityEngine;

*//*
 * using System을 사용하면서 유니티의 랜덤을 사용하고 싶은경우
   - using Random = UnityEngine.Random;
 *//*

public class Enemy : MonoBehaviour
{
    // 에너미의 드랍 테이블
    public DropTable DropTable; 
   
    // 
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.X))
        {
            Dead();
        }      
    }

    private void Dead()
    {
       GameObject dropItemPrefab = DropTable.drop_table[Random.Range(0, DropTable.drop_table.Count)];
        //Random.Range(최소, 최대)는 유니티에서 제공해주는 랜덤 분법
        //최소값부터 최대 -1까지의 범위의 값 중 하나를 랜덤으로 선택합니다

        
        Instantiate(dropItemPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject); //delay로 일정기간 후 죽는걸로 연출가능
    }
}
*/