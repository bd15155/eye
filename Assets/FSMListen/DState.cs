using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class DState : StateObject
{
    //public DState(StateManger _sm):base(_sm)
    public DState()
    {     
        a = 1750;
        b = 144;     
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
        if (Probability(7.152))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(88.377))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(4.471))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}