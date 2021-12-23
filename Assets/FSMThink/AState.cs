using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class AState : StateObject
{
    
    public AState()
    {    
        a = 477;
        b = 186;   
    }
    public static bool Probability(double fPercent)
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
    }

    public override void ExitState()
    {
    }
    public override void UpdateState()
    {
        if (Probability(99.789))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.015))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.196))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}