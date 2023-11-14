using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_ : MonoBehaviour
{

    public Button[] levelButtons;


    // Start is called before the first frame update
    void Start()
    {

        //int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        //for (int i =  0; i < levelButtons.Length; i++)
        //{
        //        if(i + 2 > levelAt)
        //        levelButtons[i].interactable = false;
        //}
        //PlayerPrefs.DeleteAll();

        levelButtons[0].interactable = true;
        int clear_level = PlayerPrefs.GetInt("clear_stage", 0);
        PlayerPrefs.DeleteKey("clear_stage1");
        for (int i = 1; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        Debug.Log(PlayerPrefs.GetInt("clear_stage", 0));
    }
    private void Update()
    {
        int clear_level = PlayerPrefs.GetInt("clear_stage", 0);
        for (int i = 0; i <= clear_level; i++)
        {
            if (clear_level != 3)
            {
                levelButtons[i].interactable = true;
            }
            else if (clear_level == 3)
            {
                levelButtons[0].interactable = true;
                levelButtons[1].interactable = true;
                levelButtons[2].interactable = true;
            }
        }
    }
}