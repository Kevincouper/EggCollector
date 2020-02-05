using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCounter : MonoBehaviour
{
    [SerializeField] private string eggName;
    private int _number = 0;
    
    void Update()
    {
        if (_number >= 3)
        {
            Destroy(gameObject);
            _number = 0;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == eggName)
        {
            _number += 1;
            Debug.Log(_number);
            //CheckWinBlack.number += 1;
            //Debug.Log(CheckWinBlack.number);
        }
    }
}
