using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject menuSet; //게임 오브젝트 사용

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
