using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCounter : MonoBehaviour
{
    [SerializeField] private string eggName;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == eggName)
        {
            CheckWin.number += 1;
            Debug.Log(CheckWin.number);
        }
    }
}
