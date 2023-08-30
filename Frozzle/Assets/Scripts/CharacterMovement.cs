using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterMovement : MonoBehaviour
{
    public Tilemap map;
    MouseInput mouseInput;
    [SerializeField] private float movementSpeed;
    private Vector3 destination;

    public bool is_map, is_move;
    public bool is_walk, flip_check, is_right;
    public Animator animator;
    public SpriteRenderer rend;
    Vector3 mousePos, transPos, targetPos, targetPos_rot;

    private void Awake()
    {
        mouseInput = new MouseInput();
    }
    private void OnEnable()
    {
        mouseInput.Enable();
    }
    private void OnDisable()
    {
        mouseInput.Disable();
    }
    void Start()
    {
        destination = transform.position;
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick();

        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        flip_check = false;
        is_right = false;

    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>();
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3Int gridPosition = map.WorldToCell(mousePosition);
        if (map.HasTile(gridPosition))
        {
            destination = mousePosition;
        }
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, destination) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
            find();
        }
        else
        {
            is_walk = true;
            stop_walking();
            is_walk = false;
            if(flip_check == true)
            {
                rend.flipX = true;
                is_move = false;
            }
        }
        
    }
    void stop_walking()
    {
        animator.SetBool("walk", false);
    }

    void find()
    {
        targetPos_rot = new Vector3(destination.x, destination.y, 0);
        Vector3 dir_rot = targetPos_rot - transform.position;
        dir_rot.y = 0;
        Vector3 player_pos = new Vector3(transform.position.x, transform.position.y, 0);

        if (targetPos_rot.y > player_pos.y)
        {
            if (targetPos_rot.x > player_pos.x)
            {
                rend.flipX = false;

                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                is_right = true;
                flip_check = false;
            }
            else if (targetPos_rot.x < player_pos.x)
            {

                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                is_right = false;
                flip_check = true;
            }
        }
        else if (targetPos_rot.y < player_pos.y)
        {
            if (targetPos_rot.x > player_pos.x)
            {

                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                is_right = false;
                flip_check = true;
            }
            else if (targetPos_rot.x < player_pos.x)
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
