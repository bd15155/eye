using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class CState : StateObject
{
    public CState()
    {    
        a = 757;
        b = 747;      
    }
    public static bool Probability(float fPercent)
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
        if (Probability(25))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(25))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(25))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(25))
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