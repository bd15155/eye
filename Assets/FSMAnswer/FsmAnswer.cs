using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Answer
{
public class FsmAnswer : MonoBehaviour
{
    public GameObject LookTarget;
    private Vector3 Campos;
    private Camera cam;
    public bool flag = false;
    void Awake()
    {
        Application.targetFrameRate = -1;
        Campos = GameObject.Find("Main Camera").transform.position;
        cam = Camera.main;
    }
    void Update()
    {
        if(flag)
        {
          Debug.Log("Answer");
        // 入力1: transform.position;
        Vector3 EyePos = LookTarget.transform.position;
          // 入力2: TobiiAPI.GetGazePoint
        Vector3 gazePointInWorld = cam.ScreenToWorldPoint(new Vector3(StateManger.GetInstance().FsmEye.x, StateManger.GetInstance().FsmEye.y, cam.nearClipPlane));
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
        transform.rotation = Quaternion.AngleAxis(angle*30, axis);
        }
    }
}
}