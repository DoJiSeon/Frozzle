using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class cutSceneTalk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public TextMeshProUGUI subText;
    public List<Image> images = new List<Image>();

    int clickCount = 0;
    float fadeCount = 0;
    float fadeCountOut = 1.0f;

    bool dialog = false;
    bool isClickable = true;
    bool autoStart = true;

    IEnumerator seq;
    IEnumerator skip_seq;

    public float delay;

    void Start()
    {
        talkPanel.SetActive(false);
        subText.enabled = true;
        StartCoroutine(cutScene());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(dialog);
        if (dialog)
        {
            Debug.Log("entered");
            subText.enabled = false;
            if (Input.GetMouseButtonDown(0) || autoStart) {
                autoStart = false;
                if (clickCount == 0 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("기억이 돌아왔어?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("(콜드는 소리없이 울며 고개를 끄덕였다.)");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("...걸을 수는 있지?");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 3 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("나를 따라와줘. 데려가고 싶은 데가 있어.");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 4 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("(콜드는 말없이 무거운 발걸음으로 칼리움을 따라갔다.");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount > 4 && isClickable)
                {
                    talkPanel.SetActive(false);
                    StartCoroutine(nextScene());
                }
            }
        }
    }

    IEnumerator nextScene()
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("memory");
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

    IEnumerator cutScene()
    {
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(imageFade(0));
        subText.enabled = true;
        subText.text = "어느 화창한 날, 멜트린에서 푸른 눈을 가진 소녀, 콜드가 태어났다.";
        yield return new WaitForSeconds(5f);
        subText.text = "멜트린 사람들은 모두 검붉은 눈을 가지고 태어나지만, 다른 색의 눈을 가진 아이가 태어나는 건 마을이 생긴 이후 두 번째 일이었다.";
        yield return new WaitForSeconds(6f);
        subText.text = "마을 사람들은 콜드를 꺼려했지만, 똑같이 대해야 한다는 장로가 정한 마을의 규칙 때문에 여느 아이들과 똑같이 대했다.";
        yield return new WaitForSeconds(6f);
        StartCoroutine(imageFade(1));
        subText.text = "시간은 흘러 콜드가 17살이 되던 해, 마을의 축제 [루시아트]가 성대하게 열렸다.";
        yield return new WaitForSeconds(5f);
        subText.text = "이 축제가 열리는 날, 멜트린의 17살이 된 아이들은 모두 제단에서 불의 마법을 부여받는다.";
        yield return new WaitForSeconds(5f);
        subText.text = "제일 먼저 콜드의 차례가 되었고, 콜드는 떨리는 마음으로 제단에 올라갔다.";
        yield return new WaitForSeconds(4f);
        images[1].color = new Color(0, 0, 0, 1.0f);
        subText.text = "그런데...";
        yield return new WaitForSeconds(2f);
        subText.text = "";
        yield return new WaitForSeconds(1f);
        images[2].color = new Color(255, 255, 255, 1.0f);
        subText.text = "제단이 파란 빛을 내뿜더니 이내 순식간에 얼어붙었고, 콜드의 몸 속으로 차갑고 푸른 기운이 들어갔다.";
        yield return new WaitForSeconds(5f);
        subText.text = "붉은 기운을 내던 제단이 차갑게 식어버린 것을 보고 사람들은 패닉에 빠졌다.";
        yield return new WaitForSeconds(4f);
        StartCoroutine(imageFade(3));
        subText.text = "그리고, 그 혼란은 콜드를 향했다.";
        yield return new WaitForSeconds(3f);
        subText.text = "장로를 포함한 사람들은 콜드를 몰아세웠고, 축제는 엉망이 되었다.";
        yield return new WaitForSeconds(4f);
        subText.text = "콜드는 너무 혼란스럽고 무서웠던 나머지,";
        yield return new WaitForSeconds(3f);
        StartCoroutine(imageFade(4));
        subText.text = "마을을 도망쳐나와 하염없이 걸었다.";
        yield return new WaitForSeconds(3f);
        subText.text = "한참을 걷던 콜드는 곧 쓰러질 것만 같았다.";
        yield return new WaitForSeconds(4f);
        StartCoroutine (imageFade(5));
        subText.text = "결국, 지칠대로 지친 콜드는 쓰러지고 말았다.";
        yield return new WaitForSeconds(4f);
        subText.text = "콜드가 흘린 눈물이 손에 닿자 차갑게 얼어 보석같이 빛났다.";
        yield return new WaitForSeconds(5f);
        subText.text = "그리고 서서히, 정신을 잃어갔다.";
        yield return new WaitForSeconds(3f);
        StartCoroutine(imageFadeOut(0));
        StartCoroutine(imageFadeOut(1));
        StartCoroutine(imageFadeOut(2));
        StartCoroutine(imageFadeOut(3));
        StartCoroutine(imageFadeOut(4));
        StartCoroutine(imageFadeOut(5));
        subText.text = "서서히...";
        StartCoroutine(dialogStart());
    }
    
    IEnumerator imageFade(int index)
    {
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            images[index].color = new Color(255, 255, 255, fadeCount);
        }
        fadeCount = 0;
    }

    IEnumerator imageFadeOut(int index)
    {
        while (fadeCountOut > 0)
        {
            fadeCountOut -= 0.05f;
            yield return new WaitForSeconds(0.02f);
            images[index].color = new Color(255, 255, 255, fadeCount);
        }
    }
    IEnumerator dialogStart()
    {
        yield return new WaitForSeconds(2f);
        dialog = true;
    } 
}
