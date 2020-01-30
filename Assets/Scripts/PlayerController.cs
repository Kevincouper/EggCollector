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
    
    private bool changeEgg = false;
    
    
    // Start is called before the first frame update
    void Start()
    {

        body = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
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
