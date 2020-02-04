using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] eggObjects;

    void Start()
    {
        SpawnRandom();
    }

    public void SpawnRandom()
    {
        int index = Random.Range(0, eggObjects.Length);
        Instantiate(eggObjects[index], transform.position, Quaternion.identity);
    }
}
