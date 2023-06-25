using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool playing;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        playing = true;
    }

    private void Pause()
    {
        if (playing)
        {
            pauseScreen.SetActive(true);
            Time.timeScale = 0f;
            playing = false;
        }
        else
        {
            pauseScreen.SetActive(false);
            Time.timeScale = 1f;
            playing = true;
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            Pause();
    }
}
