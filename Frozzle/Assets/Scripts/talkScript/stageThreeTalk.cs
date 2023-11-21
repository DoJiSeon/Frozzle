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
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("(�������� ��� ������ å�� �ϴú����� ������ �� ����� �ݵ��� �ֺ��� ���մ�.)");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "�ݵ�";
                    seq = sentenceSequence("�׸���, ����� ��Ҹ��� �鸮�� �����ߴ�.");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("��...��...��...");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 3 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("��...�ƿ�...����...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 4 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0.02f;
                    seq = sentenceSequence("��...�ƿ�...����...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 5 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0.01f;
                    seq = sentenceSequence("�ݵ�...���ƿ�...�̾���...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 6 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0.005f;
                    seq = sentenceSequence("�츮�� �߸��߾�.. ���� ���ƿ���...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 7 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0;
                    seq = sentenceSequence("�츮���� �װ� �ʿ��ϴܴ�...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 8 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0;
                    seq = sentenceSequence("���� ���ƿ���...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 9 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0;
                    seq = sentenceSequence("�ݵ�...");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 10 && isClickable)
                {
                    autoStart = true;
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    delay = 0;
                    seq = sentenceSequence("�װ� �ʿ���...");
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
                            seq = sentenceSequence("([�� ��, ��δ� �ʴ� ����� ���� ���÷Ȱ�, �̳� �ݵ带 ���Ƽ��� �������� �� ���� ū �߸����� �˰� �̸� ��������鿡�� �˷ȴ�.]�� �����ִ�.)");
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
                            seq = sentenceSequence("[��ĥ ��, ������ �ؽ��� ȭ������ ���� �����ߴ�. ���ܿ��� ġ�Ḧ �޾ƾ� ������, ������ ��� ġ�Ḧ ���� �� ������.]�� �����ִ�.");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            nameTag.SetActive(false);
                            seq = sentenceSequence("������ ȭ������...? �׸��� ������...");
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
                            seq = sentenceSequence("([���� ���������� �ݵ��� �θ���� �� ��迡�� �ݵ带 �߰��ϰ� ������ �����Դ�.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("�����̴�... ���ǿ����� ���� ����ֳ�������.");
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
                            seq = sentenceSequence("([�ᱹ ������ ���� �ؽ��� ȭ������ ġ���ϱ� ���� ��δ� ���� �������� ġ�� ���ڸ� ������. �׸��� �� ���� ���� ������ �ϳ��� �־���.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("������...? ���� �̰�...����...?");
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
                            seq = sentenceSequence("([��δ� �̸� ��������鿡�� �˷ȴ�.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("���� ��������鵵 �� �˰ڱ���.");
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
                            seq = sentenceSequence("([�׸���, �� ���� �����̴� �ص��� ������ �� ���� ȭ������ ġ���� ���̶�� �����ϰ� �־���.]�� �����ִ�.)");
                            StartCoroutine(seq);
                            pageClickCount++;
                        }
                        else if (pageClickCount == 1 && isClickable)
                        {
                            talkPanel.SetActive(true);
                            seq = sentenceSequence("ȭ���� ġ���� ���谡... ������...!");
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
