using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class preTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public Image fader;
    public List<string> textList = new List<string>();
    int clickCount = 0;
    float fadeCount = 1.0f;
    bool isClickable = true;

    IEnumerator seq;
    IEnumerator skip_seq;

    public float delay;
    void Start()
    {
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
        StartCoroutine(fadeIn());
    }

    // Update is called once per frame
    void Update()
    {
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
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if(clickCount == 2 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 3 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                StartCoroutine(fadeOut());
                clickCount++;
            }
            else if  (clickCount == 4 && isClickable)
            {
                talkPanel.SetActive(true);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount >= 5 && isClickable)
            {
                talkPanel.SetActive(false);
                StartCoroutine(nextScene("tutorial"));
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

    IEnumerator fadeIn()
    {
        isClickable = false;
        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.0001f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        isClickable = true;
    }

    IEnumerator fadeOut()
    {
        isClickable = false;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.0001f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        isClickable = true;
    }

    IEnumerator nextScene(string nextScene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nextScene);
    }

 }
