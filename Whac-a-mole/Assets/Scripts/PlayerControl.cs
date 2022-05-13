using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]public Score score;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem hitParticlesGold;

    void Update()
    {
        ProcessInput();
    }

    //Check if the player has hit a mole
    void ProcessInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.name == "Mole")
                {
                    HitMole(hit.transform.gameObject);
                }

                else if (hit.transform.name == "GoldenMole")
                {
                    HitGoldenMole(hit.transform.gameObject);
                }
            }
        }
    }

    //The player has hit a mole
    void HitMole(GameObject mole)
    {
        mole.SetActive(false);
        Instantiate(hitParticles, mole.gameObject.transform.position, Quaternion.identity);
        score.ScoreCount();
        score.ScoreUI();
    }

    //The player has hit a golden mole
    void HitGoldenMole(GameObject GoldenMole)
    {
        GoldenMole.SetActive(false);
        Instantiate(hitParticlesGold, GoldenMole.gameObject.transform.position, Quaternion.identity);
        score.playerScore = score.playerScore + 5;
        score.ScoreUI();
    }
}
