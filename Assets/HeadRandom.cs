﻿//キャラクターをランダムに動かせるクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TobiiEyeTracking
{
    public class HeadRandom : MonoBehaviour
    {
        private float dir = 1.0f;
        private Vector3 axis;
        private float Angle;
      
        void Update()
        {
          
            if (axis.y > 0 && Angle >= 20)
            {
                dir = -1;
            }
            if (axis.y < 0 && Angle >= 20)
            {
                dir = 1;
            }
            transform.rotation *= Quaternion.Euler(20 * Time.deltaTime * 0, dir, 0);
            transform.rotation.ToAngleAxis(out Angle, out axis);
            //print("頭の回転角度" + Angle);
            //print("頭の回転傾向" + axis);
         
        }
    }
}
