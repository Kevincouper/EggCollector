using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCounter : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "blackEgg")
        {
            CheckWinBlack.number += 1;
            Debug.Log(CheckWinBlack.number);
        }
    }
}
