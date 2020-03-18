using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;
using System.IO;

namespace TobiiEyeTracking
{

    public class EyeMove : MonoBehaviour
    {
        void Update()
        {
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            print(gazePoint);
        }
    }
}
