using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class FsmAnswer : MonoBehaviour {

//添加一个状态机
    StateManger stm = new StateManger();
    void Start()
    {//注册状态
        stm.Region("A", new AState(stm));
        stm.Region("B", new BState(stm));
        stm.Region("C", new CState(stm));
        stm.Region("D", new DState(stm));
        stm.Region("E", new EState(stm));
//设置默认状态
        stm.SetDefat("C");
    }
    // Update is called once per frame
    void Update()
    {
//更新状态的方法
        stm.UpdateState();
    }
}
}