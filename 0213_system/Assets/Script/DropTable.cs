using UnityEngine;
using System.Collections.Generic; // ???

/* 
 * ### CreateAssetMenu
 * ()에 filename, menuname, order를 설정할 수 잇음
 * filename : 생성되는 에셋의 이름
 * menuname : create를 통해 만들어지는 메뉴의 이름을 설정
 * /를 넣을 경우 경로가 추가됨
 * order : 메뉴중에서 몇번째 위치에 존재할 지 표시할때 설정하는 값,
 * 값이 클수록 마지막에 표기
 */

[CreateAssetMenu(fileName ="DropTable", menuName ="DropTable/drop table", order = 0)]
public class DropTable : ScriptableObject
{
    // List는 배열과 같은 문법
    public List<GameObject> mydrop_table;
}
