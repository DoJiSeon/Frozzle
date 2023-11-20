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
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("�̹����� ȥ�� �غ�! �� �� ��ġ�� ��ĥ �� ����!!");
                    StartCoroutine(seq);
                    startClickCount++;
                } else if (startClickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "�ݵ�";
                    seq = sentenceSequence("����̴� ����̳�...");
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
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("�� ã�� �� ����. �̹����� ���� �� ����?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "�ݵ�";
                    seq = sentenceSequence("�׷� �� ������... ���� �� �� �̸��� ���־�...?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("��... ���� �ű���� ã���ǰ�.");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 3 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("�ϴ� ������. ������ �������ٰ�.");
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
                            seq = sentenceSequence("([������� �дп� ������ �ҳฦ ���Ƽ�����.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("�갡 �� �߸��߱淡... �� ���� ������ΰ�?");
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
                            seq = sentenceSequence("�̰͵� ����ֳ�... �굵 �����ΰ�?");
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
                            seq = sentenceSequence("([�� ���� ������ ���� <��þ�Ʈ>�� ������ ���̾���.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("<��þ�Ʈ>? ���� �̸��� ���ڳ�. �ٵ�... �� �̷��� �ͼ�����?");
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
                            seq = sentenceSequence("([�տ� ���� ������ ���İ��� ���پ���.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("�տ� ���� ������... ���...? �̰� ���� �׷��� �� ������...?");
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
                            seq = sentenceSequence("([���� ���� �ݵ尡 �������� �ö󰬴�.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("����... ��... �� �̸���...?");
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
    //        seq = sentenceSequence("��Ʈ��? ���� ���� �̸��ΰ�?");
    //        StartCoroutine(seq);
    //    } 
    //    else if (collision.gameObject.name == "paper2")
    //    {
    //        seq = sentenceSequence("���� �� ��° ���̶�� ����? �ҳడ �¾ ���ΰ�?");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper3")
    //    {
    //        seq = sentenceSequence("�Ѱܿ��̾���? ���� �߿�������.");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper4")
    //    {
    //        seq = sentenceSequence("��? �̰� �ƹ��͵� �Ƚ��ֳ�?");
    //        StartCoroutine(seq);
    //        new WaitUntil(() => Input.GetMouseButtonDown(0));
    //        seq = sentenceSequence("�ϴ� �־���߰ڴ�. ���� �����ǰ�?");
    //        StartCoroutine(seq);
    //    }
    //    else if (collision.gameObject.name == "paper5")
    //    {
    //        seq = sentenceSequence("�ܿ￡?! ��ü ���� ���� �Ͼ�°ž�...");
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
