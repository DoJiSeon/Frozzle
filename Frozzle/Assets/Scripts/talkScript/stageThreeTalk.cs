using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class stageThreeTalk : MonoBehaviour
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
    public GameObject pageOneR;
    public GameObject pageTwoR;
    public GameObject pageThreeR;
    public GameObject pageFourR;
    public GameObject pageFiveR;
    public GameObject pageSixR;

    float fadeCount = 1.0f;
    int clickCount = 0;
    int startClickCount = 0;
    int pageClickCount = 0;
    int pageCount = 0;

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
    bool startAutoStart = false;
    bool autoStart = true;
    bool pageOneAutoStart = true;
    bool pageTwoAutoStart = true;
    bool pageThreeAutoStart = true;
    bool pageFourAutoStart = true;
    bool pageFiveAutoStart = true;
    bool pageSixAutoStart = true;

    IEnumerator seq;
    IEnumerator skip_seq;
    void Start()
    {
        player.GetComponent<CharacterMovement>().enabled = false;
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
        if (pageCount == 6)
        {
            if (Input.GetMouseButtonDown(0) || autoStart) { 
                if (clickCount == 0 && isClickable)
                {
                    autoStart = false;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("(페이지를 모두 모으자 책이 하늘빛으로 빛나며 그 기운이 콜드의 주변을 감쌌다.)");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "콜드";
                    seq = sentenceSequence("그리고, 희미한 목소리가 들리기 시작했다.");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("드...와...해...");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 3 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    seq = sentenceSequence("드...아와...안해...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 4 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0.02f;
                    seq = sentenceSequence("드...아와...안해...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 5 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0.01f;
                    seq = sentenceSequence("콜드...돌아와...미안해...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 6 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0.005f;
                    seq = sentenceSequence("우리가 잘못했어.. 제발 돌아와줘...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 7 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0;
                    seq = sentenceSequence("우리에겐 네가 필요하단다...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 8 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0;
                    seq = sentenceSequence("제발 돌아와줘...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 9 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0;
                    seq = sentenceSequence("콜드...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 10 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "칼리움";
                    delay = 0;
                    seq = sentenceSequence("네가 필요해...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if(clickCount > 3 && isClickable)
                {
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
                if (playerPos == paperLocation[0] && !pageOne &&pageOneR.activeSelf)
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
                            seq = sentenceSequence("([그 때, 장로는 초대 장로의 말을 떠올렸고, 이내 콜드를 몰아세워 도망가게 한 것이 큰 잘못임을 알고 이를 마을사람들에게 알렸다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("...");
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
                            pageCount++;
                        }
                    }
                }
                else if (playerPos == paperLocation[1] && !pageTwo && pageTwoR.activeSelf)
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
                            seq = sentenceSequence("[며칠 뒤, 마을에 극심한 화염병이 돌기 시작했다. 제단에서 치료를 받아야 했지만, 제단이 얼어 치료를 받을 수 없었다.]고 적혀있다.");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("마을에 화염병이...? 그리고 제단이...");
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
                            pageCount++;
                        }
                    }
                }
                else if (playerPos == paperLocation[2] && !pageThree && pageThreeR.activeSelf)
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
                            seq = sentenceSequence("([한편 마을사람들과 콜드의 부모님은 숲 경계에서 콜드를 발견하고 마을로 데려왔다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("다행이다... 현실에서의 나는 살아있나보구나.");
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
                            pageCount++;
                        }
                    }
                  
                }
                else if (playerPos == paperLocation[3] && !pageFour && pageFourR.activeSelf)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown(0) || pageFourAutoStart) { 
                        pageFourAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("([결국 마을에 도는 극심한 화염병을 치료하기 위해 장로는 대대로 내려오는 치료 상자를 열었다. 그리고 그 곳엔 작은 눈송이 하나가 있었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("눈송이...? 설마 이거...나야...?");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable) {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageFour = true;
                            isReading = false;
                            isDialoging = false;
                            pageCount++;
                        }
                    }
                }
                else if (playerPos == paperLocation[4] && !pageFive && pageFiveR.activeSelf)
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
                            seq = sentenceSequence("([장로는 이를 마을사람들에게 알렸다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("이제 마을사람들도 다 알겠구나.");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            pageFive = true;
                            isReading = false;
                            isDialoging = false;
                            pageCount++;
                        }
                    }
                }
                else if (playerPos == paperLocation[5] && pageSixR.activeSelf)
                {
                    isDialoging = true;
                    isReading = true;
                    if (Input.GetMouseButtonDown(0) || pageSixAutoStart)
                    {
                        pageSixAutoStart = false;
                        if (pageClickCount == 0 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("([그리고, 그 작은 눈송이는 극도로 차가운 것 만이 화염병을 치료할 것이라고 예견하고 있었다.]고 적혀있다.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("화염병 치료의 열쇠가... 나였어...!");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount > 1 && isClickable)
                        {
                            talkPanel.SetActive(false);
                            pageClickCount = 0;
                            isReading = false;
                            isDialoging = false;
                            pageCount++;
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
        SceneManager.LoadScene("ending");
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
