using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileGenerator : MonoBehaviour
{
    public GameObject treePondWithWater; // "treePondWithWater" 타일 프리팹
    public GameObject iceBridge; // "iceBridge" 타일 프리팹

    private GameObject currentTile; // 현재 타일 저장

    private void Start()
    {
        // 초기에는 "treePondWithWater" 타일을 생성하고 현재 타일로 설정
        currentTile = Instantiate(treePondWithWater, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        // 현재 타일 앞에 아무런 객체가 없으면 "iceBridge" 타일 생성
        RaycastHit hit;
        if (!Physics.Raycast(currentTile.transform.position, currentTile.transform.forward, out hit))
        {
            // 다른 객체가 감지되지 않으면 "iceBridge" 타일 생성
            currentTile = Instantiate(iceBridge, currentTile.transform.position + currentTile.transform.forward, Quaternion.identity);
        }
        else
        {
            // 다른 객체가 감지되면 생성을 멈춤 (원하는 동작 추가)
            Debug.Log("다른 객체 감지! 생성을 멈춥니다.");
        }
    }
}
