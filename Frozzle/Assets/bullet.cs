

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class bullet : MonoBehaviour
{
    public float speed;
    public float distance;
    public LayerMask isLayer;
    void Start()
    {
        Invoke("DestroyBullet",2);//invoke("실행 할 함수명", 지연시간)
    }

    void Update()
    {
	    RaycastHit2D ray = Physics2D.Raycast(transform.position,transform.right,distance,isLayer);
	   
        if(ray.collider != null)
	{
		if(ray.collider.tag == "water")// 조건문으로 부딪힌 물체 태그가 water일 때 로그를 찍게 함
	{
		Debug.Log("waterfreezing!!!");
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
        Destroy(gameObject);// Destroy(파괴할 오브젝트)
    }
}
