using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGrid 
{
    public static int row = 10;
    public static int column = 5;

    public static Transform[,] grid = new Transform[row, column];

    public static Vector2 RoundVector(Vector2 vect)
    {
        return new Vector2(Mathf.Round(vect.x), Mathf.Round(vect.y));
    }

    public static bool IsInsideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < row && (int)pos.y >= 0);
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.DrawCube(grid.transform.position.x, grid.transform.position.y);
    //}
}
