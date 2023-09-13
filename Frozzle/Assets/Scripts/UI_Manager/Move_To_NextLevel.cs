using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Move_To_Level : MonoBehaviour
{
    public int nextSceneLoad;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }
    public void OnClickStart()
    {
            //다음 레벨로 이동
            SceneManager.LoadScene(nextSceneLoad);

            //Setting Int for Index
            if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneLoad);
            }
    }
}
