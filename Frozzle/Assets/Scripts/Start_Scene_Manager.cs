using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // StartSceneManager Ŭ���� ����� ����

public class Start_Scene_Manager : MonoBehaviour
{
    // ��ư Ŭ���� ȣ��
    public void OnClickStart()
    {
        // 2_PlayScene �ҷ����� (�� ��ȯ)
        SceneManager.LoadScene("2_StoryStartScene");
    }
}
