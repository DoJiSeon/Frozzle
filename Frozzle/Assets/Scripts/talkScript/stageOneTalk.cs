using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class stageOneTalk : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public Image fader;
    public Image stageLogo;
    public GameObject player;

    float fadeCount = 1.0f;
    int clickCount = 0;
    int startClickCount = 0;
    int pageClickCount = 0;

    public List<Vector3Int> paperLocation = new List<Vector3Int>();

    public float delay;

    bool isDialoging = false;
    bool pageOne = false;
    bool pageTwo = false;
    bool pageThree = false;
    bool pageFour = false;
    bool pageFive = false;
    bool isClickable = true;
    bool isReading = false;
    bool isCleared = false;
    bool startAutoStart = false;
    bool autoStart = true;
    bool pageOneAutoStart = true;
    bool pageTwoAutoStart = true;
    bool pageThreeAutoStart = true;
    bool pageFourAutoStart = true;
    bool pageFiveAutoStart = true;

    IEnumerator seq;
    IEnumerator skip_seq;
    void Start()
    {
        player.GetComponent<CharacterMovement>().enabled = false;
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
        Debug.Log(PlayerPrefs.GetInt("enteredStage"));
        if (PlayerPrefs.GetInt("enteredStage") < 1)
        {
            StartCoroutine(fadeIn());
        } else
        {
            StartCoroutine(oldFadeIn());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("enteredStage") < 1)
        {
            if (Input.GetMouseButtonDown(0) || startAutoStart)
            {
                startAutoStart = false;
                if (startClickCount == 0 && isClickable) {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("칼리움! 어디있어?");
                    StartCoroutine(seq);
                    startClickCount++;
                } else if (startClickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("난 이 위에있어!");
                    StartCoroutine(seq);
                    startClickCount++;
                }
                else if (startClickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("신상 안으로 들어오면 난 항상 위에서 지켜보면서 알려줄거야! 여기서 봐야 경치가 좋거든!");
                    StartCoroutine(seq);
                    startClickCount++;
                }
                else if (startClickCount == 3 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("하여튼 제멋대로라니깐...");
                    StartCoroutine(seq);
                    startClickCount++;
                }
                else if (startClickCount > 3 && isClickable)
                {
                    PlayerPrefs.SetInt("enteredStage", 1);
                    StartCoroutine(StageLogoFade());
                    talkPanel.SetActive(false); 
                    nameTag.SetActive(false);
                }
            } 
        }
        if (isCleared)
        {
            if (Input.GetMouseButtonDown(0) || autoStart) { 
                autoStart = false;
                if (clickCount == 0 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("다 찾은 것 같네. 빠진 건 없지?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("응. 다 챙긴것 같아.");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("좋네! 이제 나가자!");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount > 2 && isClickable)
                {
                    PlayerPrefs.SetInt("clear_stage", 1);
                    talkPanel.SetActive(false);
                    nameTag.SetActive(false);
                    StartCoroutine(fadeOut());
                }
            }
        } else
        {
            Debug.Log(Vector3Int.FloorToInt(player.transform.position));
            if ((Input.GetKeyDown(KeyCode.Q) && !isReading) || isDialoging)
            {
                Vector3 playerPos = Vector3Int.FloorToInt(player.transform.position);
                if (playerPos == paperLocation[0] && !pageOne)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown(0) || pageOneAutoStart)
                    {
                        pageOneAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("([멜트린에서 맑고 푸른 눈을 가진 소녀가 태어났다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("멜트린? 무슨 마을 이름인가?");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageOne = true;
                            isReading = false;
                            isDialoging = false;
                        }
                    }
                }
                else if (playerPos == paperLocation[1] && !pageTwo)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown(0) || pageTwoAutoStart)
                    {
                        pageTwoAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("([마을이 생긴 이후 두 번째 일이었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("뭐가 두 번째 일이라는 거지? 소녀가 태어난 게?");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageTwo = true;
                            isReading = false;
                            isDialoging = false;
                        }
                    }
                }
                else if (playerPos == paperLocation[2] && !pageThree)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown (0) || pageThreeAutoStart)
                    {
                        pageThreeAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("([제단은 파란 빛을 내뿜으며 순식간에 얼어붙었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("한겨울이었나? 많이 추웠나보네.");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageThree = true;
                            isReading = false;
                            isDialoging = false;
                        }
                    }
                  
                }
                else if (playerPos == paperLocation[3] && !pageFour)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown(0) || pageFourAutoStart) { 
                        pageFourAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("엥? 이건 아무것도 안써있네?");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("속지 같은건가? 일단 챙겨놔야겠다.");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable) {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageFour = true;
                            isReading = false;
                            isDialoging = false;
                        }
                    }
                }
                else if (playerPos == paperLocation[4] && !pageFive)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown (0) || pageFiveAutoStart)
                    {
                        pageFiveAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("([너무 무서웠던 나머지 뒤도 돌아보지 않고 뛰었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("대체 무슨 일이 일어나는거야...");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageFive = true;
                            isCleared = true;
                            isReading = false;
                            isDialoging = false;
                        }
                    }
                }
            }
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name == "paper1")
    //    {
    //        seq = sentenceSequence("멜트린? 무슨 마을 이름인가?");
    //        StartCoroutine(seq);
    //    } 
    //    else if (collision.gameObject.name == "paper2")
    //    {
    //        seq = sentenceSequence("뭐가 두 번째 일이라는 거지? 소녀가 태어난 일인가?");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper3")
    //    {
    //        seq = sentenceSequence("한겨울이었나? 많이 추웠나보네.");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper4")
    //    {
    //        seq = sentenceSequence("엥? 이건 아무것도 안써있네?");
    //        StartCoroutine(seq);
    //        new WaitUntil(() => Input.GetMouseButtonDown(0));
    //        seq = sentenceSequence("일단 넣어놔야겠다. 속지 같은건가?");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper5")
    //    {
    //        seq = sentenceSequence("겨울에?! 대체 무슨 일이 일어나는거야...");
    //        StartCoroutine(seq);
    //    }
    //}

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
            fadeCount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        yield return new WaitForSeconds(0.5f);
        autoStart = true;
        startAutoStart = true;
        isClickable = true;
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
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("tutorial");
    }

    IEnumerator oldFadeIn()
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
        StartCoroutine(StageLogoFade());
    }

    IEnumerator StageLogoFade()
    {
        float stageFadeCount = 0;
        while (stageFadeCount < 1.0f)
        {
            stageFadeCount += 0.05f;
            yield return new WaitForSeconds(0.01f);
            stageLogo.color = new Color(255, 255, 255, stageFadeCount);
        }
        yield return new WaitForSeconds(2f);
        while (stageFadeCount > 0)
        {
            stageFadeCount -= 0.05f;
            yield return new WaitForSeconds(0.01f);
            stageLogo.color = new Color(255, 255, 255, stageFadeCount);
        }
        player.GetComponent<CharacterMovement>().enabled = true;
    }
}
