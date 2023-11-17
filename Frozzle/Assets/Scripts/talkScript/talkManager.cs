using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class talkManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public List<string> textList = new List<string>();
    int clickCount = 0;
    bool isClickable = true;

    IEnumerator seq;
    IEnumerator skip_seq;

    public float delay;
    void Start()
    {
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(textList.Count);
        if (Input.GetMouseButtonDown(0))
        {
            if (clickCount == 0 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 1 && isClickable)
            {
                nameTag.SetActive(true);
                nameTagInnerText.text = "???";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount >= textList.Count && isClickable)
            {
                talkPanel.SetActive(false);
            }
        }
    }

    IEnumerator sentenceSequence(string text_)
    {
        skip_seq = skipSequence(seq, text_);
        StartCoroutine(skip_seq);
        isClickable = false;
        text.text = "";
        foreach (char letter in text_)
        {
            text.text += letter;
            yield return new WaitForSeconds(delay);
        }
        StopCoroutine(skip_seq);
        isClickable = true;
    }

    IEnumerator skipSequence(IEnumerator seq_, string text_)
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StopCoroutine(seq_);
        text.text = text_;
        isClickable = true;
    }
}
