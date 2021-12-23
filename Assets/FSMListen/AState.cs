using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class AState : StateObject
{
    
    //public AState(StateManger _sm):base(_sm)
    public AState()
    {      
        a = 249;
        b = 423;    
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
        if (Probability(0))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(90.459))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(4.541))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("D");
        }
    }
}
}