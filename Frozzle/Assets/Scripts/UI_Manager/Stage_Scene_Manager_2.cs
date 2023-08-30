using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage_Sceen_Manager_2 : MonoBehaviour
{
    // 버튼 클릭시 호출
    public void OnClickStart()
    {
        // Stage_1-2 불러오기 (씬 전환)
        SceneManager.LoadScene("Stage_1-2");
    }
}
