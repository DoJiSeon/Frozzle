using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Scene_Manager_3 : MonoBehaviour
{
    // ��ư Ŭ���� ȣ��
    public void OnClickStart()
    {
        // Stage_1-3 �ҷ����� (�� ��ȯ)
        SceneManager.LoadScene("Stage_1-3");
    }
}
