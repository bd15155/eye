//eye動きデータを取るクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using System.IO;
using System;

namespace TobiiEyeTracking
{
    
    public class EyeMove : MonoBehaviour
    {
        void Update()
        {
            Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;
            print(gazePoint);
        }
    }
}