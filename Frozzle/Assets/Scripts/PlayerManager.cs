using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    private static PlayerManager _instance;
    public static PlayerManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = FindObjectOfType(typeof(PlayerManager)) as PlayerManager;
                if (_instance == null)
                    Debug.Log("no singleton obj");
            }
            return _instance;
        }
    }
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }

        else if(_instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    GameObject player;
    public bool has_lens, coiide_top, down_t;
    private void Start()
    {
        
    }
    void OnEnable()
    {
        // 씬 매니저의 sceneLoaded에 체인을 건다.
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 체인을 걸어서 이 함수는 매 씬마다 호출된다.
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("OnSceneLoaded: " + scene.name);
        Debug.Log(mode);

        player = GameObject.Find("player");
        has_lens = false;
        coiide_top = false;
        down_t = false;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        
    }

    public void check_lens()
    {
        if (!has_lens)
        {
            has_lens = true;
        }
        else
        {
            has_lens = false;
        }
    }
    public void check_collide_top()
    {
        if (!coiide_top)
        {
            coiide_top = true;
        }
        else
        {
            coiide_top = false;
        }
    }
    public void check_down_t()
    {
        if (!down_t)
        {
            down_t = true;
        }
        else
        {
            down_t = false;
        }
    }
}
