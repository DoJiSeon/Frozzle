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
        // �˰��� ������
        /* ���� ���� ��Ȳ :
         * ���� �÷��̾��� �ִϸ��̼� ��Ȳ�� �޾ƿͼ� �� ���� �ִϸ��̼��� �Ǵ�
         * => ���⿡ �°� ���� �÷��̾��� ��ġ (WorldToCell �������� ��ǥ�� int��)�� ���� x�� y���� +- 1�� �Ͽ� �� �տ� ���� �ִ��� �Ǵ�
         * tilemap.GetTile(new Vector3Int(currentPos.x, currentPos.y, 0)).name�� �� ����
         * �׷��� up idle anim������ EŰ�� ������ �� �� �۵�������, �ٸ� �ȴ� �ִϸ��̼� �����϶��� ������ ���ϴ°��� �۵����� ����.
         * �׷��� �� ����� �Ѱܵΰ�, �ٽ� ��ǥ�� ���� ����� ����� �� ������.
         * ��� ������ ��Ϳ� ��� ����ε�, ������ �������� ���� ��ġ�� ������������ ���� �� �� �ִ� ��ǥ�� ��� ����Ʈ�� ����
         * �� �� ����� ������ �°� �� Ÿ�ϵ��� �� ����Ʈ�� ���� (�ε����� ��ġ ����Ʈ�� ���缭)
         * �׸��� �÷��̾��� ��ġ�� �����Ӹ��� �Ǵ��ϸ鼭, ���� �� �� �ִ� ��ġ��� [E �󸮱�] UI�� ����
         * �ű⼭ �󸮸� ���� ��� ����
         * �� ��� Ÿ�Ϸ� �ٲٴ� ����� ��� ������ ��Ͱ� �Ȱ��� ������ ����
         * �׷��� �� ��� ��ĵ� ���ؾ� ��. ������ ī�� ��ǥ�� ����� ��. (2023 / 09 / 24 23:28)
         */
}
}
