using System.IO;
using UnityEngine;
/*Json �����
1. ���� �� �ִ� ������ ���·� �������
2. ���ϰ�� ������� json������ ã�� ������ �ؽ�Ʈ�� �о
3. �о �����͸� ���� Ŭ����ȭ ��


*/
[System.Serializable]
public class Item01
{
    public string name;
    public string description;

}
public class JsonLoad : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string Load_json = File.ReadAllText(Application.dataPath + "/item01.json");
        //�۾������� �ǹ�
        var data = JsonUtility.FromJson<Item01>(Load_json);//�츮�� �����ؼ� ����� �� �ִ� �����ͷ� ������
        Debug.Log(data.name);

        data.name = "�����";
        data.description = "�����2";

        File.WriteAllText(Application.dataPath + "/item01.json", JsonUtility.ToJson(data));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
