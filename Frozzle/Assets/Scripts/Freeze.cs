using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Freeze : MonoBehaviour
{
    public GameObject player;
    public Tilemap tilemap;
    public float delay = 0.1f;
    public List<TileBase> waterRoads = new List<TileBase>();
    public List<TileBase> waterFalls = new List<TileBase>();
    private List<Vector3Int> startInteraction = new List<Vector3Int>();
    private List<List<string>> decideInteraction = new List<List<string>>();
    private List<string> innerDecide = new List<string>();
    private List<List<Vector3Int>> doInteraction = new List<List<Vector3Int>>();
    private List<Vector3Int> innerDo = new List<Vector3Int>();
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.Find("player");
        startInteraction.Clear();
        doInteraction.Clear();
        Debug.Log("hello");
        startInteraction.Add(new Vector3Int(-1, -2, 0));
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        innerDecide.Add("CornerRight");
        innerDo.Add(new Vector3Int(0, -3, 0));
        innerDo.Add(new Vector3Int(1, -3, 0));
        innerDo.Add(new Vector3Int(2, -3, 0));
        innerDo.Add(new Vector3Int(3, -3, 0));
        innerDo.Add(new Vector3Int(4, -3, 0));
        innerDo.Add(new Vector3Int(6, -2, 0));
        innerDo.Add(new Vector3Int(7, -1, 0));
        innerDo.Add(new Vector3Int(8, 0, 0));
        innerDo.Add(new Vector3Int(9, 0, 0));
        Debug.Log("hello2");
        decideInteraction.Add(innerDecide);
        doInteraction.Add(innerDo);
    }

    IEnumerator freezeRoad(Vector3Int pos, int toChange)
    {
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, waterRoads[toChange]);
    }

    IEnumerator freezeFall(Vector3Int pos, int toChange)
    {
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, waterFalls[toChange]);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3Int currentPos = tilemap.WorldToCell(player.transform.position);
        if (Input.GetKeyDown(KeyCode.E) && waterRoads.Count > 0 && waterFalls.Count > 0)
        {
            delay = 0f;
            for (int i = 0; i < startInteraction.Count; i++)
            {
                Vector3Int currentPos = tilemap.WorldToCell(player.transform.position);
                if (startInteraction[i] == currentPos)
                {
                    for (int j = 0; j < decideInteraction[i].Count; j++)
                    {
                        if (decideInteraction[i][j] == "RoadRight")
                        {
                            StartCoroutine(freezeRoad(doInteraction[i][j], 0));
                        }
                        else if (decideInteraction[i][j] == "CornerRight")
                        {
                            StartCoroutine(freezeRoad(doInteraction[i][j], 1));
                        }
                        else if (decideInteraction[i][j] == "RoadLeft")
                        {
                            StartCoroutine(freezeRoad(doInteraction[i][j], 2));
                        }
                        else if (decideInteraction[i][j] == "CornerLeft")
                        {
                            StartCoroutine(freezeRoad(doInteraction[i][j], 3));
                        }
                        else if (decideInteraction[i][j] == "FallStartRight")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 0));
                        }
                        else if (decideInteraction[i][j] == "FallMiddleRight")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 1));
                        }
                        else if (decideInteraction[i][j] == "FallEndRight")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 2));
                        }
                        else if (decideInteraction[i][j] == "FallStartLeft")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 3));
                        }
                        else if (decideInteraction[i][j] == "FallMiddleLeft")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 4));
                        }
                        else if (decideInteraction[i][j] == "FallEndLeft")
                        {
                            StartCoroutine(freezeFall(doInteraction[i][j], 5));
                        }
                        delay += 0.1f;
                    }
                    break;
                }
            }
        }
    }
}
