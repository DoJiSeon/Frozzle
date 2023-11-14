using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class go_to_tester : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStart_s()
    {
        SceneManager.LoadScene("PlayerMoveTester");
    }

}
