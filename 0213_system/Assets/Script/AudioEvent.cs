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
        //Invoke�� �̺�Ʈ ����� �Լ�
    }

}
