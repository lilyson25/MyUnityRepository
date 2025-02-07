using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class InputItems : MonoBehaviour
{
    [Header("��ǲ �ʵ�")]
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputfield;
    [Header("��ư")]
    public Button saveBt;
    public Button loadBt;
    public Button deleteBt;
    [Header("����������")]
    public InputData itemsName;
    public InputData itemsInfo;

    public string temp_name;
    public string temp_description;

    void Start()
    {
        // �Է� �ʵ忡�� �ؽ�Ʈ�� �Է��ϰ� ������ �� ȣ��Ǵ� �Լ� ����
        nameInputField.onEndEdit.AddListener(NameChanged); // �̸� �Է� ����
        descriptionInputfield.onEndEdit.AddListener(DescriptionChanged); // ���� �Է� ����

        loadBt.interactable = false;
        // ��ư Ŭ�� �� ����� �Լ� ����
        loadBt.onClick.AddListener(LoadData); // ������ �ҷ����� ��ư Ŭ�� ��
        saveBt.onClick.AddListener(SaveData);
        deleteBt.onClick.AddListener(DeleteData);
    }

    private void Update()
    {
        LoadCheck();
    }
    void NameChanged(string text) => temp_name = text; // �̸��� ����� �� ȣ��Ǵ� �Լ�
    void DescriptionChanged(string text) => temp_description = text;
    //void DeleteData() => PlayerPrefs.DeleteAll(); // PlayerPrefs�� ����� �����͸� �����ϴ� �Լ�
    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        // ȭ�鿡 �ѷ��� �ؽ�Ʈ�� ���� (�� ���ڿ��� �ʱ�ȭ)
        itemsName.text = $"������ �̸� : {""}";  // ������ �̸� �ؽ�Ʈ �ʱ�ȭ
        itemsInfo.text = $"������ ���� : {""}";  // ������ ���� �ؽ�Ʈ �ʱ�ȭ
    }
    void SaveData()
    {
        if (temp_name != "" && temp_description != "") // �̸��� ������ ������� ������ ������ ����
        {
            PlayerPrefs.SetString("ItemName", temp_name);
            PlayerPrefs.SetString("ItemDescription", temp_description);
        }

        else
        {
            Debug.Log("������ �Է����ּ���");

        }
    }
    void LoadData()// �����͸� �ҷ����� �Լ�
    {
        itemsName.text = $"������ �̸� : {PlayerPrefs.GetString("ItemName")}";  // PlayerPrefs�� ����� �����͸� �ҷ��� �ؽ�Ʈ�� ǥ��
        itemsInfo.text = $"������ ���� : {PlayerPrefs.GetString("ItemDescription")}";


    }
    void LoadCheck()// ����� �����Ͱ� �ִ��� Ȯ���ϴ� �Լ�
    {
        if (PlayerPrefs.HasKey("ItemName") && PlayerPrefs.HasKey("ItemDescription"))
        {
            loadBt.interactable = true;
        }
        else
        {
            loadBt.interactable = false;
        }
    }
}