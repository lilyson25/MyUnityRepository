using System;
using UnityEngine;
[Flags]
public enum Rainbow
{
      //  None = 0,
        ��,
        ��,
        ��,
        ��,
        ��,
        ��,
        ��
}

[AddComponentMenu("SON/Sample01")]
public class ex : MonoBehaviour
{
    public int level;

    public string ���Ϲٱ���;

    public string ��;

    [Range(1, 99)]
    public string �ʵ��;

    public Rainbow;
    //public ;
   private void Star()
    {
        Debug.Log(Rainbow);
    }

}
   // [Tooltip("üũ�Ǹ� ���� �������� �ǹ�")]
   //  public bool isDead = true;