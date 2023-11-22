using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class Freeze : MonoBehaviour
{
    public GameObject player;
    public Animator playerAnim;
    public GameObject lens;
    public Tilemap tilemap;
    public float delay = 0.1f;
    public List<TileBase> waterRoads = new List<TileBase>();
    public List<TileBase> waterFalls = new List<TileBase>();
    public List<TileBase> pond = new List<TileBase>();
    public List<TileBase> bridge = new List<TileBase>();
    public List<EdgeCollider2D> edge = new List<EdgeCollider2D>();
    public List<EdgeCollider2D> mapEdge = new List<EdgeCollider2D>();
    public AudioSource freezeRoadSound;
    public AudioSource pondSound;
    public AudioSource antiPondSound;
    private List<Vector3Int> startInteraction = new List<Vector3Int>();
    private List<Vector3Int> pondInteraction = new List<Vector3Int>();
    private List<Vector3Int> pondPosition = new List<Vector3Int>();
    private List<Vector3Int> fallPosition = new List<Vector3Int>();
    private List<bool> isFallFlip = new List<bool>();
    private List<Vector3Int> fallEndTilePosition = new List<Vector3Int>();
    private List<bool> isFallFrozen = new List<bool>();
    private List<Vector3Int> fallEndPosition = new List<Vector3Int>();
    private List<string> isPondFrozen = new List<string>();
    private List<string> pondKind = new List<string>();
    private List<List<string>> decideInteraction = new List<List<string>>();
    private List<string> innerDecide = new List<string>();
    private List<List<Vector3Int>> doInteraction = new List<List<Vector3Int>>();
    private List<Vector3Int> innerDo = new List<Vector3Int>();

    bool hasLens = false;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        player = GameObject.Find("player");
        lens.SetActive(false);
        startInteraction.Clear();
        doInteraction.Clear();
        Debug.Log("hello");
        startInteraction.Add(new Vector3Int(3, -1, 0));
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDo.Add(new Vector3Int(4, -1, 0));
        innerDo.Add(new Vector3Int(5, -1, 0));
        innerDo.Add(new Vector3Int(6, -1, 0));
        innerDo.Add(new Vector3Int(7, -1, 0));
        innerDo.Add(new Vector3Int(8, -1, 0));
        innerDo.Add(new Vector3Int(9, -1, 0));
        innerDo.Add(new Vector3Int(10, -1, 0));
        innerDo.Add(new Vector3Int(11, -1, 0));
        Debug.Log("hello2");
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(9, 2, 0));
        fallPosition.Add(new Vector3Int(9, 2, 0));
        fallEndPosition.Add(new Vector3Int(13, 7, 0));
        isFallFrozen.Add(false);
        isFallFlip.Add(true);
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        innerDo.Add(new Vector3Int(10, 4, 0));
        fallEndTilePosition.Add(new Vector3Int(10, 4, 0));
        innerDo.Add(new Vector3Int(11, 5, 0));
        innerDo.Add(new Vector3Int(12, 6, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(11, 7, 0));
        pondInteraction.Add(new Vector3Int(11, 7, 0));
        innerDecide.Add("PondLeft");
        pondKind.Add("PondLeft");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeLeft");
        innerDo.Add(new Vector3Int(9, 7, 0));
        pondPosition.Add(new Vector3Int(9, 7, 0));
        innerDo.Add(new Vector3Int(8, 7, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(5, 7, 0));
        pondInteraction.Add(new Vector3Int(5, 7, 0));
        innerDecide.Add("PondLeft");
        pondKind.Add("PondLeft");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeLeft");
        innerDo.Add(new Vector3Int(3, 7, 0));
        pondPosition.Add(new Vector3Int(3, 7, 0));
        innerDo.Add(new Vector3Int(2, 7, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(-2, 7, 0));
        fallPosition.Add(new Vector3Int(-2, 7, 0));
        fallEndPosition.Add(new Vector3Int(2, 12, 0));
        isFallFrozen.Add(false);
        isFallFlip.Add(true);
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        innerDecide.Add("CornerRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDo.Add(new Vector3Int(-1, 9, 0));
        fallEndTilePosition.Add(new Vector3Int(-1, 9, 0));
        innerDo.Add(new Vector3Int(0, 10, 0));
        innerDo.Add(new Vector3Int(1, 11, 0));
        innerDo.Add(new Vector3Int(1, 12, 0));
        innerDo.Add(new Vector3Int(2, 12, 0));
        innerDo.Add(new Vector3Int(3, 12, 0));
        innerDo.Add(new Vector3Int(4, 12, 0));
        innerDo.Add(new Vector3Int(5, 12, 0));
        innerDo.Add(new Vector3Int(6, 12, 0));
        innerDo.Add(new Vector3Int(7, 12, 0));
        innerDo.Add(new Vector3Int(8, 12, 0));
        innerDo.Add(new Vector3Int(9, 12, 0));
        innerDo.Add(new Vector3Int(10, 12, 0));
        innerDo.Add(new Vector3Int(11, 12, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
    }

    IEnumerator freezeRoad(Vector3Int pos, int toChange)
    {
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, waterRoads[toChange]);
    }

    IEnumerator freezeFall(Vector3Int pos, int toChange)
    {
        for (int i = 0; i < fallEndTilePosition.Count; i++)
        {
            if (fallEndTilePosition[i] == pos)
            {
                isFallFrozen[i] = true;
            }
        }
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, waterFalls[toChange]);
    }

    IEnumerator freezePond(Vector3Int pos, int toChange)
    {
        for (int i = 0; i < pondPosition.Count; i++)
        {
            if (pondPosition[i] == pos)
            {
                isPondFrozen[i] = "yes";
            }
        }
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, pond[toChange]);
    }

    IEnumerator makeRoad(Vector3Int pos, int toChange)
    {
        yield return new WaitForSeconds(delay);
        tilemap.SetTile(pos, bridge[toChange]);
    }

    IEnumerator climbingFall()
    {
        player.GetComponent<CharacterMovement>().enabled = false;
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = false;
        }
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y + 1.5f, player.transform.position.z);
        Debug.Log("entered");
        playerAnim.SetBool("endClimb", false);
        playerAnim.SetBool("climb", true);
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("climbing", true);
        playerAnim.SetBool("climb", false);
        while (player.transform.position.y < target.y)
        {
            Debug.Log("this");
            yield return null;
            player.transform.position = Vector3.MoveTowards(player.transform.position, target, 1 * Time.deltaTime);
        }
        playerAnim.SetBool("climbed", true);
        playerAnim.SetBool("climbing", false);
        Vector3 targetTwo = new Vector3(player.transform.position.x, target.y + 0.5f, player.transform.position.z);
        while (player.transform.position.y < targetTwo.y)
        {
            Debug.Log("this");
            yield return null;
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetTwo, 1 * Time.deltaTime);
        }
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = true;
        }
        yield return new WaitForSeconds(1f);
        player.GetComponent<CharacterMovement>().enabled = true;
        playerAnim.SetBool("endClimb", true);
        playerAnim.SetBool("climbed", false);
    }

    IEnumerator downingFall()
    {
        player.GetComponent<CharacterMovement>().enabled = false;
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = false;
        }
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y - 1.5f, player.transform.position.z);
        Debug.Log("entered");
        playerAnim.SetBool("endClimb", false);
        playerAnim.SetBool("climb", true);
        yield return new WaitForSeconds(1f);
        playerAnim.SetBool("climbing", true);
        playerAnim.SetBool("climb", false);
        while (player.transform.position.y > target.y)
        {
            Debug.Log("this");
            yield return null;
            player.transform.position = Vector3.MoveTowards(player.transform.position, target, 1 * Time.deltaTime);
        }
        playerAnim.SetBool("climbed", true);
        playerAnim.SetBool("climbing", false);
        Vector3 targetTwo = new Vector3(player.transform.position.x, target.y - 0.5f, player.transform.position.z);
        while (player.transform.position.y < targetTwo.y)
        {
            Debug.Log("this");
            yield return null;
            player.transform.position = Vector3.MoveTowards(player.transform.position, targetTwo, 1 * Time.deltaTime);
        }
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = true;
        }
        yield return new WaitForSeconds(1f);
        player.GetComponent<CharacterMovement>().enabled = true;
        playerAnim.SetBool("endClimb", true);
        playerAnim.SetBool("climbed", false);
    }


    // Update is called once per frame
    void Update()
    {
        //Vector3Int currentPos = tilemap.WorldToCell(player.transform.position);
        Vector3Int currentPos = tilemap.WorldToCell(player.transform.position);
        if (Input.GetKeyDown(KeyCode.E))
        {
            for (int i = 0; i < startInteraction.Count; i++)
            {
                if (startInteraction[i] == currentPos)
                {
                    edge[i].enabled = false;
                    freezeRoadSound.mute = false;
                    freezeRoadSound.Play();
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
                        else if (decideInteraction[i][j] == "PondRight")
                        {
                            StartCoroutine(freezePond(doInteraction[i][j], 0));
                        }
                        else if (decideInteraction[i][j] == "PondLeft")
                        {
                            StartCoroutine(freezePond(doInteraction[i][j], 1));
                        }
                        else if (decideInteraction[i][j] == "BridgeRight")
                        {
                            StartCoroutine(makeRoad(doInteraction[i][j], 0));
                        }
                        else if (decideInteraction[i][j] == "BridgeLeft")
                        {
                            StartCoroutine(makeRoad(doInteraction[i][j], 1));
                        }

                        delay += 0.1f;
                    }
                    break;
                }
            }
        }
        Vector3 headPos = new Vector3(player.transform.position.x, player.transform.position.y + 0.5f, player.transform.position.z);
        lens.transform.position = headPos;

        if (Input.GetKeyDown(KeyCode.T))
        {
            for (int i = 0; i < pondInteraction.Count; i++)
            {
                Debug.Log(decideInteraction[i][0]);
                if (currentPos == pondInteraction[i] && isPondFrozen[i] == "yes" && pondKind[i] == "PondRight")
                {
                    tilemap.SetTile(pondPosition[i], pond[2]);
                    isPondFrozen[i] = "empty";
                    pondSound.mute = false;
                    pondSound.Play();
                    lens.SetActive(true);
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "yes" && pondKind[i] == "PondLeft")
                {
                    tilemap.SetTile(pondPosition[i], pond[3]);
                    isPondFrozen[i] = "empty";
                    pondSound.mute = false;
                    pondSound.Play();
                    lens.SetActive(true);
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "empty" && pondKind[i] == "PondRight")
                {
                    tilemap.SetTile(pondPosition[i], pond[4]);
                    isPondFrozen[i] = "yes";
                    antiPondSound.mute = false;
                    antiPondSound.Play();
                    lens.SetActive(false);
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "empty" && pondKind[i] == "PondLeft")
                {
                    tilemap.SetTile(pondPosition[i], pond[5]);
                    isPondFrozen[i] = "yes";
                    antiPondSound.mute = false;
                    antiPondSound.Play();
                    lens.SetActive(false);
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            for (int i = 0; i < fallPosition.Count; i++)
            {
                if (currentPos == fallPosition[i] && isFallFrozen[i])
                {
                    CharacterMovement.Instance.rend.flipX = isFallFlip[i];
                    CharacterMovement.Instance.destination = tilemap.GetCellCenterWorld(fallEndPosition[i]);
                    StartCoroutine(climbingFall());
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = 0; i < fallPosition.Count; i++)
            {
                Vector3Int targetPos = new Vector3Int(fallEndPosition[i].x, fallEndPosition[i].y - 1, fallEndPosition[i].z);
                if (currentPos == targetPos && isFallFrozen[i])
                {
                    CharacterMovement.Instance.rend.flipX = isFallFlip[i];
                    CharacterMovement.Instance.destination = tilemap.GetCellCenterWorld(fallPosition[i]);
                    StartCoroutine(downingFall());
                }
            }
        }
    }
}
