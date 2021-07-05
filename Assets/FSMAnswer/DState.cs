using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class DState : StateObject
{
    public DState()
    {       
        a = 981;
        b = 319;
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
        if (Probability(0.1403))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0.1052))
        {
            StateManger.GetInstance().ChangeState("A");
        }
        else if(Probability(0.1578))
        {
            StateManger.GetInstance().ChangeState("B");
        }
        else if(Probability(99.4127))
        {
            StateManger.GetInstance().ChangeState("D");
        }
        else if(Probability(0.1840))
        {
            StateManger.GetInstance().ChangeState("E");
        }
    }
}
}