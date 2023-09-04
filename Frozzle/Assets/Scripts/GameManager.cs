using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text talkText;
    public GameObject scanObject;
    public GameObject menuSet; //���� ������Ʈ ���
    public GameObject player;
    void Start()
    {
        GameLoad();
    }

    void Update()
    {
        // esc ������ ��, ����޴� â Ű�� ����
        if (Input.GetButtonDown("Cancel"))
        { 
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);

        }
    }

    public void GameExit() // ���� ���� �Լ�
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

        // ����� ���� ���µ� �����ؾ� ��

        menuSet.SetActive(false);
    }
    
    public void GameLoad()
    {
        float x = PlayerPrefs.GetFloat("player_pos");
        float y = PlayerPrefs.GetFloat("player_pos");

        player.transform.position = new Vector3(x, y, 0);
    }
}
