using UnityEngine;
using System.Collections.Generic; // ???

/* 
 * ### CreateAssetMenu
 * ()�� filename, menuname, order�� ������ �� ����
 * filename : �����Ǵ� ������ �̸�
 * menuname : create�� ���� ��������� �޴��� �̸��� ����
 * /�� ���� ��� ��ΰ� �߰���
 * order : �޴��߿��� ���° ��ġ�� ������ �� ǥ���Ҷ� �����ϴ� ��,
 * ���� Ŭ���� �������� ǥ��
 */

[CreateAssetMenu(fileName ="DropTable", menuName ="DropTable/drop table", order = 0)]
public class DropTable : ScriptableObject
{
    // List�� �迭�� ���� ����
    public List<GameObject> mydrop_table;
}
