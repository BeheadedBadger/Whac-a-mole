using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    //Object to spawn
    [SerializeField] GameObject mole;

    //Minimum and maximum time to wait before spawning mole
    float MinSpawnTime = 2;
    float MaxSpawnTime = 15;
    float SpawnTime;

    void Start()
    {
        SetSpawnTimer();
    }

    void Update()
    {
        //Count down and spawn mole when spawn timer has run out
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            ActivateMole();
        }
    }

    //Determine the time until the next spawn
    void SetSpawnTimer()
    {
        SpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
    }

    //Activate the mole
    void ActivateMole()
    {
        mole.SetActive(true);
        this.SetSpawnTimer();
        StartCoroutine(DeactivateMole(1.3f));
    }

    //Deactivate the mole
    public IEnumerator DeactivateMole(float DeactivateMoleTime)
    {
        yield return new WaitForSeconds(DeactivateMoleTime);
        mole.SetActive(false);
    }
}
