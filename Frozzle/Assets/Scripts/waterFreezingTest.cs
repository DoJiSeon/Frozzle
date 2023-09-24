using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class waterFreezingTest : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tilebase;
    public GameObject player;
    public Vector3Int currentPos;
    public Animator animator;

    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.Find("player");
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position);
        /*if (Input.GetKeyDown(KeyCode.E))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Left_up side anim"))
            {
                Debug.Log(new Vector3Int(currentPos.x, currentPos.y, 0));
                Debug.Log(tilemap.GetTile(new Vector3Int(currentPos.x, currentPos.y, 0)).name);

            }
        }*/
        // 알고리즘 구상중
        /* 현재 진행 상황 :
         * 현재 플레이어의 애니메이션 상황을 받아와서 각 방향 애니메이션을 판단
         * => 방향에 맞게 현재 플레이어의 위치 (WorldToCell 적용으로 좌표는 int값)을 보고 x나 y값에 +- 1을 하여 그 앞에 물이 있는지 판단
         * tilemap.GetTile(new Vector3Int(currentPos.x, currentPos.y, 0)).name가 그 역할
         * 그런데 up idle anim에서는 E키를 눌렀을 때 잘 작동하지만, 다른 걷는 애니메이션 상태일때는 감지를 못하는건지 작동하지 않음.
         * 그래서 이 방법은 넘겨두고, 다시 좌표로 보는 방법을 기용해 볼 생각임.
         * 기둥 식히는 기믹에 썼던 방법인데, 어차피 레벨마다 물의 위치는 정해져있으니 물을 얼릴 수 있는 좌표를 모두 리스트에 저장
         * 그 후 저장된 순서에 맞게 물 타일들을 또 리스트에 저장 (인덱스는 위치 리스트랑 맞춰서)
         * 그리고 플레이어의 위치를 프레임마다 판단하면서, 만약 얼릴 수 있는 위치라면 [E 얼리기] UI가 등장
         * 거기서 얼리면 물이 어는 구조
         * 물 어는 타일로 바꾸는 방법은 기둥 식히는 기믹과 똑같이 진행할 예정
         * 그래서 물 어는 방식도 정해야 함. 조만간 카톡 투표를 열어볼까 함. (2023 / 09 / 24 23:28)
         */
}
}
