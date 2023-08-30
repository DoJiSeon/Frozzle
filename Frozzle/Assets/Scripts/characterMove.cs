using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 mousePos, transPos, targetPos;
    Vector3 mousePos_rot, transPos_rot, targetPos_rot;

    // MAP CHECK VAR
    public bool is_map;
    Camera mainCam;
    Vector2 targetPosition;
    RaycastHit2D hit;

    public bool is_walk, flip_check, is_right;
    public Animator animator;
    public SpriteRenderer rend;
    public string lastside;

    private void Start()
    {
        //Camera = GameObject.Find("Camera").GetComponent<Camera>();
        animator = GetComponent<Animator>();
        rend = GetComponent<SpriteRenderer>();

        //animator.SetBool("right", false);
        //animator.SetBool("up", false);
        //animator.SetBool("walk", false);
        targetPos = transform.position;
        flip_check = false;
        is_right = false;
        lastside = "오른쪽";
        is_map = false;
        
    }
    void Update()
    {
        if (Input.GetMouseButton(1)) 
            {
                Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(worldPoint, Vector2.zero);
                CalTargetPos();
                find();
                groundCheck();
            
            
            
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
        Debug.Log("이동시작");
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        
        
        if(targetPos == transform.position)
        {
            is_walk = true;
            stop_walking();
            is_walk = false;
            if(flip_check == true)
            {
                rend.flipX = true;
          
            }
            
        }
    }
    void stop_walking()
    {
        animator.SetBool("walk", false);
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

        if (targetPos_rot.y > MY.y)
        {
            if (targetPos_rot.x > MY.x)
            {
                rend.flipX = false;
                
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                is_right = true;
                flip_check = false;
                lastside = "1";
            }
            else if (targetPos_rot.x < MY.x)
            {
                
                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                is_right = false;
                flip_check = true;
                lastside = "2";
            }
        }else if (targetPos_rot.y < MY.y)
        {
            if (targetPos_rot.x > MY.x)
            {
                
                rend.flipX = true;
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                is_right = false;
                flip_check = true;
                lastside = "오른쪽";
            }
            else if (targetPos_rot.x < MY.x)
            {
                
                rend.flipX = false;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", false);
                is_right = true;
                flip_check = false;
                lastside = "왼쪽";
            }
        }

    }

    void groundCheck()
    {
        
        if(hit.collider != null)
        {
            //targetPosition = hit.transform.position;
            if (GameObject.FindGameObjectWithTag("map"))
            {
                Debug.Log("맵 클릭 됨!");
                is_map = true;
            }
        }
    }
}
