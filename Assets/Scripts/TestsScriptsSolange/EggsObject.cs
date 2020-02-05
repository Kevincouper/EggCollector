using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggsObject : MonoBehaviour
{

    float lastFall = 0f;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (IsValidPosition())
            {
                transform.position += new Vector3(-1, 0, 0);
                UpdateMatrixGrid();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {

                if (IsValidPosition())
                {
                    transform.position += new Vector3(-1, 0, 0);
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.position += new Vector3(1, 0, 0);
                }
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {

                if (IsValidPosition())
                {
                    transform.Rotate(new Vector3(0, 0, -90));
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, 90));
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - lastFall >= 1)
            {

                if (IsValidPosition())
                {
                    transform.position += new Vector3(0, -1, 0);
                    UpdateMatrixGrid();
                }
                else
                {
                    transform.position += new Vector3(0, 1, 0);

                    //C'est ici que nous détruirons les 3 oeufs

                    FindObjectOfType<Spawner>().SpawnRandom();
                    enabled = false;
                }
                lastFall = Time.time;
            }
        }
    }
    bool IsValidPosition()
    {
        foreach (Transform child in transform)
        {
            Vector2 vect = MatrixGrid.RoundVector(child.position);
            if (!MatrixGrid.IsInsideBorder(vect))
                return false;

            if (MatrixGrid.grid[(int)vect.x, (int)vect.y] != null && MatrixGrid.grid[(int)vect.x, (int)vect.y].parent != transform)
                return false;
        }
        return true;
    }

    void UpdateMatrixGrid()
    {
        for (int y = 0; y < MatrixGrid.column; ++y)
        {
            for (int x = 0; x < MatrixGrid.row; ++x)
            {
                if (MatrixGrid.grid[x,y] != null)
                {
                    if (MatrixGrid.grid[x,y].parent == transform)
                    {
                        MatrixGrid.grid[x, y] = null;
                    }
                }
            }
        }
        foreach (Transform child in transform)
        {
            Vector2 vect = MatrixGrid.RoundVector(child.position);
            MatrixGrid.grid[(int)vect.x, (int)vect.y] = child;
        }
    }
}
