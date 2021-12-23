using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class BState : StateObject
{
    public BState()
    {    
        a = 578;
        b = 878;    
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
        if (Probability(0.070))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(99.578))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.352))
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