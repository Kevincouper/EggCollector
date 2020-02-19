using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBonus : MonoBehaviour
{
    [SerializeField] private string eggName;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == eggName)
        {
            Score.score += 5;
        }
    }
    public void destructionScore()
    {
        Score.score += 100;
    }
}
