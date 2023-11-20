using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundcutScene2 : MonoBehaviour
{
    public AudioSource musicAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("PlayMusic", 46f);
    }

    void PlayMusic()
    {
        if (musicAudioSource != null && !musicAudioSource.isPlaying)
        {
            musicAudioSource.Play();
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
