using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoleBehaviour : MonoBehaviour
{
    //Object to spawn
    [SerializeField] GameObject mole;
    [SerializeField] GameObject goldenMole;

    //Minimum and maximum time to wait before spawning mole
    public float MinSpawnTime;
    public float MaxSpawnTime;
    float SpawnTime;
    int moleSelector;

    void Start()
    {
        SetSpawnTimer();
        MinSpawnTime = 2;
        MaxSpawnTime = 15;
    }

    void Update()
    {
        //Count down and spawn mole when spawn timer has run out
        SpawnTime -= Time.deltaTime;
        if (SpawnTime < 0)
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
        //Decide whether to spawn a golden mole or regular mole
        moleSelector = Random.Range(1, 20);
        if (moleSelector == 1)
        {
            goldenMole.SetActive(true);
        }

        else
        {
           mole.SetActive(true);
        }

        Debug.Log(moleSelector);
        
        //Reset the time and deactivate the mole
        this.SetSpawnTimer();
        StartCoroutine(DeactivateMole(1.3f));
    }

    //Deactivate the mole
    public IEnumerator DeactivateMole(float DeactivateMoleTime)
    {
        yield return new WaitForSeconds(DeactivateMoleTime);
        mole.SetActive(false);
        goldenMole.SetActive(false);
    }
}
