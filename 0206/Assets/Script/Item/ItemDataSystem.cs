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
        nameInputField.onEndEdit.AddListener(ValueChanged); //����Ƽ �ν����Ϳ��� ������ �ʴ´�
        loadButton.interactable = interactable; //��ư�� interactable
    }*/


    /*
     * public���� ���� �Լ��� ����ġ �ν����Ϳ��� ��������
     * public�� �ƴ� �Լ��� ��ũ��Ʈ �ڵ带 ���� ����� �������ְڽ��ϴ�
     */
/*    public void Sample()
    {
        Debug.Log("Input Field's on value changed");
    }




    // �۾��� �������Ǿ����� �ش繮���� �Է������� �˷��ִ� �Լ�
    void ValueChanged(string text)
    {
        Debug.Log($"{text} �Է���");
    }
*/
}
