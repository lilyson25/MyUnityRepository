using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class AudioEvent : ScriptableObject
{
   
    public event Action<String> OnPlay;

    public void Play(string name)
    {

        if(OnPlay != null)
            OnPlay.Invoke(name);
        //Invoke는 이벤트 실행용 함수
    }

}
