using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject BackgroundMusic;
    AudioSource backmusic;
    void Awake()
    {
        BackgroundMusic = GameObject.Find("BgmPlayer");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); //������� �����ص�
        if (backmusic.isPlaying) return; //��������� ����ǰ� �ִٸ� �н�
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic); //������� ��� ����ϰ�(���� ��ư�Ŵ������� ����)
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
