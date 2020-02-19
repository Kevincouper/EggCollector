using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightTrigger : MonoBehaviour
{

    triggerCheck TriggerCheck;
    bool isSame = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartDestroy()
    {
        if (TriggerCheck != null)
        {
            TriggerCheck.changeState();
        }
    }
    //private void OnTriggerStay2D(Collision2D collision)
    //{
    //        Debug.Log("rightSame");
    //    if (collision.gameObject.tag == gameObject.tag)
    //    {
    //        TriggerCheck = collision.gameObject.GetComponent<triggerCheck>();
    //        isSame = true;
    //    }
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("rightTouched");
        if (collision.gameObject.tag == gameObject.tag)
        {
            TriggerCheck = collision.gameObject.GetComponent<triggerCheck>();
            isSame = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isSame = false;
    }
    public bool RightTouched()
    {
        return isSame;
    }
}
