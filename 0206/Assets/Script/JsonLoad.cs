using System.IO;
using UnityEngine;
/*Json 사용방법
1. 읽을 수 있는 데이터 형태로 만들어줌
2. 파일경로 기반으로 json파일을 찾아 내부의 텍스트를 읽어냄
3. 읽어낸 데이터를 통해 클래스화 함


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
        //작업폴더를 의미
        var data = JsonUtility.FromJson<Item01>(Load_json);//우리가 편집해서 사용할 수 있는 데이터로 가져옴
        Debug.Log(data.name);

        data.name = "변경됨";
        data.description = "변경됨2";

        File.WriteAllText(Application.dataPath + "/item01.json", JsonUtility.ToJson(data));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
