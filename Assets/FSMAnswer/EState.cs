using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class EState : StateObject
{
    public EState()
    {   
        a = 251;
        b = 354;
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
        Debug.Log("E状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("E状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("E状態更新");
        if (Probability(0.1704))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if (Probability(0.0077))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0.0000))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.0232))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(99.7987))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}