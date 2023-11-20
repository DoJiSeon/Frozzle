using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class N_StageChoose : MonoBehaviour
{
    public void OnClickStart()
    {
        SceneManager.LoadScene("tutorial");
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
