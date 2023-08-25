using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 mousePos, transPos, targetPos;
    Vector3 mousePos_rot, transPos_rot, targetPos_rot;


    public bool is_walk, is_left, is_right;
    public Animator animator;
    public SpriteRenderer rend;
    public string lastside;
    // Update is called once per frame

    private void Start()
    {
        //Camera = GameObject.Find("Camera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();
        animator.SetBool("right", false);
        animator.SetBool("left", false);
        animator.SetBool("up", false);
        animator.SetBool("down", false);
        animator.SetBool("walk", false);
        targetPos = new Vector3(0, 0, 0);
        is_left = false;
        is_right = false;
        lastside = "오른쪽";
    }
    void Update()
    {
        if (Input.GetMouseButton(1)) 
            {
                CalTargetPos();
                find();
                
        }
        MoveToTarget();
    }

    void CalTargetPos()
    {
        mousePos = Input.mousePosition;
        transPos = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos = new Vector3(transPos.x, transPos.y, 0);
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        if(targetPos == transform.position)
        {
            is_walk = true;
            stop_walking();
            is_walk = false;
        }
    }
    void stop_walking()
    {
        animator.SetBool("walk", false);
        if(is_left == true && is_right == false)
        {
            rend.flipX = true;
        }
    }
    void find()
    {
        mousePos_rot = Input.mousePosition;
        transPos_rot = Camera.main.ScreenToWorldPoint(mousePos);
        targetPos_rot = new Vector3(transPos.x, transPos.y, 0);
        Vector3 dir_rot = targetPos_rot - transform.position;
        dir_rot.y = 0;
        Quaternion rot = Quaternion.LookRotation(dir_rot.normalized);
        Vector3 MY = new Vector3(transform.position.x, transform.position.y, 0);
        //Debug.Log("마우스 포인터의 위치:"+ transPos_rot +"플레이어의 위치: " + MY);
        if (targetPos_rot.y > MY.y)
        {
            if (targetPos_rot.x > MY.x)
            {
                rend.flipX = false;
                Debug.Log("오른쪽 위로 이동");
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                is_right = true;
                //is_left = false;
                lastside = "1";
            }
            else if (targetPos_rot.x < MY.x)
            {
                Debug.Log("왼쪽 위로 위로 이동");
                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                is_right = false;
                //is_left = true;
                lastside = "2";
            }
        }else if (targetPos_rot.y < MY.y)
        {
            if (targetPos_rot.x > MY.x)
            {
                Debug.Log("오른쪽 아래로 이동");
                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                is_right = false;
                //is_left = false;
                lastside = "오른쪽";
            }
            else if (targetPos_rot.x < MY.x)
            {
                Debug.Log("왼쪽 아래로 이동");
                rend.flipX = false;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", false);
                is_right = true;
                //is_left = true;
                lastside = "왼쪽";
            }
        }

    }
}
