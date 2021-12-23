using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class AState : StateObject
{
    
    public AState()
    {
        a = 357;
        b = 68;
    }
    public static bool Probability(double fPercent)
    {
        double fProbabilityRate = UnityEngine.Random.value * 100.0f;

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
        if (Probability(0.1397))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(99.8209))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.0394))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        // else if(Probability(0.1065))
        // {
        //     StateManger.GetInstance().ChangeState("E");
        // }
    }
}
}