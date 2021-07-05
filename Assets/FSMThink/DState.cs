using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class DState : StateObject
{
    public DState()
    {           
        a = 1210;
        b = 481;     
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
        Debug.Log("D状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("D状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("D状態更新");
        if (Probability(0.0778))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.0018))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(99.9204))
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