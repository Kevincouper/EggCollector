using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawning : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;    
    [SerializeField] Transform NextEggPoint;
    [SerializeField] GameObject eggWhitePrefab;
    [SerializeField] GameObject eggBlackPrefab;
    [SerializeField] GameObject eggPurplePrefab;
    [SerializeField] GameObject eggYellowPrefab;
    
    [SerializeField] GameObject eggWhite;
    [SerializeField] GameObject eggBlack;
    [SerializeField] GameObject eggPurple;
    [SerializeField] GameObject eggYellow;
    
    

    public static bool isSpawning = true;

    //private int randomNumber;

    void Update()
    {
        if (isSpawning)
        {
            EggSpawn();
            isSpawning = false;
        }
        /*else
        {
            RandomMachineNumber();
        }*/
    }

//    void RandomMachineNumber()
//    {
//        randomNumber = Random.Range(1, 5);
//
//        if (randomNumber == 1)
//        {
//            eggWhite.SetActive(true);
//        }
//            
//        if (randomNumber == 2)
//        {
//            eggBlack.SetActive(true);
//        }
//            
//        if (randomNumber == 3)
//        {
//            eggPurple.SetActive(true);
//        }
//            
//        if (randomNumber == 4)
//        {
//            eggYellow.SetActive(true);
//        }
//    }
    void EggSpawn()
    {
        int randomNumber = Random.Range(1, 5);
        
        if (randomNumber == 1)
        {
            GameObject egg = Instantiate(eggWhitePrefab, spawnPoint.position, spawnPoint.rotation);
            /*eggWhite.SetActive(false);
            eggBlack.SetActive(false);
            eggPurple.SetActive(false);
            eggYellow.SetActive(false);*/
        }
        if (randomNumber == 2)
        {
            GameObject egg = Instantiate(eggBlackPrefab, spawnPoint.position, spawnPoint.rotation);
            /*eggWhite.SetActive(false);
              eggBlack.SetActive(false);
              eggPurple.SetActive(false);
              eggYellow.SetActive(false);*/
        }
        if (randomNumber == 3)
        {
            GameObject egg = Instantiate(eggPurplePrefab, spawnPoint.position, spawnPoint.rotation);
            /*eggWhite.SetActive(false);
            eggBlack.SetActive(false);
            eggPurple.SetActive(false);
            eggYellow.SetActive(false);*/
        }
        if (randomNumber == 4)
        {
            GameObject egg = Instantiate(eggYellowPrefab, spawnPoint.position, spawnPoint.rotation);
            /*eggWhite.SetActive(false);
                eggBlack.SetActive(false);
                eggPurple.SetActive(false);
                eggYellow.SetActive(false);*/
        }
    }
}
