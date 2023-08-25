using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToClick : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    Vector3 mousePos, transPos, targetPos;

    Vector2 MousePosition;
    Camera Camera;

    // Update is called once per frame

    private void Start()
    {
        Camera = GameObject.Find("Camera").GetComponent<Camera>();

    }
    void Update()
    {
        if (Input.GetMouseButton(1)) 
            {
                CalTargetPos();
                //exam();
            }
        MoveToTarget();

    }
    void exam()
    {
        MousePosition = Input.mousePosition;
        MousePosition = Camera.ScreenToWorldPoint(MousePosition);

        transform.position = MousePosition;
        
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
    }
}
