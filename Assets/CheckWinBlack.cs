﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinBlack : MonoBehaviour
{
    
   public static float number = 0;

   void Update()
    {
        if (number == 3)
        {
            Destroy(gameObject);
        }
    }
   
}
