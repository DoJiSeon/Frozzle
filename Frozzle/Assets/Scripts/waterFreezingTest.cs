using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class waterFreezingTest : MonoBehaviour
{
    public Tilemap tilemap; // ������ �޾ƿ� Ÿ�ϸ� ����
    public TileBase tilebase; //�ٲ� Ÿ�� ���̽� ����
    public GameObject player; // �÷��̾� ����
    public Vector3Int currentPos; // ���� ��ġ ����
    public Animator animator; // �ִϸ����� ���� (����� ���� ����, ���Ŀ� ��� ����)
    public EdgeCollider2D edgeCollider; // EdgeCollider ����
    private List<Vector3Int> toFreeze = new List<Vector3Int>(); // �� �͵��� ����Ʈ ����
    //EdgeCollider�� ����ϴ� ������, ���� �帣�� �������� ���� ���ߴٰ� ���� ��� ������ �� �� �ְ� �ϴ� ����� �����ϴµ� ���� �����ϱ� ����

    void Start()
    {
        tilemap = GetComponent<Tilemap>(); // Ÿ�ϸ� ����
        player = GameObject.Find("player"); // �÷��̾� ���� 
        animator = player.GetComponent<Animator>(); // �ִϸ����� ����
        toFreeze.Clear(); // ����Ʈ �ʱ�ȭ
        toFreeze.Add(new Vector3Int(-1, -2, 0)); // ����Ʈ�� �� �� �ִ� ��ǥ �߰�
        edgeCollider.enabled = true; // EdgeCollider Ȱ��ȭ
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); // ���� ��ġ Ÿ�Ͽ� ���� �޾ƿ���
        if (Input.GetKeyDown(KeyCode.E)) // EŰ�� ������ ��
        {
            // Debug.Log(currentPos); // ���� ��ġ ����
            if (currentPos == toFreeze[0]) // ���� ��ġ�� �� �� �ִ� ��ġ���
            {
                // Debug.Log("Working"); // �������Դϴ�
                tilemap.SwapTile(tilemap.GetTile(new Vector3Int(toFreeze[0].x + 1, toFreeze[0].y - 1, 0)), tilebase); // �÷��̾��� ��ǥ�κ��� �����Ÿ���ŭ ������ �� Ÿ���� ��� Ÿ�Ϸ� �ٲ�
                Vector3Int currentTilePos = new Vector3Int(toFreeze[0].x + 2, toFreeze[0].y - 1, 0); // ��� �� Ÿ�� ������ �� Ÿ���� ��ġ�� ����
                // Debug.Log(tilemap.GetTile(currentTilePos).name == "waterFlowing"); // Test
                while (tilemap.GetTile(currentTilePos).name == "waterFlowing") // �������� �� Ÿ���� �̸��� waterFlowing�� ������ ���� (������ ���� ��� ��)
                {
                    tilemap.SwapTile(tilemap.GetTile(new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0)), tilebase); // �� ��ġ�� �� Ÿ���� ��� Ÿ�Ϸ� �ٲ�
                    currentTilePos = new Vector3Int(currentTilePos.x + 1, currentTilePos.y, 0); // ���� Ÿ���� ��ġ�� ���� ��ġ ����
                }
                edgeCollider.enabled = false; // �� ����ٸ� EdgeCollider�� ��Ȱ��ȭ�Ͽ� ������ �� �ְ� ����
            }
        }
}
}
