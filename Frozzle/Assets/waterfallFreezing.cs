using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class waterfallFreezing : MonoBehaviour
{
    public Tilemap tilemap; // 정보를 받아올 타일맵 선언
    public TileBase tilebase; // 바꿀 타일 베이스 선언
    public GameObject player; // 플레이어 선언
    public Vector3Int currentPos; // 현재 위치 선언
    public Animator animator; // 애니메이터 선언 (현재는 죽은 변수, 추후에 사용 예정)
    public EdgeCollider2D edgeCollider; // EdgeCollider 선언
    private List<Vector3Int> toFreeze = new List<Vector3Int>(); // 얼릴 것들의 리스트 선언

    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // 타일맵 정의
        player = GameObject.Find("player"); // 플레이어 정의 
        animator = player.GetComponent<Animator>(); // 애니메이터 정의
        toFreeze.Clear(); // 리스트 초기화
        toFreeze.Add(new Vector3Int(-1, -2, 0)); // 리스트에 얼릴 수 있는 좌표 추가
        edgeCollider.enabled = true; // EdgeCollider 활성화
    }

    void Update()
{
    currentPos = tilemap.WorldToCell(player.transform.position);

    if (Input.GetKeyDown(KeyCode.E))
    {
        foreach (Vector3Int freezePos in toFreeze)
        {
            Vector3Int targetPos = currentPos + freezePos;
            TileBase currentTile = tilemap.GetTile(targetPos);

            // 이름에 "waterFall"이 있는지 확인
            if (currentTile != null && currentTile.name.Contains("waterFall"))
            {
                FreezeWater(targetPos);
            }
        }

        edgeCollider.enabled = false;
    }
    void Update()
{
    // 현재 플레이어의 타일 좌표를 받아옵니다.
    currentPos = tilemap.WorldToCell(player.transform.position);

    // Z 키가 눌렸을 때
    if (Input.GetKeyDown(KeyCode.Z))
    {
        // toFreeze 리스트에 있는 모든 위치에 대해 반복
        foreach (Vector3Int freezePos in toFreeze)
        {
            // 현재 위치에 대한 타일을 가져옵니다.
            Vector3Int targetPos = currentPos + freezePos;
            TileBase currentTile = tilemap.GetTile(targetPos);

            // 현재 타일이 존재하고 "waterFall", "waterFallMiddle", "waterFallEnd" 중 하나의 이름을 포함하고 있는지 확인
            if (currentTile != null && (currentTile.name == "waterFall" || currentTile.name == "waterFallMiddle" || currentTile.name == "waterFallEnd"))
            {
                // 현재 타일의 이름을 "iceFall"로 변경합니다.
                string newName = currentTile.name.Replace("waterFall", "iceFall");

                // FreezeWater 메서드 호출
                FreezeWater(targetPos);
            }
        }

        // 모든 얼음 생성이 완료되면 EdgeCollider 비활성화하여 지나갈 수 있게 함
        edgeCollider.enabled = false;
    }
}

    void FreezeWater(Vector3Int targetPos)
    {
    // 현재 타일을 "iceFall"로 교체
     tilemap.SwapTile(tilemap.GetTile(new Vector3Int(targetPos.x + 1, targetPos.y - 1, 0)), tilebase);

    // 다음 얼릴 타일의 초기 위치 설정
     Vector3Int currentTilePos = new Vector3Int(targetPos.x + 2, targetPos.y - 1, 0);

    // 인접한 타일을 확인하며 "waterFall", "waterFallMiddle", "waterFallEnd" 중 하나의 이름을 가진 경우 얼음으로 교체
        while (tilemap.GetTile(currentTilePos) != null && (tilemap.GetTile(currentTilePos).name == "waterFall" || tilemap.GetTile(currentTilePos).name == "waterFallMiddle" || tilemap.GetTile(currentTilePos).name == "waterFallEnd"))
        {
        // 현재 인접한 타일의 이름을 "iceFall"로 변경
        string newAdjacentName = tilemap.GetTile(currentTilePos).name.Replace("waterFall", "iceFall");

        // 인접한 타일을 "iceFall"로 교체
        tilemap.SwapTile(tilemap.GetTile(new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0)), tilebase);

        // 다음 인접한 타일로 이동
        currentTilePos = new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0);
        }
    }

    }
}