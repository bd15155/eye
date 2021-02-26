using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
public class AnswerState : StateObject
{
    public AnswerState(StateManger _sm):base(_sm)
    {       
    }
    public override void EnterState()
    {
        Debug.Log("答え状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("答え状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("答え状態更新");
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            sm.ChangeState("Listen");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            sm.ChangeState("Init");

        }
    }
}
}