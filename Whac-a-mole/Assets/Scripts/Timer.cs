using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public Text timeText;
    [SerializeField] public Score score;
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
        }

        //When the timer has run out, end the game
        else
        {
            timeRemaining = 0;
            score.Highscore();
            //Game end
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
}
