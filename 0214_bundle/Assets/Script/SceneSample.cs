using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.OnScreen;
using UnityEngine.SceneManagement;

public class SceneSample : MonoBehaviour
{
    /*
     * Life Cycle
     * ���۴ܰ���� ����ܰ������ �Լ��� ����
     */
    private void OnEnable() //Ȱ��ȭ �Ǿ��� ���
    { 
        Debug.Log("�� �ε��");
        SceneManager.sceneLoaded += OnScreenLoaded;
    }
    private void OnDisable() //��Ȱ��ȭ �Ǿ��� ���
    {
        Debug.Log("���ε� ������");
        SceneManager.sceneLoaded -= OnScreenLoaded;
    }

    private void OnScreenLoaded(Scene scene, LoadSceneMode mode)
    {
      Debug.Log($"���� �ε�� ���� �̸��� {scene.name}�Դϴ�");
    }

    // 
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene("BRP Sample Scene");
            //�ڵ��ۼ� �� ����ǥ�÷� �ڵ����� �ߴ� �κ� : �̺�Ʈ
            //���� �� ��带 �������� ������, ("�ٲ���̸�", LoadSceneMode.Single)�� ó����

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SceneManager.LoadScene("BRP Sample Scene", LoadSceneMode.Additive);
            //LoadSceneMode.Additive�ϰ�쿡�� ���������� ���ο� ���� �ߺ��ؼ� �ε��ϴ� ����
            //�⺻ ������Ʈ��(maincamera, directionlight��)�� �� �ε�ǰԶ����� �����ؾ���

        }
        if(Input.GetKeyDown(KeyCode.O))
        {

            StartCoroutine("LoadSceneC"); // StartCoroutine(Ÿ������ ǥ���������)

            //SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
            //�񵿱���(async) �ε� : �ε��� ���ÿ� �۾������� ���� ��� -> �������� �ε��۾��̶� �ڷ�ƾȰ���� �ʿ���
            //�Ϲ����� �� �ε��۾��� ���������� ó���� : ���� �ε��Ϸ��������� �ٸ���ҵ��� �۵����� ����
        }   
    }
    IEnumerator LoadSceneC()
    {

        yield return SceneManager.LoadSceneAsync("BRP Sample Scene", LoadSceneMode.Additive);
    }
}
