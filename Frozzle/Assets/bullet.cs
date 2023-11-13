
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed = 10f; // 총알 속도 변수
    public float distance = 0.5f; // 감지할 최대 거리 나타내는 변수, 기본값 0.5f
    public LayerMask isLayer; 

    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        float moveDirection = transform.rotation.eulerAngles.y == 0f ? 1f : -1f;
        transform.Translate(Vector3.right * moveDirection * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject); // 총알 오브젝트를 파괴
    } // 다른 Collider와 충돌했을 때 호출되는 메서드

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (isLayer == (isLayer | (1 << other.gameObject.layer))) // 충돌한 객체의 Layer가 isLayer에 해당하는지 확인
        {
            Destroy(gameObject);  // 총알 파괴
        }
    }
}
