using System;
using UnityEngine;
using UnityEngine.UI;

public class BasicCode2 : MonoBehaviour
{

    /*
## ��ǲ �ʵ忡 ���� �Է��ϰ� ���� ����Ǹ� �ؽ�Ʈ�� �������ִ� �ڵ�

* AddListenerȮ���ϱ�
    */

    public InputField inputField;
    public Text text;
    
    private void Start()
    {
        inputField.onValueChanged.AddListener(inputText); 
    }

    private void inputText(string arg0)
    {
       text.text = arg0;
    }
}
