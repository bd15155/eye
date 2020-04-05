using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightEyeballController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 出力: transform.localRotation
        // 入力1: transform.position;
        // 入力2: TobiiAPI.GetGazePoint
        // 方法: Camera.ScreenToWorldPoint
        //        ↑ おそらく
    }
}
