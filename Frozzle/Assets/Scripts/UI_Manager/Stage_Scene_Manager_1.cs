using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Sceen_Manager_1 : MonoBehaviour
{
    // 버튼 클릭시 호출
    public void OnClickStart()
    {
        // Stage_1-1 불러오기 (씬 전환)
        SceneManager.LoadScene("Stage_1-1");
    }
}
