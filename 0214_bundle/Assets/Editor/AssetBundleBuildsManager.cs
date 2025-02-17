using UnityEngine;
using System.IO; //폴더 확인하기 위한 선언
using UnityEditor;

public class AssetBundleBuildsManager : MonoBehaviour
{
    //에디터에 메뉴를 등록해주는 기능
    [MenuItem("Asset Bundle")]
    public static void AssetBundleBuild() //전체공개됨
    {
        //현재 번들의 위치
        string directory = "./Bundle";


        //해당 디렉토리가 존재하지 않는다면
        if (!Directory.Exists(directory)) 
        {
        Directory.CreateDirectory(directory);
        }
        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        //해당 경로에 에셋 번들에 대한 설정과 필드 플랫폼을 설정해서 빌드를 진행하는 코드

        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle build completed!!", "complete");
    }
   
}
