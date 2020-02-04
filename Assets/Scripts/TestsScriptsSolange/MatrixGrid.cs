using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid 
{
    [SerializeField] private static int row = 10;
    [SerializeField] private static int column = 20;

    public Transform[,] grid = new Transform[row, column];

    public static Vector2 RoundVector(Vector2 vect)
    {
        return new Vector2(Mathf.Round(vect.x), Mathf.Round(vect.y));
    }
}
