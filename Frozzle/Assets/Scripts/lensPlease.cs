using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class lensPlease : MonoBehaviour
{
    public Tilemap tilemap; // 정보를 받아올 타일맵 선언
    public TileBase tilebase; //바꿀 타일 베이스 선언
    public TileBase tilebase_null_puddle; // 텅 빈 웅덩이
    public TileBase tilebase_puddle;// 그냥 웅덩이
    public GameObject player; // 플레이어 선언
    public Vector3Int currentPos; // 현재 위치 선언
    public bool has_lens;
    public bool insert_lens, is_collide_top, down_t;
    public List<bool> is_frozen;
    public GameObject player_lens, top_1_lens;
    public Animator animator; // 애니메이터 선언 (현재는 죽은 변수, 추후에 사용 예정)
    //public EdgeCollider2D edgeCollider; // EdgeCollider 선언
    private List<Vector3Int> toFreeze = new List<Vector3Int>(); // 얼릴 것들의 리스트 선언
    //EdgeCollider를 사용하는 이유는, 물이 흐르고 있을때는 가지 못했다가 물이 얼고 나서는 갈 수 있게 하는 기능을 구현하는데 가장 적합하기 때문

    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // 타일맵 정의
        player = GameObject.Find("player"); // 플레이어 정의 
        animator = player.GetComponent<Animator>(); // 애니메이터 정의
        toFreeze.Clear(); // 리스트 초기화
        toFreeze.Add(new Vector3Int(4, 1, 0)); // 리스트에 얼릴 수 있는 좌표 추가
        //edgeCollider.enabled = true; // EdgeCollider 활성화
        has_lens = false;
        is_frozen.Add(false);
        player_lens.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); // 현재 위치 타일에 맞춰 받아오고
        if (Input.GetKeyDown(KeyCode.Y)) // E키가 눌렸을 때
        {
            // Debug.Log(currentPos); // 현재 위치 띄우기
            if (currentPos == toFreeze[0] && is_frozen[0] == false) // 현재 위치가 얼릴 수 있는 위치라면
            {
                Debug.Log("Working"); // 실행중입니다
                tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[0].x + 1, toFreeze[0].y, 0)), tilebase);
                StartCoroutine("change_puddle", 0);
                is_frozen[0] = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.T))
        {

            if(currentPos == toFreeze[0] && is_frozen[0] == true)
            {
                if (!has_lens)
                {
                    Debug.Log("get lens");
                    tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[0].x + 1, toFreeze[0].y, 0)), tilebase_null_puddle);
                    has_lens = true;
                    
                }
                else
                {
                    has_lens = false;
                    player_lens.SetActive(false);
                    tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[0].x + 1, toFreeze[0].y, 0)), tilebase_puddle);
                }
            }
        }
        if (has_lens)
        {
            get_lens();
        }

        is_collide_top = PlayerManager.Instance.coiide_top;
        if (has_lens)
        {
            if(is_collide_top && Input.GetKeyDown(KeyCode.B))
            {
                top_1_lens.SetActive(true);
                has_lens = false;
                player_lens.SetActive(false);
            }
        }
    }

    IEnumerator change_puddle(int number)
    {
        yield return new WaitForSeconds(1.5f);
        tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[number].x + 1, toFreeze[number].y, 0)), tilebase_puddle);
        
    }
    private void get_lens()
    {

        Vector3 player_head = new Vector3(player.transform.position.x, player.transform.position.y+ 0.5f, transform.position.z);
        player_lens.transform.position = player_head;
        player_lens.SetActive(true);
        ;
    }
}
