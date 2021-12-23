using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class CState : StateObject
{
    public CState()
    {
        a = 1275;
        b = 434;
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
        if (Probability(0.0475))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.0048))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        // else if(Probability(0.0045))
        // {
        //     StateManger.GetInstance().ChangeState("E");
        // }
        else if(Probability(99.9335))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0.0142))
        {
            StateManger.GetInstance().ChangeState("A");
        }
    }
}
}