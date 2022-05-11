using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] public Text timeText;
    public float timeElapsed;
    float levelDuration = 90;
    float timeRemaining;
    
    private void Start()
    {
        timeRemaining = levelDuration;
    }
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeElapsed = Time.timeSinceLevelLoad;
            timeRemaining = (levelDuration - timeElapsed);
        }

        else
        {
            timeRemaining = 0;
            //Game end
        }

        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
