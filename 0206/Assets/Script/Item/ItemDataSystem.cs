using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public Button loadButton;
    public bool interactable;
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
/*    void Start()
    {
        nameInputField.onEndEdit.AddListener(ValueChanged); //유니티 인스펙터에서 보이지 않는다
        loadButton.interactable = interactable; //버튼의 interactable
    }*/


    /*
     * public으로 만든 함수는 유니치 인스펙터에서 직접연결
     * public이 아닌 함수는 스크립트 코드를 통해 기능을 연결해주겠습니다
     */
/*    public void Sample()
    {
        Debug.Log("Input Field's on value changed");
    }




    // 작업이 마무리되었을때 해당문구를 입력했음을 알려주는 함수
    void ValueChanged(string text)
    {
        Debug.Log($"{text} 입력함");
    }
*/
}
