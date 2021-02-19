using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DState : StateObject
{
    public DState(StateManger _sm):base(_sm)
    {       
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
        Debug.Log("D状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("D状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("D状態更新");
        if (Probability(100))
        {
            sm.ChangeState("C");
        }
    }
}