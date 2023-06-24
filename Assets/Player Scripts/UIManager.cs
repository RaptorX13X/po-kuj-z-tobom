using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject howToPlay;

    private void Start()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToPlayEnter()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }
    
    public void HowToPlayExit()
    {
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
