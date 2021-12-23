using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class BState : StateObject
{
    //public BState(StateManger _sm):base(_sm)
    public BState()
    {    
        a = 395;
        b = 1022;      
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
            StateManger.GetInstance().ChangeState("A");
        }
        else if (Probability(4.592))
        {
            StateManger.GetInstance().ChangeState("C");
        } 
        else if (Probability(90.408))
        {
            StateManger.GetInstance().ChangeState("B");
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