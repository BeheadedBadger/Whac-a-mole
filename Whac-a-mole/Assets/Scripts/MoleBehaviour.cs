using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    [SerializeField] GameObject mole;

    float MinSpawnTime = 2;
    float MaxSpawnTime = 15;
    [SerializeField] Timer timer;
    float SpawnTime;

    void Start()
    {
        SetSpawnTimer();
    }


    void Update()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime <= 0)
        {
            ActivateMole();
        }
    }

    void SetSpawnTimer()
    {
        SpawnTime = Random.Range(MinSpawnTime, MaxSpawnTime);
    }

    void ActivateMole()
    {
        mole.SetActive(true);
        this.SetSpawnTimer();
        StartCoroutine(DeactivateMole(1.3f));
    }

    public IEnumerator DeactivateMole(float DeactivateMoleTime)
    {
        yield return new WaitForSeconds(DeactivateMoleTime);
        mole.SetActive(false);
    }
}
