using UnityEngine;
[System.Serializable]
public class SampleData
{
    public int i;
    public float f;
    public bool b;
    public Vector3 v;
    public string s;
    public int[] iArray;
   
}

public class JsonEX : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SampleData sampleData = new SampleData();
        sampleData.i = 0;
        sampleData.f = 1.0f;
        sampleData.b = false;
        sampleData.v = Vector3.zero;
        sampleData.s = "hi";
        sampleData.iArray = new int[] { 1, 2, 3, 4, 5 };

        string json_data = JsonUtility.ToJson(sampleData);
        Debug.Log(json_data);   

        //json_data 통해 전달받은 값으로 만든 SampleData오브젝트
        var Sampledata2 = JsonUtility.FromJson<SampleData>(json_data);


        Debug.Log(Sampledata2.s);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
