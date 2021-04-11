using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class AState : StateObject
{
    
    public AState(StateManger _sm):base(_sm)
    {
        a = 347;
        b = 524;
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
        Debug.Log("A状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("A状態から出る");
    }
    public override void UpdateState()
    {
        Debug.Log("A状態更新");
        if (Probability(20))
        {
            sm.ChangeState("B");
        }
        else if(Probability(20))
        {
            sm.ChangeState("A");
        }
        else if(Probability(20))
        {
            sm.ChangeState("C");
        }
        else if(Probability(20))
        {
            sm.ChangeState("D");
        }
        else if(Probability(20))
        {
            sm.ChangeState("E");
        }
    }
}
}