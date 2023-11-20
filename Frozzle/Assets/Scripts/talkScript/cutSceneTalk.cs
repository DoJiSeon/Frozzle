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
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("����� ���ƿԾ�?");
                    StartCoroutine(seq);
                    clickCount++;
                } else if (clickCount == 1 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("(�ݵ�� �Ҹ����� ��� ���� ��������.)");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 2 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("...���� ���� ����?");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 3 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(true);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("���� �������. �������� ���� ���� �־�.");
                    StartCoroutine(seq);
                    clickCount++;
                }
                else if (clickCount == 4 && isClickable)
                {
                    talkPanel.SetActive(true);
                    nameTag.SetActive(false);
                    nameTagInnerText.text = "Į����";
                    seq = sentenceSequence("(�ݵ�� ������ ���ſ� �߰������� Į������ ���󰬴�.");
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
        subText.text = "��� ȭâ�� ��, ��Ʈ������ Ǫ�� ���� ���� �ҳ�, �ݵ尡 �¾��.";
        yield return new WaitForSeconds(5f);
        subText.text = "��Ʈ�� ������� ��� �˺��� ���� ������ �¾����, �ٸ� ���� ���� ���� ���̰� �¾�� �� ������ ���� ���� �� ��° ���̾���.";
        yield return new WaitForSeconds(6f);
        subText.text = "���� ������� �ݵ带 ����������, �Ȱ��� ���ؾ� �Ѵٴ� ��ΰ� ���� ������ ��Ģ ������ ���� ���̵�� �Ȱ��� ���ߴ�.";
        yield return new WaitForSeconds(6f);
        StartCoroutine(imageFade(1));
        subText.text = "�ð��� �귯 �ݵ尡 17���� �Ǵ� ��, ������ ���� [��þ�Ʈ]�� �����ϰ� ���ȴ�.";
        yield return new WaitForSeconds(5f);
        subText.text = "�� ������ ������ ��, ��Ʈ���� 17���� �� ���̵��� ��� ���ܿ��� ���� ������ �ο��޴´�.";
        yield return new WaitForSeconds(5f);
        subText.text = "���� ���� �ݵ��� ���ʰ� �Ǿ���, �ݵ�� ������ �������� ���ܿ� �ö󰬴�.";
        yield return new WaitForSeconds(4f);
        images[1].color = new Color(0, 0, 0, 1.0f);
        subText.text = "�׷���...";
        yield return new WaitForSeconds(2f);
        subText.text = "";
        yield return new WaitForSeconds(1f);
        images[2].color = new Color(255, 255, 255, 1.0f);
        subText.text = "������ �Ķ� ���� ���մ��� �̳� ���İ��� ���پ���, �ݵ��� �� ������ ������ Ǫ�� ����� ����.";
        yield return new WaitForSeconds(5f);
        subText.text = "���� ����� ���� ������ ������ �ľ���� ���� ���� ������� �дп� ������.";
        yield return new WaitForSeconds(4f);
        StartCoroutine(imageFade(3));
        subText.text = "�׸���, �� ȥ���� �ݵ带 ���ߴ�.";
        yield return new WaitForSeconds(3f);
        subText.text = "��θ� ������ ������� �ݵ带 ���Ƽ�����, ������ ������ �Ǿ���.";
        yield return new WaitForSeconds(4f);
        subText.text = "�ݵ�� �ʹ� ȥ�������� �������� ������,";
        yield return new WaitForSeconds(3f);
        StartCoroutine(imageFade(4));
        subText.text = "������ �����ĳ��� �Ͽ����� �ɾ���.";
        yield return new WaitForSeconds(3f);
        subText.text = "������ �ȴ� �ݵ�� �� ������ �͸� ���Ҵ�.";
        yield return new WaitForSeconds(4f);
        StartCoroutine (imageFade(5));
        subText.text = "�ᱹ, ��ĥ��� ��ģ �ݵ�� �������� ���Ҵ�.";
        yield return new WaitForSeconds(4f);
        subText.text = "�ݵ尡 �기 ������ �տ� ���� ������ ��� �������� ������.";
        yield return new WaitForSeconds(5f);
        subText.text = "�׸��� ������, ������ �Ҿ��.";
        yield return new WaitForSeconds(3f);
        StartCoroutine(imageFadeOut(0));
        StartCoroutine(imageFadeOut(1));
        StartCoroutine(imageFadeOut(2));
        StartCoroutine(imageFadeOut(3));
        StartCoroutine(imageFadeOut(4));
        StartCoroutine(imageFadeOut(5));
        subText.text = "������...";
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
