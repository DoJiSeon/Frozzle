using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class stageTwoTalk : MonoBehaviour
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
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
        Debug.Log(PlayerPrefs.GetInt("enteredStage"));
        if (PlayerPrefs.GetInt("enteredStage") < 2)
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
        if (PlayerPrefs.GetInt("enteredStage") < 2)
        {
            if (Input.GetMouseButtonDown(0) || startAutoStart)
            {
                startAutoStart = false;
                if (startClickCount == 0) {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("이번에는 혼자 해봐! 난 이 경치를 놓칠 수 없어!!");
                    StartCoroutine(seq);
                    startClickCount++;
                } else if (startClickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("고양이는 고양이네...");
                    StartCoroutine(seq);
                    startClickCount++;
                }
                else if (startClickCount > 1 && isClickable)
                {
                    PlayerPrefs.SetInt("enteredStage", 2);
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
                    seq = sentenceSequence("다 찾은 것 같네. 이번에도 빠진 건 없지?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("그런 것 같은데... 여기 왜 내 이름이 써있어...?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("하... 벌써 거기까지 찾은건가.");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 3 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("일단 나가자. 나가서 설명해줄게.");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if(clickCount > 3 && isClickable)
                {
                    PlayerPrefs.SetInt("clear_stage", 2);
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
                            seq = sentenceSequence("([사람들은 패닉에 빠졌고 소녀를 몰아세웠다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("얘가 뭘 잘못했길래... 좀 나쁜 사람들인가?");
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
                            seq = sentenceSequence("이것도 비어있네... 얘도 속지인가?");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 0 && isClickable)
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
                            seq = sentenceSequence("([그 날은 마을의 축제 <루시아트>가 열리는 날이었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("<루시아트>? 축제 이름이 예쁘네. 근데... 왜 이렇게 익숙하지?");
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
                            seq = sentenceSequence("([손에 닿은 눈물은 순식간에 얼어붙었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("손에 닿은 눈물이... 얼어...? 이거 나도 그랬던 것 같은데...?");
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
                            seq = sentenceSequence("([제일 먼저 콜드가 제단으로 올라갔다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("여기... 왜... 내 이름이...?");
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
    }
}
