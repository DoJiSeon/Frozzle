using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice_attack : MonoBehaviour
{
    public GameObject bullet;//총알 프리팹을 저장하는 GameObject 변수
    public Transform pos;//발사 위치 지정 Transform 변수
    public float cooltime;//발사 간 쿨타임
    private float curtime;//현재 쿨타임
    public GameObject newBullet;
    public Vector3 playerDirection;
    void Start()
    {
        
    }

    void Update()
    {
        if (curtime <=0)// 만약 현재 쿨타임이 0 이하일 경우
        {
            if (Input.GetKey(KeyCode.Z))//Z키를 누른 경우
        {
           Vector3 platerDirection =  transform.forward; // player의 현재 방향을 얻어서 그 방향으로 회전값을 만듦-> 그방향으로 총알 발사
            Quaternion playerRotation = Quaternion.LookRotation(playerDirection); 

            GameObject newBullet = Instantiate(bullet, pos.position, playerRotation); // 발사 위치(pos.position)와 방향(playerRotation)으로 총알을 발사

           curtime=cooltime;//현재 쿨타임을 설정된 쿨타임 값으로 초기화
        }
        }
        curtime-= Time.deltaTime;
    }
}

