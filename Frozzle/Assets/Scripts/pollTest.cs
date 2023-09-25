using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class pollTest : MonoBehaviour
{
    //Tilemap tilemap; -> Ÿ�ϸ�
    //Vector3 localPos -> ���� ������
    //Vector3 worldPos -> ���� ������
    // Start is called before the first frame update
    public Tilemap tilemap; //������ �޾ƿ� Ÿ�ϸ� ����
    public TileBase animatedTile; //Ÿ�� ���̽� (���� �޼��� �ٲ� Ÿ��) ����
    public GameObject player; //�÷��̾� ����
    public Vector3 currentPos; //Vector3Ÿ���� ���� ��ġ ����
    public List<Vector3> toCool = new List<Vector3>(); //��յ��� ���� ����(�÷��̾��� ��ġ)�� ���� ����Ʈ ����
    
    
    void Start()
    {
        tilemap = GetComponent<Tilemap>(); //Ÿ�ϸ� ����
        toCool.Clear(); // ����Ʈ Ŭ����
        toCool.Add(new Vector3Int(4, 0, 0)); //����Ʈ�� ����� ���� �� �ִ� �÷��̾� ��ġ �߰�
        player = GameObject.Find("player"); //�÷��̾� ����
    }
    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position); //���� ��ġ�� ������ ��, Ÿ�ϸʿ� �°� Ÿ����ǥ�� �ٲ�
        //WorldToCell�� ����ϸ�, (0.1, 0.88, -1.2)���� ������ ��ǥ�� (0,0,-1)���� Ÿ��(��) ��ǥ�� �ٲ���
        if (Input.GetKeyDown(KeyCode.A)) //AŰ�� �����ٸ�
        {
            Debug.Log(currentPos); //���� ��ġ �ֿܼ� ���
            if (currentPos.x >= (toCool[0].x - 1) && currentPos.x <= (toCool[0].x + 1) && currentPos.y >= (toCool[0].y - 1) && currentPos.y <= (toCool[0].y + 1)) //�׸��� ���� ��ġ�� ����� ���� �� �ִ� ��ġ���
            {
                tilemap.SwapTile(tilemap.GetTile(new Vector3Int(4, -1, 0)), animatedTile); //����� AnimatedTile�� �ٲ� �Ĵ� �ִϸ��̼� ����
                //�� ��, AnimatedTile�� Flags�Ӽ��� Loop Once�� �־� �ѹ� �ִϸ��̼� ���� �� ����ä�� ��������
            }
        }
    }
}
