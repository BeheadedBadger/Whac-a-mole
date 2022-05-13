using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject highScore;
    [SerializeField] Score score;
    [SerializeField] Text scoreText;

    //End the game
    public void End()
    {
        DeactivateMoles();
        DeactivateGameUI();
        EndUI();
    }

    //Turn off moles
    void DeactivateMoles()
    { 
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("Mole");   
        foreach (GameObject Mole in taggedObjects)
        {
            Destroy(Mole);
        }
    }

    //Turn off game UI
    void DeactivateGameUI()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("GameUI");
        foreach (GameObject GameUI in taggedObjects)
        {
            GameUI.SetActive(false);
        }
    }

    //Show end UI
    void EndUI()
    {
        endScreen.SetActive(true);
        scoreText.text = (score.playerScore.ToString());

        if (score.NewHighScore == true)
        {
            highScore.SetActive(true);
        }
    }
}
