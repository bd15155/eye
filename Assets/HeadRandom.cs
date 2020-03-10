﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TobiiEyeTracking
{
    public class HeadRandom : MonoBehaviour
    {
        private float speed = 10f;
        private float dir =1.0f;
        private Vector3 axis;
        private float Angle;
      
        void Update()
        {
            //transform.Rotate(new Vector3(0.0f, -2.0f, 0.0f));
            //transform.Rotate(Vector3.up * Time.deltaTime * speed);
            if (axis.y > 0 && Angle >= 210)
            {
                print("true");
                dir = -1;
            }
            if (axis.y > 0 && Angle <= 120)
            {
                print("false");
                dir = 1;
            }
            transform.rotation *= Quaternion.Euler(20 * Time.deltaTime * 0, dir, 0);
            transform.rotation.ToAngleAxis(out Angle, out axis);
            print(Angle);
            print(axis);
         
        }
    }
}
