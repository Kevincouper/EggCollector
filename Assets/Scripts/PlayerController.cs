using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Vector2 direction;
    float speedY = -4f;
    private float speedX = 0f;
    private float movementX = 0f;
    //[SerializeField] GameObject egg;
    [SerializeField] private Vector3 startPosition;

    private bool isGround = false;

    private bool isControlling = true;

    private bool goLeft = true;
    private bool goRight = true;
    
    
    //[SerializeField] private GameObject panelEndGame;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
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
        
        if (isControlling)
        {
            body.velocity = new Vector2(speedX, speedY);

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Q) && goLeft)
            {
                LeftDirection();
            }

            if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.E) && goRight)
            {
                RightDirection();
            }
        }
    }
    
    public void LeftDirection()

    {
        body.position += new Vector2(-1f, 0);
    }

    public void RightDirection()
    {
        body.position += new Vector2(1f, 0);
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

}
