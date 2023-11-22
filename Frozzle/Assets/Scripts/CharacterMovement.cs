using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CharacterMovement : MonoBehaviour // ĳ���� �̵� �� �ִϸ��̼ǿ� ���̴� ��ũ��Ʈ
{
    public Grid grid;
    public Tilemap map; // Ÿ�ϸ� ����
    MouseInput mouseInput;  // ���콺 ��ǲ Ŭ���� ����
    [SerializeField] private float movementSpeed; // �����̴� ���ǵ�
    public Vector3 destination; // ���콺 Ŭ���� ��ġ

    public bool is_map, is_move; // �� �ȿ� �ִ°�, �����̴� ��
    public bool is_walk, flip_check, is_right; // �Ȱ��ֳ�, �ִϸ��̼� ���� �Ұų�, ������ ������ �����ֳ�
    public Animator animator; // �ִϸ��̼� ���� �ִϸ����� ����
    public SpriteRenderer rend; // ��������Ʈ ����
    Vector3 mousePos, transPos, targetPos, targetPos_rot; // Ÿ���� ���� ���� ����

    public Vector3Int currentPos;
    public Tilemap tilemap;
    public GameObject player;

    public bool walkSound = false;

    public bool up_spell_check, right_spell_check, can_spell;

    public ParticleSystem particle;

    public static CharacterMovement _instance;
    public static CharacterMovement Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(CharacterMovement)) as CharacterMovement;
                if (_instance == null)
                    Debug.Log("no singleton obj");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        mouseInput = new MouseInput(); // MouseInput ��ũ��Ʈ���� ������ ��ü ����
    }
    private void OnEnable() //��ũ��Ʈ�� Ȱ��ȭ �ɶ�
    {
        mouseInput.Enable(); // ���콺 ��ǲ Ȱ��ȭ
    }
    private void OnDisable() // ��ũ��Ʈ�� ��Ȱ��ȭ �ɶ�
    {
        mouseInput.Disable(); // ���콺 ��ǲ ��Ȱ��ȭ
    }
    void Start()
    {
        destination = transform.position; // ���� ���� ������Ʈ�� ������ �־���
        mouseInput.Mouse.MouseClick.performed += _ => MouseClick(); // �Ƹ� ���콺 Ŭ�� �޼ҵ�� �������ִ� ���ε�?

        animator = GetComponent<Animator>(); // ���� ���� ������Ʈ�� �ִϸ����� ������Ʈ�� �����´�.
        rend = GetComponent<SpriteRenderer>(); // ���� ���� ������Ʈ�� ��������Ʈ������ ������Ʈ�� �����´�.
        flip_check = false; // �¿� ���� �Ұų�?
        is_right = false; // ������ ������ �����ֳ�?
        up_spell_check = false;
        right_spell_check = false;
        can_spell = false;

        tilemap = GetComponent<Tilemap>();
        player = GameObject.Find("player");
        particle = GetComponentInChildren<ParticleSystem>();
    }

    private void MouseClick()
    {
        Vector2 mousePosition = mouseInput.Mouse.MousePosition.ReadValue<Vector2>(); // ���� ������ ���콺 ��ġ�� ���� �޾ƿ´�.
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); // ī�޶� �������� ���콺 ������ �� �ٲ��ֱ�
        Vector3Int gridPosition = map.WorldToCell(mousePosition); // �׸��� ���� ���������� ��������
        if (map.HasTile(gridPosition)) // �׸��� �����ǿ� Ÿ���� �ִٸ�?
        {
            destination = mousePosition; // ��ġ ���� ���콺 ������ �� �־��ֱ�
            // Debug.Log(destination);
        }
        CastRay();
    }
    void CastRay()
    {
        int layermask = 1 << LayerMask.NameToLayer("load");
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        // Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity,layermask)
        RaycastHit2D hit2 = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, LayerMask.GetMask("load"));
        if (hit2.collider != null) // hit.collider != null
        {
            Debug.Log(hit.collider.gameObject.tag);
            if (hit.collider.gameObject.tag == "map")
            {
                GameObject touchObj = hit2.transform.gameObject;
                Vector3 touchpos = touchObj.transform.position;
                destination = touchpos;
            }

        }
    }


    void Update()
    {
        //currentPos = tilemap.WorldToCell(player.transform.position);
        //Debug.Log(currentPos);

        if (Vector3.Distance(transform.position, destination) > 0.1f) // ���콺 ��ġ�� ���� ��ġ ������ �Ÿ��� 0.1���� ũ�ٸ�
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime); // �� ��ġ�� �̵�
            find(); // ���� ���� �ִϸ��̼� ���� �޼ҵ�
            if (animator.GetBool("infall") == true)
            {
                animator.SetBool("infallmoving", true);

            }
        }
        else // ĳ������ ��ġ�� ���콺 ��ġ�� ���ٸ�
        {
            is_walk = true; // �ѹ� �Ȱ� �ֵ� Ʈ�� ���ְ�
            stop_walking(); // �޼ҵ� �ѹ� �������ְ�
            is_walk = false; // �Ȱ��ִ� ������ ������ �ٲ��ֱ�
            if (flip_check == true) // �ݴ�� �¿���� ������ϴ� ��? Ʈ����
            {
                rend.flipX = true; // �¿�������ְ�
                is_move = false; // �����̱� �ߴ�
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("spell_t");
                spell();
            }
            animator.SetBool("infallmoving", false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "top1")
        {
            Debug.Log("ž�� �΋H���� ���� ><");
            PlayerManager.Instance.check_collide_top();
        }
        //else if (collision.gameObject.name == "paper1")
        //{
        //    PlayerPrefs.SetInt("clear_stage", 1);
        //    SceneManager.LoadScene("tutorial");
        //    //int clear_stage = PlayerPrefs.GetInt("clear_stage");
        //    //Debug.Log(clear_stage);
        //}
        //else if (collision.gameObject.name == "paper2")
        //{
        //    PlayerPrefs.SetInt("clear_stage", 2);
        //    SceneManager.LoadScene("tutorial");

        //}
        //else if (collision.gameObject.name == "paper3")
        //{
        //    PlayerPrefs.SetInt("clear_stage", 3);
        //    SceneManager.LoadScene("tutorial");

        //}
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "top1")
        {
            Debug.Log("ž���� ������ ><");
            PlayerManager.Instance.check_collide_top();
        }
    }

    void stop_walking()
    {
        animator.SetBool("walk", false); // �ִϸ������� walk ������ ������ �ٲ��ֱ�
    }

    void find()
    {
        targetPos_rot = new Vector3(destination.x, destination.y, 0); // ���콺 x,y ��ǥ ���� Ÿ�� ���� ������ �־��ֱ�, z���� 2d �ϱ� 0!
        Vector3 dir_rot = targetPos_rot - transform.position; // ���콺���� ���� ������ ���� ���� ��ġ �� ���ϱ�, �����ǿ� ��ġ, ���� �� �پ��� ���� ��� �־�
        dir_rot.y = 0;  // �̰� ���ߴ��� x ���� �ʿ��߳�����~~^^
        Vector3 player_pos = new Vector3(transform.position.x, transform.position.y, 0); // ���� �������� ���� �־��ֱ�

        if (targetPos_rot.y > player_pos.y) // ���࿡ Ÿ���� y ���� �÷��̾��� y ������ ũ�ٸ�? = ���콺 ��ġ�� �����̶��?
        {
            if (targetPos_rot.x > player_pos.x) // ���� ���콺 ��ġ�� �������̶��?
            {
                rend.flipX = false; // �̹� ������ �ִϸ����͸� �־�ּ� ������ �ʿ䰡 ���� ������ ����

                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                is_right = true;
                flip_check = false;
            }
            else if (targetPos_rot.x < player_pos.x) // ���� �����̰� �����뿡 ���콺 Ŭ���� �־������?
            {
                rend.flipX = true; // �¿���� �ϱ�, �ִϸ��̼��� ������ ���⸸ �־���� ������ ���� ������ ������ �¿���� true �ؾ���
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                is_right = false;
                flip_check = true;
            }
        }
        else if (targetPos_rot.y < player_pos.y) // y���� �Ʒ��� �ִٸ�, ���콺�� �Ʒ��ʿ� Ŭ�� �ƴٸ�?
        {
            if (targetPos_rot.x > player_pos.x) // ������ ������ Ŭ�����ִٸ�?
            {

                rend.flipX = true; // ���� �Ʒ��� ����� ���� �������� ���°Ű� �⺻���� �Ǿ��־ ������ ���� ������ ������ true �ؾ���
                animator.SetBool("walk", true);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                is_right = false;
                flip_check = true;
            }
            else if (targetPos_rot.x < player_pos.x) // ���� ���� Ŭ�� �Ǿ��ٸ�?
            {

                rend.flipX = false;
                animator.SetBool("walk", true);
                animator.SetBool("right", false);
                animator.SetBool("up", false);
                is_right = true;
                flip_check = false;
            }
        }
    }

    void spell()
    {
        targetPos_rot = new Vector3(destination.x, destination.y, 0); // ���콺 x,y ��ǥ ���� Ÿ�� ���� ������ �־��ֱ�, z���� 2d �ϱ� 0!
        Vector3 dir_rot = targetPos_rot - transform.position; // ���콺���� ���� ������ ���� ���� ��ġ �� ���ϱ�, �����ǿ� ��ġ, ���� �� �پ��� ���� ��� �־�
        dir_rot.y = 0;  // �̰� ���ߴ��� x ���� �ʿ��߳�����~~^^
        Vector3 player_pos = new Vector3(transform.position.x, transform.position.y, 0); // ���� �������� ���� �־��ֱ�

        if (animator.GetBool("up") == true) // ���࿡ Ÿ���� y ���� �÷��̾��� y ������ ũ�ٸ�? = ���콺 ��ġ�� �����̶��?
        {
            if (animator.GetBool("right") == true) // ���� ���콺 ��ġ�� �������̶��?
            {
                rend.flipX = false; // �̹� ������ �ִϸ����͸� �־�ּ� ������ �ʿ䰡 ���� ������ ����

                animator.SetBool("walk", false);
                animator.SetBool("right", true);
                animator.SetBool("up", true);
                animator.SetTrigger("spell_t");
                //animator.SetBool("spell", true);
                is_right = true;
                flip_check = false;
                StartCoroutine("Particle");
            }
            else if (animator.GetBool("right") == false) // ���� �����̰� �����뿡 ���콺 Ŭ���� �־������?
            {
                rend.flipX = true; // �¿���� �ϱ�, �ִϸ��̼��� ������ ���⸸ �־���� ������ ���� ������ ������ �¿���� true �ؾ���
                animator.SetBool("walk", false);
                animator.SetBool("right", false);
                animator.SetBool("up", true);
                animator.SetTrigger("spell_t");
                //animator.SetBool("spell", true);
                is_right = false;
                flip_check = true;
                StartCoroutine("Particle");
            }
        }
        else if (animator.GetBool("up") == false) // y���� �Ʒ��� �ִٸ�, ���콺�� �Ʒ��ʿ� Ŭ�� �ƴٸ�?
        {
            if (animator.GetBool("right") == true) // ������ ������ Ŭ�����ִٸ�?
            {

                rend.flipX = true; // ���� �Ʒ��� ����� ���� �������� ���°Ű� �⺻���� �Ǿ��־ ������ ���� ������ ������ true �ؾ���
                animator.SetBool("walk", false);
                animator.SetBool("right", true);
                animator.SetBool("up", false);
                animator.SetTrigger("spell_t");
                //animator.SetBool("spell", true);
                is_right = false;
                flip_check = true;
                StartCoroutine("Particle");
            }
            else if (animator.GetBool("right") == false) // ���� ���� Ŭ�� �Ǿ��ٸ�?
            {

                rend.flipX = false;
                animator.SetBool("walk", false);
                animator.SetBool("right", false);
                animator.SetBool("up", false);
                animator.SetTrigger("spell_t");
                //animator.SetBool("spell", true);
                is_right = true;
                flip_check = false;
                StartCoroutine("Particle");
            }
        }
    }

    public IEnumerator Particle()
    {
        particle.Play();
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
    }
}