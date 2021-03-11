using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class StateManger {

    //利用字典存储各种状态
    Dictionary<string, StateObject> Dic = new Dictionary<string, StateObject>();

    //当前状态
    StateObject currentstate;
    //注册状态
    public void Region(string statename,StateObject state)
    {
        if (!Dic.ContainsKey(statename))
        {
            Dic.Add(statename,state);
        }
    }

    //设置默认状态
    public void SetDefat(string statename)
    {
        if (Dic.ContainsKey(statename))
        {
            currentstate = Dic[statename];
            currentstate.EnterState();
        }
    }
    //改变状态
    public void ChangeState(string statename)
    {
        if (Dic.ContainsKey(statename))
        {
            if (currentstate!=null)
            {
                currentstate.ExitState();
                currentstate = Dic[statename];
                currentstate.EnterState();
            }
        }
    }

    //更新状态
    public void UpdateState()
    {
        if (currentstate!=null)
        {
            currentstate.UpdateState();
        }
    }
    public Vector2 FsmEye
    {
    get
    {  
    Vector2 point;
    point.x = currentstate.a;
    point.y = currentstate.b;  
    return point;    
    }
    }  
}
}