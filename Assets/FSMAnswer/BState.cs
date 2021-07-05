using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class BState : StateObject
{
    public BState()
    {
        a = 1254;
        b = 606;      
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
        Debug.Log("B状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("B状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("B状態更新");
        if (Probability(0))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if (Probability(0.0583))
        {
            StateManger.GetInstance().ChangeState("C");
        } 
        else if (Probability(99.8746))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.0583))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0.0088))
        {
            StateManger.GetInstance().ChangeState("E");
        }         
    }
}
}