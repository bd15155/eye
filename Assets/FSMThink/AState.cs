using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class AState : StateObject
{
    
    public AState()
    {    
        a = 247;
        b = 412;   
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
        Debug.Log("A状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("A状態から出る");
    }
    public override void UpdateState()
    {
        Debug.Log("A状態更新");
        if (Probability(0.1313))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.0175))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(99.8512))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0))
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