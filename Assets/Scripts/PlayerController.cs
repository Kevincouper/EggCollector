using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    float speedY = -2f;
    private float speedX = 0f;
    private float movementX = 0f;
    [SerializeField] GameObject egg;
    [SerializeField] private Vector3 startPosition;

    private bool isGround = false;

    private bool isControlling = true;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        Grounded();
        
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
    
    void LeftDirection()

    {
        body.position += new Vector2(-1f, 0);
    }

    void RightDirection()
    {
        body.position += new Vector2(1f, 0);
    }

    void Grounded()
    {
        if (isGround)
        {
            Debug.Log("Touch ground");
            isControlling = false;
            EggSpawning.isSpawning = true;
            isGround = false;
            Destroy(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "blackEgg" || collision.gameObject.tag == "whiteEgg" || collision.gameObject.tag == "purpleEgg" || collision.gameObject.tag == "yellowEgg" )
        {
            // body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
            isGround = true;
        }
    }

}
