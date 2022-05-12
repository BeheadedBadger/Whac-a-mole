using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    [SerializeField] public Text highScoreText;
    private int playerScore;
    private int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        ScoreUI();
    }

    public void ScoreCount()
    {
        //Mole hit, add score
        playerScore++;
    }

    public void Highscore()
    { 
        //Check if the current score surpasses the high score
        if (playerScore > PlayerPrefs.GetInt("highScore"))
        {
            //NEW HIGH SCORE!! (Communicate to player)
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
            ScoreUI();
        }
    }

    //Display score in the UI
    public void ScoreUI()
    {
        scoreText.text = (playerScore.ToString());
        highScoreText.text = (PlayerPrefs.GetInt("highScore").ToString());
    }
}
