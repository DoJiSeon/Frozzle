using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool isPaused = false;
    public AudioSource audioSource;

    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            TogglePause();
            StopMusic();
        }
    }
    void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
    }

    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    void StopMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else {
            audioSource.Play();
        }
    }
}