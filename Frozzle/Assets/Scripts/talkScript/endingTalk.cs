using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class endingTalk : MonoBehaviour
{
    public List<TextMeshProUGUI> texts;
    public Image fader;
    public GameObject btn;

    float fadeCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
            texts[i].enabled = false;
        }
        btn.SetActive(false);
        StartCoroutine(ending());
    }

    IEnumerator fadeText(int index)
    {
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;
            yield return new WaitForSeconds(0.005f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
        for (int i = 0; i < 12; i++)
        {
            if (i == index)
            {
                texts[i].enabled = true;
            } else
            {
                texts[i].enabled= false;
            }
        }
        while (fadeCount > 0)
        {
            fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.005f);
            fader.color = new Color(0, 0, 0, fadeCount);
        }
    }

    IEnumerator ending()
    {
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(fadeText(0));
        yield return new WaitForSeconds(2f);
        StartCoroutine(fadeText(1));
        yield return new WaitForSeconds(4f);
        StartCoroutine(fadeText(2));
        yield return new WaitForSeconds(4f);
        StartCoroutine(fadeText(3));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(4));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(5));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(6));
        yield return new WaitForSeconds(2f);
        StartCoroutine(fadeText(7));
        yield return new WaitForSeconds(1f);
        StartCoroutine(fadeText(8));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(9));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(10));
        yield return new WaitForSeconds(3f);
        StartCoroutine(fadeText(11));
        yield return new WaitForSeconds(2f);
        btn.SetActive(true);
    }
}
