using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Sceen_Manager_1 : MonoBehaviour
{
    // ��ư Ŭ���� ȣ��
    public void OnClickStart()
    {
        // Stage_1-1 �ҷ����� (�� ��ȯ)
        SceneManager.LoadScene("Stage_1-1");
    }
}
