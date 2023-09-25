using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class pollTest : MonoBehaviour
{
    //Tilemap tilemap; -> 타일맵
    //Vector3 localPos -> 로컬 포지션
    //Vector3 worldPos -> 월드 포지션
    // Start is called before the first frame update
    public Tilemap tilemap; //정보를 받아올 타일맵 선언
    public TileBase animatedTile; //타일 베이스 (조건 달성시 바뀔 타일) 선언
    public GameObject player; //플레이어 선언
    public Vector3 currentPos; //Vector3타입의 현재 위치 선언
    public List<Vector3> toCool = new List<Vector3>(); //기둥들이 식을 조건(플레이어의 위치)를 담은 리스트 선언
    
    
    void Start()
    {
        tilemap = GetComponent<Tilemap>(); //타일맵 설정
        toCool.Clear(); // 리스트 클리어
        toCool.Add(new Vector3Int(4, 0, 0)); //리스트에 기둥이 식을 수 있는 플레이어 위치 추가
        player = GameObject.Find("player"); //플레이어 설정
    }
    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); //현재 위치를 가져온 후, 타일맵에 맞게 타일좌표로 바꿈
        //WorldToCell을 사용하면, (0.1, 0.88, -1.2)같은 복잡한 좌표를 (0,0,-1)같이 타일(셀) 좌표로 바꿔줌
        if (Input.GetKeyDown(KeyCode.A)) //A키를 눌렀다면
        {
            Debug.Log(currentPos); //현재 위치 콘솔에 찍기
            if (currentPos.x >= (toCool[0].x - 1) && currentPos.x <= (toCool[0].x + 1) && currentPos.y >= (toCool[0].y - 1) && currentPos.y <= (toCool[0].y + 1)) //그리고 현재 위치가 기둥이 식을 수 있는 위치라면
            {
                tilemap.SwapTile(tilemap.GetTile(new Vector3Int(4, -1, 0)), animatedTile); //기둥을 AnimatedTile로 바꿔 식는 애니메이션 적용
                //그 후, AnimatedTile에 Flags속성을 Loop Once로 주어 한번 애니메이션 실행 후 식은채로 남아있음
            }
        }
    }
}
