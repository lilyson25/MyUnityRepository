using TMPro;
using UnityEditor.Overlays;
using UnityEngine;
using UnityEngine.UI;

public class InputItems : MonoBehaviour
{
    [Header("인풋 필드")]
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputfield;
    [Header("버튼")]
    public Button saveBt;
    public Button loadBt;
    public Button deleteBt;
    [Header("아이템정보")]
    public InputData itemsName;
    public InputData itemsInfo;

    public string temp_name;
    public string temp_description;

    void Start()
    {
        // 입력 필드에서 텍스트를 입력하고 끝냈을 때 호출되는 함수 설정
        nameInputField.onEndEdit.AddListener(NameChanged); // 이름 입력 변경
        descriptionInputfield.onEndEdit.AddListener(DescriptionChanged); // 설명 입력 변경

        loadBt.interactable = false;
        // 버튼 클릭 시 실행될 함수 설정
        loadBt.onClick.AddListener(LoadData); // 데이터 불러오기 버튼 클릭 시
        saveBt.onClick.AddListener(SaveData);
        deleteBt.onClick.AddListener(DeleteData);
    }

    private void Update()
    {
        LoadCheck();
    }
    void NameChanged(string text) => temp_name = text; // 이름이 변경될 때 호출되는 함수
    void DescriptionChanged(string text) => temp_description = text;
    //void DeleteData() => PlayerPrefs.DeleteAll(); // PlayerPrefs에 저장된 데이터를 삭제하는 함수
    void DeleteData()
    {
        PlayerPrefs.DeleteAll();
        // 화면에 뿌려진 텍스트도 삭제 (빈 문자열로 초기화)
        itemsName.text = $"아이템 이름 : {""}";  // 아이템 이름 텍스트 초기화
        itemsInfo.text = $"아이템 설명 : {""}";  // 아이템 설명 텍스트 초기화
    }
    void SaveData()
    {
        if (temp_name != "" && temp_description != "") // 이름과 설명이 비어있지 않으면 데이터 저장
        {
            PlayerPrefs.SetString("ItemName", temp_name);
            PlayerPrefs.SetString("ItemDescription", temp_description);
        }

        else
        {
            Debug.Log("내용을 입력해주세요");

        }
    }
    void LoadData()// 데이터를 불러오는 함수
    {
        itemsName.text = $"아이템 이름 : {PlayerPrefs.GetString("ItemName")}";  // PlayerPrefs에 저장된 데이터를 불러와 텍스트에 표시
        itemsInfo.text = $"아이템 설명 : {PlayerPrefs.GetString("ItemDescription")}";


    }
    void LoadCheck()// 저장된 데이터가 있는지 확인하는 함수
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