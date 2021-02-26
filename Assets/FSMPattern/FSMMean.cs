using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pattern
{
public class FSMMean : MonoBehaviour {

//添加一个状态机
    StateManger stm = new StateManger();
    void Start()
    {//注册状态
        stm.Region("Init", new InitState(stm));
        stm.Region("Listen", new ListenState(stm));
        stm.Region("Think", new ThinkState(stm));
        stm.Region("Answer", new AnswerState(stm));
//设置默认状态
        stm.SetDefat("Init");
    }

    // Update is called once per frame
    void Update()
    {
//更新状态的方法
        stm.UpdateState();
    }
}
}