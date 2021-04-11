using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Think
{
public class FsmThink : MonoBehaviour
{
    public GameObject LookTarget;
    private Vector3 Campos;
    public bool flag = false;

    private Camera cam;
//添加一个状态机
    StateManger stm = new StateManger();
    void Start()
    {
        Campos = GameObject.Find("Main Camera").transform.position;
        cam = Camera.main;
        //注册状态
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
        if(flag)
        {
            Debug.Log("Think");

//更新状态的方法
        stm.UpdateState();
        // 入力1: transform.position;
        Vector3 EyePos = LookTarget.transform.position;
          // 入力2: TobiiAPI.GetGazePoint
        Vector3 gazePointInWorld = cam.ScreenToWorldPoint(new Vector3(stm.FsmEye.x, stm.FsmEye.y, cam.nearClipPlane));
        // EyeballCenterからCameraに向かうdirectional vector
        Vector3 EyeCamPos = Vector3.Normalize(Campos - EyePos);
        Vector3 EyeGazePos = Vector3.Normalize(gazePointInWorld - EyePos);
        // cross productの計算
        Vector3 axis = Vector3.Cross(EyeCamPos, EyeGazePos);
        axis = Vector3.Normalize(axis);
        //inner productの計算
        float Angle = Mathf.Acos(Vector3.Dot(EyeCamPos, EyeGazePos));
        float angle = Angle * Mathf.Rad2Deg;
        // 出力: transform.localRotation
        transform.rotation = Quaternion.AngleAxis(angle*40, axis);
        }
    }
    void Awake()
    {
		// FPS設定
		Application.targetFrameRate = 1;
	}
}
}