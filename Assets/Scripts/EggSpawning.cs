using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawning : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject eggPrefab;

    private bool isSpawning = true;

    // Update is called once per frame
    void Update()
    {
        if (isSpawning)
        {
            EggSpawn();
            isSpawning = false;
        }

    }

    void EggSpawn()
    {
        GameObject egg = Instantiate(eggPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
