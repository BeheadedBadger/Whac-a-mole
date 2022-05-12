using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]public Score score;

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
                if (hit.transform)
                {
                    HitMole(hit.transform.gameObject);
                }
            }
        }
    }

    //The player has hit a mole
    void HitMole(GameObject mole)
    {
        mole.SetActive(false);
        score.ScoreCount();
        score.ScoreUI();
    }
}
