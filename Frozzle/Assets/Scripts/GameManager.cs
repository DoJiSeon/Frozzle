using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet; //게임 오브젝트 사용
    public GameObject player;
    void Start()
    {
        GameLoad();
    }

    void Update()
    {
        // esc 눌렀을 때, 서브메뉴 창 키고 끄기
        if (Input.GetButtonDown("Cancel"))
        { 
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);

        }
    }

    public void GameExit() // 게임 종료 함수
    {
        Application.Quit();
    }

    public void GameSave()
    {
        if (!PlayerPrefs.HasKey("player_pos"))
            return;

        PlayerPrefs.SetFloat("player_pos", player.transform.position.x);
        PlayerPrefs.SetFloat("player_pos", player.transform.position.y);
        PlayerPrefs.Save();

        // 기믹의 진행 상태도 저장해야 함

        menuSet.SetActive(false);
    }
    
    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("player_pos");
        float y = PlayerPrefs.GetFloat("player_pos");

        player.transform.position = new Vector3(x, y, 0);
    }
}
