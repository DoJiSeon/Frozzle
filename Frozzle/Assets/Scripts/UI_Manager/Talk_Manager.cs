using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk_Manager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;


    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1, new string[] { "�ȳ�, �� Į�����̾�." });
        talkData.Add(1, new string[] { "���� ��¼�� ��¼��" });
        talkData.Add(1, new string[] { "��ȥ�� ������ ������." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
