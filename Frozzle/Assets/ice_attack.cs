using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    public float cooltime;
    private float curtime;
    void Start()
    {
        
    }

    void Update()
    {
        if (curtime <=0)
        {
            if (Input.GetKey(KeyCode.Z))
        {
            Instantiate(bullet,pos.position,transform.rotation);
        }
        curtime=cooltime;
        }
        curtime-= Time.deltaTime;
    }
}
