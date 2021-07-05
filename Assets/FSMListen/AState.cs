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
        a = 247;
        b = 212;    
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
        Debug.Log("A状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("A状態から出る");
    }
    public override void UpdateState()
    {
        Debug.Log("A状態更新");
        if (Probability(0.6163))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(0.0143))
        {
            StateManger.GetInstance().ChangeState("E");
        }
        else if(Probability(99.3694))
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