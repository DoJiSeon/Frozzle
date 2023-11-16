
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
      bullet = Instantiate(bullet, transform.position, transform.rotation);
    }

   void Update()
   {
        if(curtime <= 0)// curtime이 0이하일 때만 Z키가 눌리게 하기.
        {
          if(Input.GetKey(KeyCode.Z))
            {
                Instantiate(bullet,pos.position,transform.rotation);
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
   }
} 



