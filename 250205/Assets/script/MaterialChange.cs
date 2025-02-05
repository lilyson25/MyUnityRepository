using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    
    public Material skyboxMaterial;
    private bool isSkyboxChanged = false; // Skybox�� ����Ǿ����� Ȯ���ϴ� ���� (�⺻��: ������� ����)
    void Start()
    {
        if (skyboxMaterial != null)
            RenderSettings.skybox = skyboxMaterial;
        else
            Debug.LogWarning("�����ʿ�");
    }

    // Update is called once per frame
   public void ChangeSkybox(Material newSkybox)
    {
        if (!isSkyboxChanged && newSkybox != null) // Skybox�� ���� �������� �ʾҰ�, ���ο� Skybox�� ������ �� ����
        {
            RenderSettings.skybox = newSkybox;// Skybox ����
            DynamicGI.UpdateEnvironment();  // ���� ������ ��� �ݿ�
            isSkyboxChanged = true; //����Ǿ����Ƿ�
            Debug.Log("ok");
        }
        

    }
}
