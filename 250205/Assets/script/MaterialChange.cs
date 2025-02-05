using UnityEngine;

public class MaterialChange : MonoBehaviour
{
    
    public Material skyboxMaterial;
    private bool isSkyboxChanged = false; // Skybox가 변경되었는지 확인하는 변수 (기본값: 변경되지 않음)
    void Start()
    {
        if (skyboxMaterial != null)
            RenderSettings.skybox = skyboxMaterial;
        else
            Debug.LogWarning("설정필요");
    }

    // Update is called once per frame
   public void ChangeSkybox(Material newSkybox)
    {
        if (!isSkyboxChanged && newSkybox != null) // Skybox를 아직 변경하지 않았고, 새로운 Skybox가 존재할 때 실행
        {
            RenderSettings.skybox = newSkybox;// Skybox 변경
            DynamicGI.UpdateEnvironment();  // 변경 사항을 즉시 반영
            isSkyboxChanged = true; //변경되었으므로
            Debug.Log("ok");
        }
        

    }
}
