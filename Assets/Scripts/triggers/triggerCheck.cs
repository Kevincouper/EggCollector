using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerCheck : MonoBehaviour
{

    int sameTouched = 0;

    bool rightTouched = false;
    bool leftTouched = false;
    bool upTouched = false;
    bool downTouched = false;

    [SerializeField]rightTrigger rightTrigger;
    [SerializeField] leftTrigger leftTrigger;
    [SerializeField] upTrigger upTrigger;
    [SerializeField] downTrigger downTrigger;

    enum State
    {
        CHECK_TRIGGERS,
        CHECK_FOR_DESTRUCTION
    }

    State state = State.CHECK_TRIGGERS;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            
            case State.CHECK_TRIGGERS:
                rightTouched = rightTrigger.RightTouched();
                leftTouched = leftTrigger.LeftTouched();
                upTouched = upTrigger.UpTouched();
                downTouched = downTrigger.DownTouched();
                CheckMatch();
                break;
            case State.CHECK_FOR_DESTRUCTION:
                DestroySameColor();
                break;
        }

        //rightTouched = rightTrigger.RightTouched();
        //leftTouched = leftTrigger.LeftTouched();
        //upTouched = upTrigger.UpTouched();
        //downTouched = downTrigger.DownTouched();
        //CheckMatch();
        Debug.Log(downTouched);
        Debug.Log(upTouched);
    }
    //public void sameColorStay()
    //{
    //    sameTouched++;
    //}
    //public void sameColorExit()
    //{
    //    sameTouched--;
    //}
    void CheckMatch()
    {
        if(rightTouched&&leftTouched||upTouched&&downTouched||rightTouched&&upTouched||rightTouched&&downTouched||leftTouched&&upTouched||leftTouched&&downTouched)
        {
            Debug.Log("destroy");
            state = State.CHECK_FOR_DESTRUCTION;
        }
    }
     void DestroySameColor()
    {
        if(rightTouched)
        {
            rightTrigger.StartDestroy();
        }
        if(leftTouched)
        {
            leftTrigger.StartDestroy();
        }
        if(upTouched)
        {
            upTrigger.StartDestroy();
        }
        if(downTouched)
        {
            downTrigger.StartDestroy();
        }
        Destroy(gameObject, 1);
        state = State.CHECK_TRIGGERS;
    }
    public void changeState()
    {
        state = State.CHECK_FOR_DESTRUCTION;
    }
}
