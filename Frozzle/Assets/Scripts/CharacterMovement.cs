using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour // ĳ���� �̵� �� �ִϸ��̼ǿ� ���̴� ��ũ��Ʈ
{
    public Grid grid;
    public Tilemap map; // Ÿ�ϸ� ����
    MouseInput mouseInput;  // ���콺 ��ǲ Ŭ���� ����
    [SerializeField] private float movementSpeed; // �����̴� ���ǵ�
    private Vector3 destination; // ���콺 Ŭ���� ��ġ

    public bool is_map, is_move; // �� �ȿ� �ִ°�, �����̴� ��
    public bool is_walk, flip_check, is_right; // �Ȱ��ֳ�, �ִϸ��̼� ���� �Ұų�, ������ ������ �����ֳ�
    public Animator animator; // �ִϸ��̼� ���� �ִϸ����� ����
    public SpriteRenderer rend; // ��������Ʈ ����
    Vector3 mousePos, transPos, targetPos, targetPos_rot; // Ÿ���� ���� ���� ����

    private void Awake()
    {
        mouseInput = new MouseInput(); // MouseInput ��ũ��Ʈ���� ������ ��ü ����
    }
    private void OnEnable() //��ũ��Ʈ�� Ȱ��ȭ �ɶ�
    {
        mouseInput.Enable(); // ���콺 ��ǲ Ȱ��ȭ
    }
    private void OnDisable() // ��ũ��Ʈ�� ��Ȱ��ȭ �ɶ�
    {
        mouseInput.Disable(); // ���콺 ��ǲ ��Ȱ��ȭ
    }
    void Start()
    {
        destination = transform.position; // ���� ���� ������Ʈ�� ������ �־���
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick(); // �Ƹ� ���콺 Ŭ�� �޼ҵ�� �������ִ� ���ε�?

        animator = GetComponent<Animator>(); // ���� ���� ������Ʈ�� �ִϸ����� ������Ʈ�� �����´�.
        rend = GetComponent<SpriteRenderer>(); // ���� ���� ������Ʈ�� ��������Ʈ������ ������Ʈ�� �����´�.
        flip_check = false; // �¿� ���� �Ұų�?
        is_right = false; // ������ ������ �����ֳ�?

        Vector3 initialPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        Vector3Int _targetCell = grid.WorldToCell(initialPosition);

        // Snap the player to the center of the initial cell
        Vector3 _targetPosition = grid.CellToWorld(_targetCell);

    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>(); // ���� ������ ���콺 ��ġ�� ���� �޾ƿ´�.
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // ī�޶� �������� ���콺 ������ �� �ٲ��ֱ�
        Vector3Int gridPosition = map.WorldToCell(mousePosition); // �׸��� ���� ���������� ��������
        if (map.HasTile(gridPosition)) // �׸��� �����ǿ� Ÿ���� �ִٸ�?
        {
            destination = map.WorldToCell(mousePosition); // ��ġ ���� ���콺 ������ �� �־��ֱ�
            Debug.Log(destination);
        }
        Vector3Int targetcell = grid.WorldToCell(mousePosition);
        Vector3 targetpos = grid.CellToWorld(targetcell);
        //destination = targetpos;
    }
    void Update()
    {

        if (Vector3.Distance(transform.position, destination) > 0.1f) // ���콺 ��ġ�� ���� ��ġ ������ �Ÿ��� 0.1���� ũ�ٸ�
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime); // �� ��ġ�� �̵�
            find(); // ���� ���� �ִϸ��̼� ���� �޼ҵ�
        }
        else // ĳ������ ��ġ�� ���콺 ��ġ�� ���ٸ�
        {
            is_walk = true; // �ѹ� �Ȱ� �ֵ� Ʈ�� ���ְ�
            stop_walking(); // �޼ҵ� �ѹ� �������ְ�
            is_walk = false; // �Ȱ��ִ� ������ ������ �ٲ��ֱ�
            if (flip_check == true) // �ݴ�� �¿���� ������ϴ� ��? Ʈ����
            {
                rend.flipX = true; // �¿�������ְ�
                is_move = false; // �����̱� �ߴ�
            }
        }

    }
    void stop_walking()
    {
        animator.SetBool("walk", false); // �ִϸ����ͤ��� walk ������ ������ �ٲ��ֱ�
    }

    void find()
    {
        targetPos_rot = new Vector3(destination.x, destination.y, 0); // ���콺 x,y ��ǥ ���� Ÿ�� ���� ������ �־��ֱ�, z���� 2d �ϱ� 0!
        Vector3 dir_rot = targetPos_rot - transform.position; // ���콺���� ���� ������ ���� ���� ��ġ �� ���ϱ�, �����ǿ� ��ġ, ���� �� �پ��� ���� ��� �־�
        dir_rot.y = 0;  // �̰� ���ߴ��� x ���� �ʿ��߳�����~~^^
        Vector3 player_pos = new Vector3(transform.position.x, transform.position.y, 0); // ���� �������� ���� �־��ֱ�

        if (targetPos_rot.y > player_pos.y) // ���࿡ Ÿ���� y ���� �÷��̾��� y ������ ũ�ٸ�? = ���콺 ��ġ�� �����̶��?
        {
            if (targetPos_rot.x > player_pos.x) // ���� ���콺 ��ġ�� �������̶��?
            {
                rend.flipX = false; // �̹� ������ �ִϸ����͸� �־�ּ� ������ �ʿ䰡 ���� ������ ����

                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                is_right = true;
                flip_check = false;
            }
            else if (targetPos_rot.x < player_pos.x) // ���� �����̰� �����뿡 ���콺 Ŭ���� �־������?
            {
                rend.flipX = true; // �¿���� �ϱ�, �ִϸ��̼��� ������ ���⸸ �־���� ������ ���� ������ ������ �¿���� true �ؾ���
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                is_right = false;
                flip_check = true;
            }
        }
        else if (targetPos_rot.y < player_pos.y) // y���� �Ʒ��� �ִٸ�, ���콺�� �Ʒ��ʿ� Ŭ�� �ƴٸ�?
        {
            if (targetPos_rot.x > player_pos.x) // ������ ������ Ŭ�����ִٸ�?
            {

                rend.flipX = true; // ���� �Ʒ��� ����� ���� �������� ���°Ű� �⺻���� �Ǿ��־ ������ ���� ������ ������ true �ؾ���
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                is_right = false;
                flip_check = true;
            }
            else if (targetPos_rot.x < player_pos.x) // ���� ���� Ŭ�� �Ǿ��ٸ�?
            {

                rend.flipX = false;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", false);
                is_right = true;
                flip_check = false;
            }
        }
    }
}