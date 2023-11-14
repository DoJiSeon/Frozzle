using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class reset_clear_stage : MonoBehaviour
{
    public void OnClickStart()
    {
        PlayerPrefs.SetInt("clear_stage", 0);
        Debug.Log(PlayerPrefs.GetInt("clear_stage"));
    }
}