using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public abstract class StateObject
{
    public float a;
    public float b;
    //进入状态方法
    public abstract void EnterState();
    //离开状态方法
    public abstract void ExitState();
    //更新状态方法
    public abstract void UpdateState();


}
}