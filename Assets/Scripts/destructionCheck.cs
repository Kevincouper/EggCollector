using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destructionCheck : MonoBehaviour
{
    [SerializeField] float raycastLength = 0.6f;
    // Start is called before the first frame update
   

    string eggTag;

    Collider2D eggCollider;

    bool sameColorRight = false;
    bool sameColorLeft = false;
    bool sameColorUp = false;
    bool sameColorDown = false;

    int sameEggTouched;
    void Start()
    {
    eggCollider = gameObject.GetComponent<Collider2D>();
   
        eggTag = gameObject.tag;
    }

    // Update is called once per frame
    void Update()
    {
        checkRaycast();

        sameColorsCheck();
    }
     void checkRaycast()
    {
        RaycastHit2D hitUp;
        RaycastHit2D hitRight;
        RaycastHit2D hitLeft;
        RaycastHit2D hitDown;

        hitUp = Physics2D.Raycast(transform.position, Vector2.up, raycastLength, 1 << LayerMask.NameToLayer("egg"));
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastLength, 1 << LayerMask.NameToLayer("egg"));
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastLength, 1 << LayerMask.NameToLayer("egg"));
        hitDown = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, 1 << LayerMask.NameToLayer("egg"));



        //if(hitDown.collider!=null)
        //{
        //    Debug.Log("hey");
        //    Debug.Log(hitDown.collider.gameObject);
        //}
        //if(hitDown.collider != null)
        //{
        //    Debug.Log(hitDown.collider.gameObject.name);
        //}

        if ( hitDown.collider != null)
        {
            
            if (hitDown.collider.gameObject.tag == gameObject.tag)
            {
                
                sameColorDown = true;
                Debug.Log("down");
                
            }
            
        }
        if (hitUp.collider != null)
        {
            
            if (hitUp.collider.gameObject.tag == gameObject.tag)
            {
                
                sameColorUp = true;
                Debug.Log("up");

            }

        }
        if (hitRight.collider != null)
        {
            
            if (hitRight.collider.gameObject.tag == gameObject.tag)
            {
               
                sameColorRight = true;

            }

        }
        if (hitLeft.collider != null)
        {
            
            if (hitLeft.collider.gameObject.tag == gameObject.tag)
            {
                Debug.Log(hitLeft.collider.gameObject.name);
                sameColorLeft = true;

            }

        }

        //if (hitUp.collider != null&&hitUp.collider.tag == eggTag)
        //{
        //    Debug.Log("touched");
        //    sameEggTouched++;
        //}
        //if (hitLeft.collider != null && hitLeft.collider.tag == eggTag)
        //{
        //    Debug.Log("touched");
        //    sameEggTouched++;
        //}
        //if (hitDown.collider != null && hitDown.collider.tag == eggTag)
        //{
        //    Debug.Log("touched");
        //    sameEggTouched++;
        //}
        //if (hitRight.collider != null && hitRight.collider.tag == eggTag)
        //{
        //    Debug.Log("touched");
        //    sameEggTouched++;
        //}
    }

    void sameColorsCheck()
    {
        if(sameColorDown&&sameColorUp)
        {
            Debug.Log("sameC");
        }
        if(sameColorUp&&sameColorRight)
        {
            Debug.Log("same3");
        }
        if(sameColorRight&&sameColorLeft)
        {
            Debug.Log("same3");
        }
        if(sameColorDown&&sameColorRight)
        {
            Debug.Log("same4");
        }
        if(sameColorDown&&sameColorLeft)
        {
            Debug.Log("same5");
            Debug.Log(gameObject.name);
        }
       if(sameColorUp&&sameColorLeft)
        {
            Debug.Log("same6");
        }
        if (sameColorDown && sameColorLeft || sameColorDown && sameColorRight || sameColorUp && sameColorRight || sameColorUp && sameColorLeft || sameColorLeft && sameColorRight || sameColorUp && sameColorDown)
        {
           // Debug.Log("same");
            checkAndDestroy();
        }
    }
    public void checkAndDestroy()
    {

        RaycastHit2D hitUp;
        RaycastHit2D hitRight;
        RaycastHit2D hitLeft;
        RaycastHit2D hitDown;

        hitUp = Physics2D.Raycast(transform.position, Vector2.up, raycastLength, 1 << LayerMask.NameToLayer("downWall"));
        hitRight = Physics2D.Raycast(transform.position, Vector2.right, raycastLength, 1 << LayerMask.NameToLayer("downWall"));
        hitLeft = Physics2D.Raycast(transform.position, Vector2.left, raycastLength, 1 << LayerMask.NameToLayer("downWall"));
        hitDown = Physics2D.Raycast(transform.position, Vector2.down, raycastLength, 1 << LayerMask.NameToLayer("downWall"));


        if (hitUp.collider != null && hitUp.collider.tag == gameObject.tag)
        {
            destructionCheck destructionCheck;
            destructionCheck = hitUp.collider.gameObject.GetComponent<destructionCheck>();
            destructionCheck.checkAndDestroy();
            sameColorUp = false;
        }
        if (hitRight.collider != null && hitRight.collider.tag == gameObject.tag)
        {
            Debug.Log("hit");
            Debug.Log(hitRight.collider.gameObject);
            destructionCheck destructionCheck;
            destructionCheck = hitRight.collider.GetComponent<destructionCheck>();
            destructionCheck.checkAndDestroy();
            sameColorRight = false;
        }
        if (hitLeft.collider != null && hitLeft.collider.tag == gameObject.tag)
        {
            destructionCheck destructionCheck;
            destructionCheck= hitLeft.collider.GetComponent<destructionCheck>();
            destructionCheck.checkAndDestroy();
            sameColorLeft = false;
        }
        if (hitDown.collider != null && hitDown.collider.tag == gameObject.tag)
        {
            destructionCheck destructionCheck;
            destructionCheck= hitDown.collider.GetComponent<destructionCheck>();
            destructionCheck.checkAndDestroy();
            sameColorDown = false;
        }
        destroy();
    }
    public void destroy()
    {
        Debug.Log("destroy");
        Destroy(gameObject);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.down * raycastLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.right * raycastLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.left * raycastLength);
        Gizmos.DrawLine((Vector2)transform.position, (Vector2)transform.position + Vector2.up * raycastLength);

    }
}
