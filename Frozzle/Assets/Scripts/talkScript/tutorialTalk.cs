using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System;

public class tutorialTalk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public TextMeshProUGUI pressG;
    public Image pressGWrapper;
    public Image fader;
    public GameObject calium;
    public GameObject player;
    public Animator playerAnim;
    public Animator caliumAnim;
    public SpriteRenderer caliumRend;
    public Tilemap tilemap;
    public bool isFlip;
    public List<string> textList = new List<string>();
    public List<string> TLASOC = new List<string>();
    public List<string> TLASTC = new List<string>();
    int clickCount = 0;
    float fadeCount = 1.0f;
    bool isClickable = true;
    bool autoStart = false;
    bool isEverReached = false;

    IEnumerator seq;
    IEnumerator skip_seq;

    public float delay;
    void Start()
    {
        clickCount = 0;
        pressG.enabled = false;
        pressGWrapper.enabled = false;
        player.GetComponent<CharacterMovement>().enabled = false;
        talkPanel.SetActive(false);
        nameTag.SetActive(false);
        StartCoroutine(fadeIn());
        if (PlayerPrefs.GetInt("clear_stage") == 1 || PlayerPrefs.GetInt("enteredStage") == 1)
        {
            player.transform.position = tilemap.GetCellCenterWorld(new Vector3Int(23, 0, 0)); ;
        } else if (PlayerPrefs.GetInt("clear_stage") == 2 || PlayerPrefs.GetInt("enteredStage") == 2)
        {
            player.transform.position = tilemap.GetCellCenterWorld(new Vector3Int(25, 0, 0)); ;
        }
        else if (PlayerPrefs.GetInt("clear_stage") == 3 || PlayerPrefs.GetInt("enteredStage") == 3)
        {
            player.transform.position = tilemap.GetCellCenterWorld(new Vector3Int(27, 0, 0)); ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTargetPosition = tilemap.GetCellCenterWorld(Vector3Int.FloorToInt(player.transform.position));
        Vector3Int playerPosition = Vector3Int.FloorToInt(player.transform.position);
        if ((Input.GetMouseButtonDown(0) || autoStart || (playerTargetPosition.x >= 3 && !isEverReached)) && PlayerPrefs.GetInt("clear_stage") == 0)
        {
            autoStart = false;
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
                nameTag.SetActive(true);
                nameTagInnerText.text = "???";
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
                nameTagInnerText.text = "???";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 4 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 5 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "말하는 고양이";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 6 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 7 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 8 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 9 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "말하는 고양이";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 10 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "말하는 고양이";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 11 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 12 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 13 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                caliumAnim.SetBool("copterInitiate", true);
                StartCoroutine(moveCalium(new Vector3Int(24, -1, 1), 1f));
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (!isEverReached && playerTargetPosition.x >= 3)
            {
                player.GetComponent<CharacterMovement>().enabled = false;
                playerAnim.SetBool("walk", false);
                isEverReached = true;
                pressG.enabled = false;
                pressGWrapper.enabled = false;
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 15 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 16 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 17 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "칼리움 ";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 18 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 19 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 20 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(false);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 21 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 22 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 23 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 24 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount == 25 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTagInnerText.text = "콜드";
                seq = sentenceSequence(textList[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
            else if (clickCount > 25 && isClickable)
            {
                player.GetComponent<CharacterMovement>().enabled = true;
                talkPanel.SetActive(false);
                pressG.text = "G키를 눌러 고양이 신상 안으로 진입하세요.";
                pressG.enabled = true;
                pressGWrapper.enabled = true;
            }
        }
        if (Input.GetMouseButtonDown(0) || autoStart || (playerTargetPosition.x >= 3 && !isEverReached) && PlayerPrefs.GetInt("clear_stage") == 1)
        {
            if (clickCount == 0 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(TLASOC[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            } else if (clickCount == 1 && isClickable)
            {
                talkPanel.SetActive(true);
                nameTag.SetActive(true);
                nameTagInnerText.text = "칼리움";
                seq = sentenceSequence(TLASOC[clickCount]);
                StartCoroutine(seq);
                clickCount++;
            }
        }

            Debug.Log(playerPosition);
        if (playerPosition == new Vector3Int(11, 6, 0) && Input.GetKeyDown(KeyCode.G))
        {
            pressG.enabled = false;
            pressGWrapper.enabled = false;
            talkPanel.SetActive(true);
            if (PlayerPrefs.GetInt("enteredStage") == 0)
            {
                PlayerPrefs.SetInt("enteredStage", 1);
                seq = nextSentenceSequence("으아아아아아아아아아아아아아아아아아아아아아악!", "Stage_1-1");
                StartCoroutine(seq);
            } else
            {
                seq = nextSentenceSequence("스테이지 1-1에 진입합니다.", "Stage_1-1");
                StartCoroutine(seq);
            }
        } else if (playerPosition == new Vector3Int(12, 6, 0) && Input.GetKeyDown(KeyCode.G))
        {
            pressG.enabled = false;
            pressGWrapper.enabled = false;
            talkPanel.SetActive(true);
            if (PlayerPrefs.GetInt("enteredStage") == 1)
            {
                PlayerPrefs.SetInt("enteredStage", 2);
                seq = nextSentenceSequence("대체... 나한테... 무슨 일이 있었던거지...?", "Stage_1-2");
                StartCoroutine(seq);
            }
            else
            {
                seq = nextSentenceSequence("스테이지 1-2에 진입합니다.", "Stage_1-2");
                StartCoroutine(seq);
            }
        } else if (playerPosition == new Vector3Int(13, 7, 0) && Input.GetKeyDown(KeyCode.G))
        {
            pressG.enabled = false;
            pressGWrapper.enabled = false;
            talkPanel.SetActive(true);
            if (PlayerPrefs.GetInt("stageThreeEntered") == 2)
            {
                PlayerPrefs.SetInt("enteredStage", 3);
                seq = nextSentenceSequence("멜트린에 무슨 일이 일어났는지 알아야겠어!", "Stage_1-3");
                StartCoroutine(seq);
            }
            else
            {
                seq = nextSentenceSequence("스테이지 1-3에 진입합니다.", "Stage_1-3");
                StartCoroutine(seq);
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

    IEnumerator moveCalium(Vector3Int caliumPosition, float delay_)
    {
        isClickable = false;
        int movementSpeed = 2;
        yield return new WaitForSeconds(delay_);
        Vector3 caliumTargetPosition = tilemap.GetCellCenterWorld(caliumPosition); // 목표 위치를 World 좌표로 변환
        while (Vector3.Distance(calium.transform.position, caliumTargetPosition) > 0.01f)
        {
            calium.transform.position = Vector3.MoveTowards(calium.transform.position, caliumTargetPosition, movementSpeed * Time.deltaTime);
            yield return null;
        }
        isClickable = true;
        player.GetComponent<CharacterMovement>().enabled = true;
        talkPanel.SetActive(false);
        pressG.text = "마우스 우클릭으로 이동하여 칼리움에게 가세요.";
        pressG.enabled = true;
        pressGWrapper.enabled = true;
        caliumAnim.SetBool("copterEnd", true);
        caliumAnim.SetBool("copterInitiate", false);
    }

}
