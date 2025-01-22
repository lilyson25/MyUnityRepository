using System;
using UnityEngine;
[Flags]
public enum Rainbow
{
      //  None = 0,
        빨,
        주,
        노,
        초,
        파,
        남,
        보
}

[AddComponentMenu("SON/Sample01")]
public class ex : MonoBehaviour
{
    public int level;

    public string 과일바구니;

    public string 돈;

    [Range(1, 99)]
    public string 필드뷰;

    public Rainbow;
    //public ;
   private void Star()
    {
        Debug.Log(Rainbow);
    }

}
   // [Tooltip("체크되면 죽은 상태임을 의미")]
   //  public bool isDead = true;