using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class enterLevelChoose : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject talkPanel;
    public TextMeshProUGUI text;
    public GameObject nameTag;
    public TextMeshProUGUI nameTagInnerText;
    public Image fader;
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int playerPosition = Vector3Int.FloorToInt(player.transform.position);
        if (playerPosition == new Vector3Int(11, 6, 0))
        {
            Debug.Log("���ðڽ��ϱ�?");
            if (Input.GetKeyDown(KeyCode.G)) {
                Debug.Log("���� ��...");
            }
        }
    }
}
