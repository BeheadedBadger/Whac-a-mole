using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public Text timeText;
    [SerializeField] public Score score;
    [SerializeField] EndGame endGame;
    [SerializeField] MoleBehaviour mole;
    public float timeElapsed;
    float levelDuration = 90;
    float timeRemaining;
    
    private void Start()
    {
        timeRemaining = levelDuration;
    }

    void Update()
    {
        //When there is still time left on the timer, continue to count down
        if (timeRemaining > 0)
        {
            timeElapsed = Time.timeSinceLevelLoad;
            timeRemaining = (levelDuration - timeElapsed);

            //Increase number of spawns as game progresses
            if (timeRemaining < 60)
            {
                Debug.Log("Start phase 2");
                PhaseTwo();
            }

            if (timeRemaining < 30)
            {
                Debug.Log("Start phase 3");
                PhaseThree();
            }
        }

        //When the timer has run out, end the game
        else
        {
            timeRemaining = 0;
            score.Highscore();
            endGame.End();
        }



        DisplayTime(timeRemaining);
    }

    //Display the remaining time
    void DisplayTime(float timeToDisplay)
    {
        //Set the display to zero if the remaining time goes below zero
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        //Display the remaining time in minutes and seconds
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //Decrease time between spawns
    private void PhaseTwo()
    {
        mole.MinSpawnTime = 2;
        mole.MaxSpawnTime = 10;
    }

    //Decrease time between spawns even more
    private void PhaseThree()
    {
        mole.MinSpawnTime = 0;
        mole.MaxSpawnTime = 1.5f;
    }
}
