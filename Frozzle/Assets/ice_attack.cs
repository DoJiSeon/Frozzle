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
    void Start()
    {
        
    }

    void Update()
    {
        if (curtime <=0)// 만약 현재 쿨타임이 0 이하일 경우
        {
            if (Input.GetKey(KeyCode.Z))//Z키를 누른 경우
        {
            newBullet = Instantiate(bullet,pos.position,transform.rotation);// 총알을 pos 위치에 생성->현재 객체의 회전을 사용해 발사
            Destroy(newBullet, 2f ); // 총알 2초 후에 파괴됨
        }
        curtime=cooltime;//현재 쿨타임을 설정된 쿨타임 값으로 초기화
        }
        curtime-= Time.deltaTime;
    }
}
