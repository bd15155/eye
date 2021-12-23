using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class CState : StateObject
{
    public CState()
    {    
        a = 1220;
        b = 376;      
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
        if (Probability(0.144))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.575))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(98.858))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0.323))
        {
            StateManger.GetInstance().ChangeState("A");
        }
    }
}
}