//右眼球動きのクラス
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

namespace TobiiEyeTracking
{

    public class eyeball2 : MonoBehaviour
    {
        public GameObject LookTarget;
        private Vector3 StartPos;
        public float Range_X;
        public float Range_Y;
        public bool Invert_X;
        public bool Invert_Y;


        void Start()
        {
            StartPos = LookTarget.transform.position;

        }

        void Update()
        {
            {
                GazePoint gazePoint = TobiiAPI.GetGazePoint();
                Range_X = Mathf.Abs(Range_X) * (Invert_X ? 1 : -1);
                Range_Y = Mathf.Abs(Range_Y) * (Invert_Y ? 1 : -1);
                Vector3 gazePointInWorld = new Vector3(StartPos.x + ((gazePoint.Viewport.x - 0.5f) * Range_X), StartPos.y + ((gazePoint.Viewport.y - 0.5f) * Range_Y), StartPos.z);
                LookTarget.transform.position = gazePointInWorld;
            }
        }
    }
}