using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class lensPlease : MonoBehaviour
{
    public Tilemap tilemap; // ������ �޾ƿ� Ÿ�ϸ� ����
    public TileBase tilebase; //�ٲ� Ÿ�� ���̽� ����
    public TileBase tilebase_null_puddle; // �� �� ������
    public TileBase tilebase_puddle;// �׳� ������
    public GameObject player; // �÷��̾� ����
    public Vector3Int currentPos; // ���� ��ġ ����
    public bool has_lens;
    public bool insert_lens, is_collide_top, down_t;
    public List<bool> is_frozen;
    public GameObject player_lens, top_1_lens;
    public Animator animator; // �ִϸ����� ���� (����� ���� ����, ���Ŀ� ��� ����)
    //public EdgeCollider2D edgeCollider; // EdgeCollider ����
    private List<Vector3Int> toFreeze = new List<Vector3Int>(); // �� �͵��� ����Ʈ ����
    //EdgeCollider�� ����ϴ� ������, ���� �帣�� �������� ���� ���ߴٰ� ���� ��� ������ �� �� �ְ� �ϴ� ����� �����ϴµ� ���� �����ϱ� ����

    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // Ÿ�ϸ� ����
        player = GameObject.Find("player"); // �÷��̾� ���� 
        animator = player.GetComponent<Animator>(); // �ִϸ����� ����
        toFreeze.Clear(); // ����Ʈ �ʱ�ȭ
        toFreeze.Add(new Vector3Int(4, 1, 0)); // ����Ʈ�� �� �� �ִ� ��ǥ �߰�
        //edgeCollider.enabled = true; // EdgeCollider Ȱ��ȭ
        has_lens = false;
        is_frozen.Add(false);
        player_lens.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); // ���� ��ġ Ÿ�Ͽ� ���� �޾ƿ���
        if (Input.GetKeyDown(KeyCode.Y)) // EŰ�� ������ ��
        {
            // Debug.Log(currentPos); // ���� ��ġ ����
            if (currentPos == toFreeze[0] && is_frozen[0] == false) // ���� ��ġ�� �� �� �ִ� ��ġ���
            {
                Debug.Log("Working"); // �������Դϴ�
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
