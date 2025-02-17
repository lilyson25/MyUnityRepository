using UnityEngine;
using System.Collections.Generic; // ???

[CreateAssetMenu(fileName ="MyDropTable", menuName ="DropTable/my drop table", order = 0)]
public class MyDropTable : ScriptableObject
{
    
    public List<string> my_drop_table;
    // ������ ������ Queue
    public Queue<string> dialogueQueue = new Queue<string>();

          
}
