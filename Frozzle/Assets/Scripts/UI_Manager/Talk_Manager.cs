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
        talkData.Add(1, new string[] { "¾È³ç, ³­ Ä®¸®¿ÂÀÌ¾ß." });
        talkData.Add(1, new string[] { "´ëÃæ ¾îÂ¼±¸ ÀúÂ¼±¸" });
        talkData.Add(1, new string[] { "»çÈ¥ÀÇ Á¶°¢À» ¸ğÀ¸·Å." });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
