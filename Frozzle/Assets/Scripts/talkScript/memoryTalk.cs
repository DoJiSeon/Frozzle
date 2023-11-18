using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class memoryTalk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public Image fader;
    public List<string> textList = new List<string>();

    bool autoStart = false;
    bool isClickable = true;

    int clickCount = 0;
    float fadeCount = 1.0f;

    IEnumerator seq;
    IEnumerator skip_seq;
    void Start()
    {
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || autoStart) 
        {
            autoStart = false;
            if (clickCount == 0 && isClickable)
            {

            }
        }
    }

    IEnumerator fadeIn()
    {
        isClickable = false;
        while (fadeCount > 0)
        {
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(0.5f);
        autoStart = true;
        isClickable = true;
    }
}
