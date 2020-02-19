using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    [SerializeField] ParticleSystem deathBurst;
    [SerializeField] TextMeshProUGUI text;
    bool burst = false;

    ScoreBonus score;

    enum State
    {
        CHECK_TRIGGERS,
        CHECK_FOR_DESTRUCTION
    }

    State state = State.CHECK_TRIGGERS;
    // Start is called before the first frame update
    void Start()
    {
        score = gameObject.GetComponent<ScoreBonus>();
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
            burst = true;
            score.destructionScore();
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
        if (burst)
        {
            Burst();
            burst = false;
        }
            destroy();
        state = State.CHECK_TRIGGERS;
    }
    void Burst()
    {
        if (deathBurst != null)
        {
            Debug.Log("burst");
            deathBurst.Play();

        }
    }
    void destroy()
    {
        Destroy(gameObject, 1.2f);
    }
    public void changeState()
    {
        state = State.CHECK_FOR_DESTRUCTION;
    }
}
