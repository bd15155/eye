using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class DState : StateObject
{
    public DState()
    {           
        a = 1787;
        b = 96;     
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
        if (Probability(0.570))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.268))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.152))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(98.882))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0.128))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}