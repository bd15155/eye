using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class StateManger: MonoBehaviour {
    private static StateManger instance;
    public static StateManger GetInstance()
    {
        return instance;
    }
    void Awake()
    {
        instance = this;
        // 状態登録
        Region("A", new AState());
        Region("B", new BState());
        Region("C", new CState());
        Region("D", new DState());
        Region("E", new EState());
　　　　 // デフォルト状態設定
        SetDefat("B");
    }
    void Update()
    {
        UpdateState();
    }
    public static void Clear()
    {
        instance = default(StateManger);
    }   
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