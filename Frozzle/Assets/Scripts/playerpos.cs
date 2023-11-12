using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class playerpos : MonoBehaviour
{
    public Tilemap tilemap;
    public GameObject player;
    public Vector3 currentPos;
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = tilemap.WorldToCell(player.transform.position);
        Debug.Log(currentPos);
    }
}
