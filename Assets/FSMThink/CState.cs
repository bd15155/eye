using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class CState : StateObject
{
    public CState()
    {   
        a = 861;
        b = 364;     
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
        Debug.Log("C状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("C状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("C状態更新");
        if (Probability(0.0051))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.2235))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0.0305))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(99.7409))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("A");
        }
    }
}
}