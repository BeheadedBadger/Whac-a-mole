using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] public Text scoreText;
    [SerializeField] public Text highScoreText;
    public int playerScore;
    public int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        ScoreUI();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform)
                {
                    HitMole(hit.transform.gameObject);
                }
            }
        }
    }

    void HitMole(GameObject mole)
    {
        mole.SetActive(false);
        Score();
        ScoreUI();
    }

    void Score()
    {
        playerScore = (playerScore + 1);

        //High score
        if (playerScore > PlayerPrefs.GetInt("highScore"))
        {
            highScore = playerScore;
            PlayerPrefs.SetInt("highScore", playerScore);
        }
    }

    void ScoreUI()
    {
        if (playerScore > 0)
        {
            scoreText.text = (playerScore.ToString());
        }

        if (highScore > 0)
        {
            highScoreText.text = (PlayerPrefs.GetInt("highScore").ToString());
        }
    }
}
