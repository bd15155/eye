using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class CState : StateObject
{
    public CState()
    {   
        a = 1301;
        b = 120;     
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
        if (Probability(0.245))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.394))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(98.675))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0.158))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0.528))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}