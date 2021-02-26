using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
public class ListenState : StateObject
{
    
    public ListenState(StateManger _sm):base(_sm)
    {       
    }
    public override void EnterState()
    {
        Debug.Log("聞く状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("聞く状態から出る");
    }
    public override void UpdateState()
    {
        Debug.Log("聞く状態更新");
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            sm.ChangeState("Think");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            sm.ChangeState("Answer");
        }
    }
}
}