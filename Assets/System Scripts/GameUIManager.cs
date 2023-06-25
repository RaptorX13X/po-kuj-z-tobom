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
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private GameplayMusicManager gameplayMusicManager;

    public bool Playing => playing;
    [SerializeField] private AudioClip victory;
    [SerializeField] private AudioClip loss;
    
    
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
        AudioManager.instance.PlaySound(loss);
        Time.timeScale = 0f;
        playing = false;

        audioManager.gameObject.SetActive(false);
        gameplayMusicManager.gameObject.SetActive(false);
    }

    public void DisplayVictoryScreen()
    {
        victoryScreen.SetActive(true);
        AudioManager.instance.PlaySound(victory);
        Time.timeScale = 0f;
        playing = false;

        audioManager.gameObject.SetActive(false);
        gameplayMusicManager.gameObject.SetActive(false);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
