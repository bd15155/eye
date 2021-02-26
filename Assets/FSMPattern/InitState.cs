using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
public class InitState : StateObject
{
    public InitState(StateManger _sm):base(_sm)
    {       
    }
    public override void EnterState()
    {
        Debug.Log("初期化状態に入る");
    }

    public override void ExitState()
    {
        Debug.Log("初期化状態から出る");
    }

    public override void UpdateState()
    {
        Debug.Log("初期化状態更新");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            sm.ChangeState("Listen");
        }
    }
}
}