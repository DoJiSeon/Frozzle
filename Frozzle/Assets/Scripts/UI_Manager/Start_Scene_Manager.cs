using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // StartSceneManager 클래스 사용을 위해

public class Start_Scene_Manager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet; //게임 오브젝트 사용
    public GameObject player;

    // 버튼 클릭시 호출
    public void OnClickStart()
    {
        // 2_PlayScene 불러오기 (씬 전환)
        SceneManager.LoadScene("N_StageChoose");
    }
    public void GameExit() // 게임 종료 함수
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
