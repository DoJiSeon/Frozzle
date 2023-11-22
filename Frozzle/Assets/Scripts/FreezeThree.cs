using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class FreezeThree : MonoBehaviour
{
    public GameObject player;
    public Animator playerAnim;
    public GameObject lens;
    public Tilemap tilemap;
    public Tilemap tilemapTwo;
    public TileBase smokingIce;
    public TileBase burningIce;
    public TileBase meltingIce;
    public List<GameObject> pages = new List<GameObject>();
    public float delay = 0.1f;
    public List<GameObject> lenses = new List<GameObject>();
    public List<TileBase> waterRoads = new List<TileBase>();
    public List<TileBase> waterFalls = new List<TileBase>();
    public List<TileBase> pond = new List<TileBase>();
    public List<TileBase> bridge = new List<TileBase>();
    public List<Vector3Int> lensInteraction = new List<Vector3Int>();
    public List<Vector3Int> ice = new List<Vector3Int>();
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
    private List<float> fallClimb = new List<float>();
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
        startInteraction.Add(new Vector3Int(-1, 0, 0));
        fallPosition.Add(new Vector3Int(-1, 0, 0));
        fallEndPosition.Add(new Vector3Int(3, 5, 0));
        isFallFrozen.Add(false);
        isFallFlip.Add(true);
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        fallClimb.Add(0.6f);
        innerDo.Add(new Vector3Int(0, 2, 0));
        fallEndTilePosition.Add(new Vector3Int(0, 2, 0));
        innerDo.Add(new Vector3Int(1, 3, 0));
        innerDo.Add(new Vector3Int(2, 4, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(2, -1, 0));
        pondInteraction.Add(new Vector3Int(2, -1, 0));
        innerDecide.Add("PondLeft");
        pondKind.Add("PondLeft");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeLeft");
        innerDo.Add(new Vector3Int(3, -1, 0));
        pondPosition.Add(new Vector3Int(3, -1, 0));
        innerDo.Add(new Vector3Int(4, -1, 0));
        lensInteraction.Add(new Vector3Int(5, -1, 0));
        ice.Add(new Vector3Int(8, -1, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(2, 6, 0));
        pondInteraction.Add(new Vector3Int(2, 6, 0));
        innerDecide.Add("PondRight");
        pondKind.Add("PondRight");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeRight");
        innerDo.Add(new Vector3Int(2, 7, 0));
        pondPosition.Add(new Vector3Int(2, 7, 0));
        innerDo.Add(new Vector3Int(2, 8, 0));
        ice.Add(new Vector3Int(12, 8, 0));
        lensInteraction.Add(new Vector3Int(9, 8, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(4, 8, 0));
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDo.Add(new Vector3Int(5, 8, 0));
        innerDo.Add(new Vector3Int(6, 8, 0));
        innerDo.Add(new Vector3Int(7, 8, 0));
        innerDo.Add(new Vector3Int(8, 8, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(7, 4, 0));
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDo.Add(new Vector3Int(8, 4, 0));
        innerDo.Add(new Vector3Int(9, 4, 0));
        innerDo.Add(new Vector3Int(10, 4, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(11, 4, 0));
        pondInteraction.Add(new Vector3Int(11, 4, 0));
        innerDecide.Add("PondLeft");
        pondKind.Add("PondLeft");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeLeft");
        innerDo.Add(new Vector3Int(12, 4, 0));
        pondPosition.Add(new Vector3Int(12, 4, 0));
        innerDo.Add(new Vector3Int(13, 4, 0));
        ice.Add(new Vector3Int(21, 4, 0));
        lensInteraction.Add(new Vector3Int(18, 4, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(25, 4, 0));
        fallPosition.Add(new Vector3Int(25, 4, 0));
        fallEndPosition.Add(new Vector3Int(31, 11, 0));
        isFallFrozen.Add(false);
        isFallFlip.Add(true);
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        fallClimb.Add(1.8f);
        innerDo.Add(new Vector3Int(26, 6, 0));
        fallEndTilePosition.Add(new Vector3Int(26, 6, 0));
        innerDo.Add(new Vector3Int(27, 7, 0));
        innerDo.Add(new Vector3Int(28, 8, 0));
        innerDo.Add(new Vector3Int(29, 9, 0));
        innerDo.Add(new Vector3Int(30, 10, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(30, 12, 0));
        pondInteraction.Add(new Vector3Int(30, 12, 0));
        innerDecide.Add("PondLeft");
        pondKind.Add("PondLeft");
        isPondFrozen.Add("no");
        innerDecide.Add("BridgeLeft");
        innerDo.Add(new Vector3Int(29, 12, 0));
        pondPosition.Add(new Vector3Int(29, 12, 0));
        innerDo.Add(new Vector3Int(28, 12, 0));
        ice.Add(new Vector3Int(33, 17, 0));
        lensInteraction.Add(new Vector3Int(30, 17, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(24, 12, 0));
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDecide.Add("RoadRight");
        innerDo.Add(new Vector3Int(24, 13, 0));
        innerDo.Add(new Vector3Int(24, 14, 0));
        innerDo.Add(new Vector3Int(24, 15, 0));
        innerDo.Add(new Vector3Int(24, 16, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        startInteraction.Add(new Vector3Int(26, 17, 0));
        fallPosition.Add(new Vector3Int(26, 17, 0));
        fallEndPosition.Add(new Vector3Int(31, 23, 0));
        isFallFrozen.Add(false);
        isFallFlip.Add(true);
        innerDecide.Add("FallEndRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallMiddleRight");
        innerDecide.Add("FallStartRight");
        fallClimb.Add(1.2f);
        innerDo.Add(new Vector3Int(27, 19, 0));
        fallEndTilePosition.Add(new Vector3Int(27, 19, 0));
        innerDo.Add(new Vector3Int(28, 20, 0));
        innerDo.Add(new Vector3Int(29, 21, 0));
        innerDo.Add(new Vector3Int(30, 22, 0));
        decideInteraction.Add(new List<string>(innerDecide));
        doInteraction.Add(new List<Vector3Int>(innerDo));
        innerDecide.Clear();
        innerDo.Clear();
        for (int i = 0; i < lensInteraction.Count; i++)
        {
            lenses[i].SetActive(false);
        }
        for (int i = 0; i < pages.Count; i++)
        {
            pages[i].SetActive(false);
        }
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

    IEnumerator climbingFall(float howMuch)
    {
        player.GetComponent<CharacterMovement>().enabled = false;
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = false;
        }
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y + howMuch + 0.5f, player.transform.position.z);
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

    IEnumerator downingFall(float howMuch)
    {
        player.GetComponent<CharacterMovement>().enabled = false;
        for (int i = 0; i < mapEdge.Count; i++)
        {
            mapEdge[i].enabled = false;
        }
        Vector3 target = new Vector3(player.transform.position.x, player.transform.position.y - howMuch - 1.5f, player.transform.position.z);
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

    IEnumerator changeIce(Vector3Int pos)
    {
        yield return new WaitForSeconds(0.5f);
        tilemapTwo.SetTile(pos, smokingIce);
        yield return new WaitForSeconds(1f);
        tilemapTwo.SetTile(pos, burningIce);
        yield return new WaitForSeconds(1f);
        tilemapTwo.SetTile(pos, meltingIce);
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
                    lens.SetActive(true);
                    pondSound.mute = false;
                    pondSound.Play();
                    hasLens = true;
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "yes" && pondKind[i] == "PondLeft")
                {
                    tilemap.SetTile(pondPosition[i], pond[3]);
                    isPondFrozen[i] = "empty";
                    lens.SetActive(true);
                    pondSound.mute = false;
                    pondSound.Play();
                    hasLens = true;
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "empty" && pondKind[i] == "PondRight")
                {
                    tilemap.SetTile(pondPosition[i], pond[4]);
                    isPondFrozen[i] = "yes";
                    lens.SetActive(false);
                    antiPondSound.mute = false;
                    antiPondSound.Play();
                    hasLens = false;
                } else if (currentPos == pondInteraction[i] && isPondFrozen[i] == "empty" && pondKind[i] == "PondLeft")
                {
                    tilemap.SetTile(pondPosition[i], pond[5]);
                    isPondFrozen[i] = "yes";
                    lens.SetActive(false);
                    antiPondSound.mute = false;
                    antiPondSound.Play();
                    hasLens = false;
                }
            }
            if (hasLens)
            {
                for (int i = 0; i < lensInteraction.Count; i++)
                {
                    if (currentPos == lensInteraction[i]) {
                        lenses[i].SetActive(true);
                        lens.SetActive(false);
                        antiPondSound.mute = false;
                        antiPondSound.Play();
                        StartCoroutine(changeIce(ice[i]));
                    }
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
                    StartCoroutine(climbingFall(fallClimb[i]));
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            for (int i = 0; i < fallPosition.Count; i++)
            {
                if (currentPos == fallEndPosition[i] && isFallFrozen[i])
                {
                    CharacterMovement.Instance.rend.flipX = isFallFlip[i];
                    CharacterMovement.Instance.destination = tilemap.GetCellCenterWorld(fallPosition[i]);
                    StartCoroutine(downingFall(fallClimb[i]));
                }
            }
        }
    }
}
