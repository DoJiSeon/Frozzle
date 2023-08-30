using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // StartSceneManager 클래스 사용을 위해

public class Start_Scene_Manager : MonoBehaviour
{
    // 버튼 클릭시 호출
    public void OnClickStart()
    {
        // 2_PlayScene 불러오기 (씬 전환)
        SceneManager.LoadScene("2_StoryStartScene");
    }
}
