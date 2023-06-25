using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    private bool playing;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject deathScreen;

    private void Awake()
    {
        pauseScreen.SetActive(false);
        victoryScreen.SetActive(false);
        deathScreen.SetActive(false);
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

    public void DisplayLoseScreen()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        playing = false;
    }

    public void DisplayVictoryScreen()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
        playing = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
