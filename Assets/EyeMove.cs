//eyeの動きlogを残すクラス
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
            //Gaze point in screen space (where (0,0) is lower left corner)
            Vector2 gazePoint = TobiiAPI.GetGazePoint().Screen;
            print(gazePoint);
            //Gaze point in viewport space
            Vector2 gazepoint = TobiiAPI.GetGazePoint().Viewport;
            //print(gazepoint);
            //Gaze point in GUI space (where (0,0) is upper left corner).
            Vector2 gazepointGUI = TobiiAPI.GetGazePoint().GUI;
            //print(gazepointGUI);
            //print(Time.deltaTime);
        }
    }
}