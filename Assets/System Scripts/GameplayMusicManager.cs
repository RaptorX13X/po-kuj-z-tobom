using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayMusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicIntro;
    [SerializeField] private AudioSource musicLoopA;
    [SerializeField] private AudioSource musicLoopB;
    [SerializeField] private float introDuration;
    [SerializeField] private float loopDuration;

    private bool introFinish;
    private bool playingA;
    private float timer = 0;
    private float timerToCheck;
    void Start()
    {
        musicIntro.Play();
        timerToCheck = introDuration;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timerToCheck)
        {
            timer = 0;

            if (!introFinish)
            {
                introFinish = true;
                playingA = true;
                musicLoopA.Play();
                timerToCheck = loopDuration;
                return;
            }

            if (playingA) musicLoopB.Play();
            else musicLoopA.Play();

            playingA = !playingA;
        }
    }
}
