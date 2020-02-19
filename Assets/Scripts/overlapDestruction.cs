using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overlapDestruction : MonoBehaviour
{

    //RaycastHit2D up;
    //RaycastHit2D down;
    //RaycastHit2D right;
    //RaycastHit2D left;

    [SerializeField] float rayLength;
    // Start is called before the first frame update
    void Start()
    {
        //up = Physics2D.Raycast(transform.position, Vector2.up, rayLength,LayerMask.GetMask("downWall"));
        //down = Physics2D.Raycast(transform.position, Vector2.down, rayLength, 1<<LayerMask.NameToLayer("Water"));
        //right = Physics2D.Raycast(transform.position, Vector2.right, rayLength, LayerMask.GetMask("downWall"));
        //left = Physics2D.Raycast(transform.position, Vector2.left, rayLength, LayerMask.GetMask("downWall"));
    }

    // Update is called once per frame
    void Update()
    {
        raycast();
        //if (down.rigidbody != null) 
        //{
        //    Debug.Log("okay");
        //}
    }
    void raycast()
    {
        RaycastHit2D up;
        RaycastHit2D down;
        RaycastHit2D right;
        RaycastHit2D left;

        up = Physics2D.Raycast(transform.position, Vector2.up, rayLength, LayerMask.GetMask("downWall"));
        down = Physics2D.Raycast(transform.position, Vector2.down, rayLength, 1 << LayerMask.NameToLayer("Water"));
        right = Physics2D.Raycast(transform.position, Vector2.right, rayLength, LayerMask.GetMask("downWall"));
        left = Physics2D.Raycast(transform.position, Vector2.left, rayLength, LayerMask.GetMask("downWall"));

        if (down.rigidbody != null)
        {
            Debug.Log("okay");
        }
    }
}
