using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    float speedY = -1f;
    private float speedX = 0f;
    private float movementX = 0f;
    [SerializeField] GameObject egg;
    [SerializeField]private Vector3 startPosition;
    
    private bool isControlling = true;
    
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        if (isControlling)
        {
            body.velocity = new Vector2(speedX, speedY);

            if (Input.GetMouseButtonDown(0))
            {
               LeftDirection();
            }

            if (Input.GetMouseButtonDown(1))
            {
                RightDirection();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
           // body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            isControlling = false;
            EggSpawning.isSpawning = true;
        }
    }

    void LeftDirection()
    {
        body.position += new Vector2(-1f, 0);
    }
    
    void RightDirection()
    {
        body.position += new Vector2(1f, 0);
    }
}
