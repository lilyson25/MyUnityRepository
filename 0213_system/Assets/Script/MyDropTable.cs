using UnityEngine;
using System.Collections.Generic; // ???

[CreateAssetMenu(fileName ="MyDropTable", menuName ="DropTable/my drop table", order = 0)]
public class MyDropTable : ScriptableObject
{
    
    public List<string> my_drop_table;
    // 대사들을 저장할 Queue
    public Queue<string> dialogueQueue = new Queue<string>();

          
}
