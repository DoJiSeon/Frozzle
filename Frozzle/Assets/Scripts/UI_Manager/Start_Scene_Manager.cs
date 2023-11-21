using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // StartSceneManager Ŭ���� ����� ����

public class Start_Scene_Manager : MonoBehaviour
{
    // ��ư Ŭ���� ȣ��
    public Image fader;

    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
        if (fader)
        {
            fader.enabled = false;
        }
        PlayerPrefs.SetInt("memory", 0);
        PlayerPrefs.SetInt("enteredStage", 0);
        PlayerPrefs.SetInt("clear_stage", 0);

    }
    public void OnClickStart()
    {
        // preTutorial �ҷ����� (�� ��ȯ)
        Debug.Log("this is");
        StartCoroutine(nextScene());
    }
    public void GameExit() // ���� ���� �Լ�
    {
        Application.Quit();
    }
    
    IEnumerator nextScene()
    {
        Debug.Log("Hello");
        float fadeCount = 0;
        fader.enabled = true;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("preTutorial");
    }
}
