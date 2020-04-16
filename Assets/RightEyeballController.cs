//右眼球動きのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

namespace TobiiEyeTracking { 

public class RightEyeballController : MonoBehaviour
{
    public GameObject LookTarget;
        void Start()
    {
        
    }
    void Update()
    {
            // 出力: transform.localRotation
            // 入力1: transform.position;
            // 入力2: TobiiAPI.GetGazePoint
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            // 方法: Camera.ScreenToWorldPoint
            //        ↑ おそらく

            transform.localRotation = Quaternion.Euler(0, Time.time * 100, 0);
    }
}
                             } 