using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Think;
using Listen;
using Answer;


public class SceneUIManager: MonoBehaviour
{
    public GameObject ListenLeft;
    public GameObject ListenRight;


    public void OnClickListen()
    {
        ListenLeft.GetComponent<FsmListen>().flag = true;
        ListenRight.GetComponent<FsmListen>().flag = true;
        ListenLeft.GetComponent<FsmThink>().flag = false;
        ListenRight.GetComponent<FsmThink>().flag = false;
        ListenLeft.GetComponent<FsmAnswer>().flag = false;
        ListenRight.GetComponent<FsmAnswer>().flag = false;
    }
    public void OnClickthink()
    {        
        ListenLeft.GetComponent<FsmListen>().flag = false;
        ListenRight.GetComponent<FsmListen>().flag = false;
        ListenLeft.GetComponent<FsmThink>().flag = true;
        ListenRight.GetComponent<FsmThink>().flag = true;
        ListenLeft.GetComponent<FsmAnswer>().flag = false;
        ListenRight.GetComponent<FsmAnswer>().flag = false;
    }    
    public void OnClickanswer()
    {   
        ListenLeft.GetComponent<FsmListen>().flag = false;
        ListenRight.GetComponent<FsmListen>().flag = false;
        ListenLeft.GetComponent<FsmThink>().flag = false;
        ListenRight.GetComponent<FsmThink>().flag = false;
        ListenLeft.GetComponent<FsmAnswer>().flag = true;
        ListenRight.GetComponent<FsmAnswer>().flag = true;
    }
}