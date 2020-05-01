//眼球動きのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using System;

namespace TobiiEyeTracking
{

    public class RightEyeballController : MonoBehaviour
    {
        public GameObject LookTarget;
        private Vector3 Campos;
        private Camera cam;

        void Start()
        {
            Campos = GameObject.Find("Main Camera").transform.position;
            cam = Camera.main;
        }
        void Update()
        {
            // 出力: transform.localRotation

            // 入力1: transform.position;
            Vector3 EyePos = LookTarget.transform.position;
            // 入力2: TobiiAPI.GetGazePoint
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            Vector3 gazePointInWorld = new Vector3(gazePoint.Screen.x, gazePoint.Screen.y, cam.nearClipPlane);

            //EyeballCenterからCameraに向かうdirectional vector
            Vector3 EyeCamPos = Vector3.Normalize(Campos - EyePos);
            //EyeballCenterからGazePointに向かうdirectional vector
            Vector3 EyeGazePos = Vector3.Normalize(gazePointInWorld - EyePos);

            //cross productの計算
            //Vector3 axis = Vector3.Cross(EyeCamPos, EyeGazePos); // 回転軸 どちらかだけ使う
            Vector3 axis = Vector3.Cross(EyeGazePos, EyeCamPos); // 回転軸 どちらかだけ使う
            axis = Vector3.Normalize(axis);
            // Vector3 Normal = Vector3.Cross(EyeGazePos, EyeCamPos);
            //float angle = Mathf.Asin(Vector3.Distance(Vector3.zero, Vector3.Cross(EyeCamPos.normalized, EyeGazePos.normalized))) * Mathf.Rad2Deg;
            //print("EyeCamPos x EyeGazePosのcross product：" + normal);
            // print("EyeGazePos x EyeCamPosのcross product：" + Normal);
            //print("a，bの角度：" + angle);

            //inner productの計算
            float DotProduct = Vector3.Dot(EyeCamPos, EyeGazePos);
            float Angle = Mathf.Acos(Vector3.Dot(EyeCamPos.normalized, EyeGazePos.normalized));
            //print("EyeCamPos x EyeGazePosのinner product：" + DotProduct);
            print("a，bの角度：" + Angle * Mathf.Rad2Deg);

            transform.rotation = Quaternion.AngleAxis(Angle, axis);
        }
    }
}