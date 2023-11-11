using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // StartSceneManager Ŭ���� ����� ����

public class Start_Scene_Manager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet; //���� ������Ʈ ���
    public GameObject player;

    // ��ư Ŭ���� ȣ��
    public void OnClickStart()
    {
        // 2_PlayScene �ҷ����� (�� ��ȯ)
        SceneManager.LoadScene("N_StageChoose");
    }
    public void GameExit() // ���� ���� �Լ�
    {
        Application.Quit();
    }

    public void resume()
    {
        if (menuSet.activeSelf)
            menuSet.SetActive(false);
        else
            menuSet.SetActive(true);
    }

}
