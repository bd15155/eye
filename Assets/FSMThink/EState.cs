using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class EState : StateObject
{
    public EState(StateManger _sm):base(_sm)
    {          
        x = 618;
        y = 112;     
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
        Debug.Log("E状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("E状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("E状態更新");
        if (Probability(50))
        {
            sm.ChangeState("A");
        }
        else if (Probability(50))
        {
            sm.ChangeState("C");
        }
        else if(Probability(0))
        {
            sm.ChangeState("B");
        }
        else if(Probability(0))
        {
            sm.ChangeState("D");
        }
        else if(Probability(0))
        {
            sm.ChangeState("E");
        }
    }
}
}