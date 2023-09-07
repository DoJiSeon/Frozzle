using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    public float distance=0.5f;
    
    public LayerMask isLayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyBullet",2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast (transform.position, transform.right, distance, isLayer);
        if(ray.collider != null)
        {
            if(ray.collider.tag == "Water")
            {
                Debug.Log("Freezing!!!");
            }
            DestroyBullet();
        }
        if(transform.rotation.y == 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        }
        
    }

    void DestroyBullet()
    {
        DestroyBullet();//파괴할 오브젝트
    }
}
