using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform pos;
    void Start()
    {
        
    }

    void Update()
    {
    
        if (Input.GetKey(KeyCode.Z))
        {
            Instantiate(bullet,pos.position,transform.rotation);
        }
    }
}
