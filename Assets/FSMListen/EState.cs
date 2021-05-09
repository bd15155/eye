using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Listen
{
public class EState : StateObject
{
    //public EState(StateManger _sm):base(_sm)
    public EState()
    {  
        a = 1210;
        b = 364;       
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
            StateManger.GetInstance().ChangeState("A");
        }
        else if (Probability(50))
        {
            StateManger.GetInstance().ChangeState("C");
        }
        else if(Probability(0))
        {
            StateManger.GetInstance().ChangeState("B");
        }            
        else if(Probability(0))
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