using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterfallAnim : MonoBehaviour
{
    public Tilemap tilemap; // ������ �޾ƿ� Ÿ�ϸ� ����
    public TileBase tilebase; //�ٲ� Ÿ�� ���̽� ����
    public GameObject player; // �÷��̾� ����
    public Vector3Int currentPos, fall_bottom, fall_middle, fall_top, fall_start_check; // ���� ��ġ ����
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // Ÿ�ϸ� ����
        player = GameObject.Find("player"); // �÷��̾� ���� 
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position);
        //Debug.Log(currentPos);
        fall_start_check = new Vector3Int(currentPos.x + 1, currentPos.y, currentPos.z);
        fall_middle = new Vector3Int(currentPos.x + 1, currentPos.y + 1, currentPos.z);
        if (tilemap.GetTile(fall_start_check).name == "fallEndFR")
        {
            animator.SetBool("infall", true);
            animator.SetTrigger("meetfall");
            // Debug.Log("���� ÷ �����̴�");
            // animate ����
        }
        else if (tilemap.GetTile(fall_start_check).name == "fallMiddleFR")
        {
            // Debug.Log("���� �߰��̴�");
        }
        else if (tilemap.GetTile(currentPos).name == "fallTopFR")
        {
            // Debug.Log("���� �� ���̴�");
            animator.SetTrigger("byefall");
            animator.SetBool("infall", false);
        }


    }
}
