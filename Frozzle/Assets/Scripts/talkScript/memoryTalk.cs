using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class memoryTalk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public Image fader;
    public List<Image> imageList;
    public List<string> textList = new List<string>();

    bool autoStart = false;
    bool isClickable = true;

    public float delay;

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
        Debug.Log(isClickable);
        if (Input.GetMouseButtonDown(0) || autoStart) 
        {
            autoStart = false;
            if (clickCount == 0 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            } else if (clickCount == 1 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 2 && isClickable)
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
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 4 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 5 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 6 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 7 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 8 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 9 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 10 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 11 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 12 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 13 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 14 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                StartCoroutine(ImageFadeIn(7));
                clickCount++;
            }
            else if (clickCount == 15 && isClickable)
            {
                StartCoroutine(ImageFadeIn(0));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 16 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 17 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 18 && isClickable)
            {
                StartCoroutine(ImageFadeIn(1));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 19 && isClickable)
            {
                StartCoroutine(ImageFadeIn(2));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 20 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 21 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 22 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 23 && isClickable)
            {
                StartCoroutine(ImageFadeIn(3));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 24 && isClickable)
            {
                StartCoroutine(ImageFadeIn(4));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 25 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 26 && isClickable)
            {
                StartCoroutine(ImageFadeIn(5));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 27 && isClickable)
            {
                StartCoroutine(ImageFadeIn(8));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 28 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 29 && isClickable)
            {
                StartCoroutine(ImageFadeIn(6));
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 30 && isClickable)
            {
                StartCoroutine(ImageAllFadeOut());
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 31 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 32 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 33 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 34 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 35 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 36 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 37 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 38 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 39 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 40 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 41 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 42 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 43 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 44 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 45 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 46 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 47 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 48 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 49 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 50 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 51 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 52 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 53 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 54 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 55 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 56 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 57 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 58 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 59 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 60 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 61 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 62 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 63 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "Ä®¸®¿ò";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 64 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 65 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                nameTagInnerText.text = "ÄÝµå";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount > 65 && isClickable)
            {
                talkPanel.SetActive(false);
                PlayerPrefs.SetInt("memory", 1);
                StartCoroutine(nextFade("tutorial"));
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

    IEnumerator cutSceneStartSentenceSequence(string text_)
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
        StartCoroutine(fadeOut());
        isClickable = true;
    }

    IEnumerator nextSentenceSequence(string text_, string nextStage)
    {
        skip_seq = nextSkipSequence(seq, text_, nextStage);
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
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(nextFade(nextStage));
    }

    IEnumerator skipSequence(IEnumerator seq_, string text_)
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StopCoroutine(seq_);
        text.text = text_;
        isClickable = true;
    }

    IEnumerator nextSkipSequence(IEnumerator seq_, string text_, string nextStage)
    {
        yield return new WaitForSeconds(0.3f);
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StopCoroutine(seq_);
        text.text = text_;
        isClickable = true;
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));
        StartCoroutine(nextFade(nextStage));
    }
    IEnumerator fadeOut()
    {
        isClickable = false;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        isClickable = true;
    }

    IEnumerator ImageAllFadeOut()
    {
        float imageFadeOutCount = 1;
        int rgb = 255;
        while (imageFadeOutCount > 0)
        {
            imageFadeOutCount -= 0.05f;
            for (int i = 0; i < 9; i++ )
            {
                if (i >= 7)
                {
                    rgb = 0;
                } else
                {
                    rgb = 255;
                }
                imageList[i].color = new Color(rgb, rgb, rgb, imageFadeOutCount);
            }
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator ImageFadeIn(int index)
    {
        float imageFadeCount = 0;
        int rgb = 255;
        if (index >= 7)
        {
            rgb = 0;
        }
        isClickable = false;
        while (imageFadeCount < 1.0f)
        {
            imageFadeCount += 0.025f;
            yield return new WaitForSeconds(0.01f);
            imageList[index].color = new Color(rgb, rgb, rgb, imageFadeCount);
        }
    }


    IEnumerator nextFade(string nextStage)
    {
        isClickable = false;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        isClickable = true;
        SceneManager.LoadScene(nextStage);

    }
}
