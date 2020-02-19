using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upTrigger : MonoBehaviour
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
        if (collision.gameObject.tag == gameObject.tag)
        {
        Debug.Log("okk");
            TriggerCheck = collision.gameObject.GetComponent<triggerCheck>();
            Debug.Log("worked");
            isSame = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isSame = false;
    }
    public bool UpTouched()
    {
        return isSame;
    }
}
