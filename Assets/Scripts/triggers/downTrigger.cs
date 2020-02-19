using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class downTrigger : MonoBehaviour
{
    triggerCheck TriggerCheck;
    bool isSame = false;
    string tag;
    // Start is called before the first frame update
    void Start()
    {
        tag = gameObject.tag;
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
    //private void OnCollisionStay2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == gameObject.tag)
    //    {
    //        TriggerCheck = collision.gameObject.GetComponent<triggerCheck>();
    //        isSame = true;
    //    }
    //}
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag)
        {
        Debug.Log("downTouched");
            TriggerCheck = collision.gameObject.GetComponent<triggerCheck>();
            isSame = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isSame = false;
    }
    public bool DownTouched()
    {
        return isSame;
    }
}
