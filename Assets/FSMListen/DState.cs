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
        a = 1671;
        b = 470;     
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
        Debug.Log("D状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("D状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("D状態更新");
        if (Probability(0.1273))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.1272))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(99.7455))
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