using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public abstract class StateObject
{
    //状态控制机
    protected StateManger sm;
    public float a;
    public float b;
    //构造函数
    public StateObject(StateManger _sm)
    {
        sm = _sm;
    }
    //进入状态方法
    public abstract void EnterState();
    //离开状态方法
    public abstract void ExitState();
    //更新状态方法
    public abstract void UpdateState();


}
}