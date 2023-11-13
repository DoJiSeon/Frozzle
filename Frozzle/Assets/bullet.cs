
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour
{
    public float speed = 10f; // 총알 속도 변수
    public float distance = 0.5f; // 감지할 최대 거리 나타내는 변수, 기본값 0.5f
    public LayerMask isLayer; 4
    private Transform playerTransform;// player의 좌표 저장할 변수 설정

    void Start()
    {
        Invoke("DestroyBullet", 2);

        playerTransform = GameObject.FindFameObjectWithTag("Player").transform; // player을 찾아서 좌표 가져옴 
    }

    void Update()
    {
        MoveBullet();
    }

    void MoveBullet()
    {
        Vector3 direction = playerTransform.position - transform.position; // player가 향하고 있는 방향을 구하고 그 방향으로 불렛이 이동
        direction.Normalize(); // 방향 정규화 -> 모든 방향의 벡터 길이 1로 만듦 -> 방향에 따른 이동 속도 같아지기 위해서
        float moveDirection = transform.rotation.eulerAngles.y == 0f ? 1f : -1f;
        transform.Translate(Vector3.right * moveDirection * speed * Time.deltaTime);
    }

    void DestroyBullet()
    {
        Destroy(gameObject); // 총알 오브젝트를 파괴
    } // 다른 Collider와 충돌했을 때 호출되는 메서드

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<treeFinal>() != null) //무시할 스크립트인 바닥타일 treeFinal을 가진 객체인 경우 걍 무시하기
        {
            return;
        }
        
        if (isLayer == (isLayer | (1 << other.gameObject.layer))) // 충돌한 객체의 Layer가 isLayer에 해당하는지 확인
        {
            Destroy(gameObject);  // 총알 파괴
        }
    }
}
