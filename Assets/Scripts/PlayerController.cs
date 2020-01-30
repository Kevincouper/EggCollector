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
    
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isControlling)
        {
            body.velocity = new Vector2(speedX, speedY);

            if (Input.GetKeyDown(KeyCode.Q))
            {
                body.position += new Vector2(-1f, 0);

            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                body.position += new Vector2(1f, 0);

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
}
