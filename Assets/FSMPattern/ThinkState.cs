using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
public class ThinkState : StateObject
{
    public ThinkState(StateManger _sm):base(_sm)
    {       
    }
    public override void EnterState()
    {
        Debug.Log("考え状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("考え状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("考え状態更新");
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            sm.ChangeState("LIsten");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            sm.ChangeState("Answer");
        }       
    }
}
}