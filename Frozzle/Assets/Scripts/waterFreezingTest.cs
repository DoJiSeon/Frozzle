using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class waterFreezingTest : MonoBehaviour
{
    public Tilemap tilemap; // 정보를 받아올 타일맵 선언
    public TileBase tilebase; //바꿀 타일 베이스 선언
    public GameObject player; // 플레이어 선언
    public Vector3Int currentPos; // 현재 위치 선언
    public Animator animator; // 애니메이터 선언 (현재는 죽은 변수, 추후에 사용 예정)
    public EdgeCollider2D edgeCollider; // EdgeCollider 선언
    private List<Vector3Int> toFreeze = new List<Vector3Int>(); // 얼릴 것들의 리스트 선언
    //EdgeCollider를 사용하는 이유는, 물이 흐르고 있을때는 가지 못했다가 물이 얼고 나서는 갈 수 있게 하는 기능을 구현하는데 가장 적합하기 때문

    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // 타일맵 정의
        player = GameObject.Find("player"); // 플레이어 정의 
        animator = player.GetComponent<Animator>(); // 애니메이터 정의
        toFreeze.Clear(); // 리스트 초기화
        toFreeze.Add(new Vector3Int(-1, -2, 0)); // 리스트에 얼릴 수 있는 좌표 추가
        edgeCollider.enabled = true; // EdgeCollider 활성화
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); // 현재 위치 타일에 맞춰 받아오고
        if (Input.GetKeyDown(KeyCode.E)) // E키가 눌렸을 때
        {
            // Debug.Log(currentPos); // 현재 위치 띄우기
            if (currentPos == toFreeze[0]) // 현재 위치가 얼릴 수 있는 위치라면
            {
                // Debug.Log("Working"); // 실행중입니다
                tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[0].x + 1, toFreeze[0].y - 1, 0)), tilebase); // 플레이어의 좌표로부터 일정거리만큼 떨어진 물 타일을 어는 타일로 바꿈
                Vector3Int currentTilePos = new Vector3Int(toFreeze[0].x + 2, toFreeze[0].y - 1, 0); // 방금 언 타일 다음에 얼 타일의 위치를 저장
                // Debug.Log(tilemap.GetTile(currentTilePos).name == "waterFlowing"); // Test
                while (tilemap.GetTile(currentTilePos).name == "waterFlowing") // 다음으로 얼 타일의 이름이 waterFlowing일 때동안 실행 (인접한 물은 모두 얼림)
                {
                    tilemap.SwapTile(tilemap.GetTile(new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0)), tilebase); // 그 위치의 물 타일을 어는 타일로 바꿈
                    currentTilePos = new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0); // 다음 타일의 위치로 현재 위치 변경
                }
                edgeCollider.enabled = false; // 다 얼었다면 EdgeCollider를 비활성화하여 지나갈 수 있게 해줌
            }
        }
}
}
