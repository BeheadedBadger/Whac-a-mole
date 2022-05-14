using System.Collections;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]public Score score;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] ParticleSystem hitParticlesGold;
    [SerializeField] ParticleSystem explosionParticles;

    //Screenshake
    Vector3 originalCameraPos;
    float shakeAmount = 0.3f;
    bool screenShaker;

    void Start()
    {
        originalCameraPos = this.gameObject.transform.position;
    }

    void Update()
    {
        ProcessInput();
        if (screenShaker == true)
        {
            StartCoroutine(Screenshake(0.3f));
        }
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

                else if (hit.transform.name == "Bomb")
                { 
                    HitBomb(hit.transform.gameObject);
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

    //The player has hit a bomb
    void HitBomb(GameObject Bomb)
    {
        screenShaker = true;
        Bomb.SetActive(false);
        Instantiate(explosionParticles, Bomb.gameObject.transform.position, Quaternion.identity);
        score.playerScore = score.playerScore - 5;
        score.ScoreUI();
    }

    //Screenshake
    IEnumerator Screenshake(float DeactivateShakeTime)
    {
        this.gameObject.transform.position = originalCameraPos + Random.insideUnitSphere * shakeAmount;
        yield return new WaitForSeconds(DeactivateShakeTime);
        screenShaker = false;
        this.gameObject.transform.position = originalCameraPos;
    }
}
