using UnityEngine;
using System.IO; //���� Ȯ���ϱ� ���� ����
using UnityEditor;

public class AssetBundleBuildsManager : MonoBehaviour
{
    //�����Ϳ� �޴��� ������ִ� ���
    [MenuItem("Asset Bundle")]
    public static void AssetBundleBuild() //��ü������
    {
        //���� ������ ��ġ
        string directory = "./Bundle";


        //�ش� ���丮�� �������� �ʴ´ٸ�
        if (!Directory.Exists(directory)) 
        {
        Directory.CreateDirectory(directory);
        }
        BuildPipeline.BuildAssetBundles(directory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);
        //�ش� ��ο� ���� ���鿡 ���� ������ �ʵ� �÷����� �����ؼ� ���带 �����ϴ� �ڵ�

        EditorUtility.DisplayDialog("Asset Bundle Build", "Asset Bundle build completed!!", "complete");
    }
   
}
