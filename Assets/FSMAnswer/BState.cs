using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class BState : StateObject
{
    public BState(StateManger _sm):base(_sm)
    {       
    }
    public static bool Probability(float fPercent)
    {
        float fProbabilityRate = UnityEngine.Random.value * 100.0f;

        if(fPercent == 100.0f && fProbabilityRate == fPercent)
        {
            return true;
        }
        else if (fProbabilityRate < fPercent)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void EnterState()
    {
        Debug.Log("B状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("B状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("B状態更新");
        if (Probability(30))
        {
            sm.ChangeState("A");
        }
        else if (Probability(30))
        {
            sm.ChangeState("C");
        } 
        else if (Probability(40))
        {
            sm.ChangeState("B");
        }
        else if(Probability(0))
        {
            sm.ChangeState("D");
        }
        else if(Probability(0))
        {
            sm.ChangeState("E");
        }         
    }
}
}