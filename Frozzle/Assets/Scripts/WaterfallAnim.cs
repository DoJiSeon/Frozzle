using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WaterfallAnim : MonoBehaviour
{
    public Tilemap tilemap; // 정보를 받아올 타일맵 선언
    public TileBase tilebase; //바꿀 타일 베이스 선언
    public GameObject player; // 플레이어 선언
    public Vector3Int currentPos, fall_bottom, fall_middle, fall_top, fall_start_check; // 현재 위치 선언
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // 타일맵 정의
        player = GameObject.Find("player"); // 플레이어 정의 
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
            // Debug.Log("폭포 첨 시작이당");
            // animate 실행
        }
        else if (tilemap.GetTile(fall_start_check).name == "fallMiddleFR")
        {
            // Debug.Log("폭포 중간이당");
        }
        else if (tilemap.GetTile(currentPos).name == "fallTopFR")
        {
            // Debug.Log("폭포 맨 끝이당");
            animator.SetTrigger("byefall");
            animator.SetBool("infall", false);
        }


    }
}
