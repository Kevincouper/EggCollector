using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float speedY = -4f;
    private float speedX = 0f;

    private bool isGround = false;
    private bool isControlling = true;
    private bool goLeft = true;
    private bool goRight = true;

    private Vector3 targetPosition;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = new Vector2(speedX, speedY);
    }

    void Update()
    {            Debug.Log("Sort pas du board putain!!!");
        if ( transform.position.x <= 0.5)
        {
            goLeft = false;

        }
        else
        {
            goLeft = true;
        }
        
        if ( transform.position.x >= 6.4)
        {
            goRight = false;
        }
        else
        {
            goRight = true;
        }
        
        Grounded();

        if (Input.GetMouseButtonDown(0))
        {
            SetTargetPosition();
        
            if (isControlling)
            {
                body.velocity = new Vector2(speedX, speedY);

                if (targetPosition.x < 3.5f && goLeft)
                {
                    LeftDirection();
                }

                if (targetPosition.x > 3.5f && goRight)
                {
                    RightDirection();
                }
            }
        }
    }

    public void LeftDirection()
    {
       transform.position += new Vector3(-1f, 0, 0);
    }

    public void RightDirection()
    {
        transform.position += new Vector3(1f, 0, 0);
    }

    void Grounded()
    {
        if (isGround)
        {
            isControlling = false;
            EggSpawning.isSpawning = true;
            isGround = false;
            Score.score += 10;
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
    void SetTargetPosition()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = transform.position.z;
    }

}
