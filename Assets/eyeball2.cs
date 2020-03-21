using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming;

namespace TobiiEyeTracking
{
    public enum UpdateType
{
    None,
    Update,
    LateUpdate,
}

public class eyeball2 : MonoBehaviour
{
    public UpdateType UpdateType = UpdateType.Update;
    public GameObject LookTarget;
    private Vector3 StartPos;
    public float Renge_X;
    public float Renge_Y;
    public bool Invert_X;
    public bool Invert_Y;
    public float FilterSmoothingFactor = 0.15f;
    private bool _hasHistoricPoint;
    private Vector3 _historicPoint;

    void Start()
    {
        StartPos = LookTarget.transform.position;
    }

    void Update()
    {
        if (UpdateType == UpdateType.Update)
        {
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            Renge_X = Mathf.Abs(Renge_X) * (Invert_X ? 1 : -1);
            Renge_Y = Mathf.Abs(Renge_Y) * (Invert_Y ? 1 : -1);

            Vector3 gazePointInWorld = new Vector3(StartPos.x + ((gazePoint.Viewport.x - 0.5f) * Renge_X), StartPos.y + ((gazePoint.Viewport.y - 0.5f) * Renge_Y), StartPos.z);
            LookTarget.transform.position = Smoothify(gazePointInWorld);
        }
    }

    void LateUpdate()
    {
        if (UpdateType == UpdateType.LateUpdate)
        {
            GazePoint gazePoint = TobiiAPI.GetGazePoint();
            Renge_X = Mathf.Abs(Renge_X) * (Invert_X ? 1 : -1);
            Renge_Y = Mathf.Abs(Renge_Y) * (Invert_Y ? 1 : -1);

            Vector3 gazePointInWorld = new Vector3(StartPos.x + ((gazePoint.Viewport.x - 0.5f) * Renge_X), StartPos.y + ((gazePoint.Viewport.y - 0.5f) * Renge_Y), StartPos.z);
            LookTarget.transform.position = Smoothify(gazePointInWorld);
        }
    }

    private Vector3 Smoothify(Vector3 point)
    {

        if (!_hasHistoricPoint)
        {
            _historicPoint = point;
            _hasHistoricPoint = true;
        }

        var smoothedPoint = new Vector3(
            point.x * (1.0f - FilterSmoothingFactor) + _historicPoint.x * FilterSmoothingFactor,
            point.y * (1.0f - FilterSmoothingFactor) + _historicPoint.y * FilterSmoothingFactor,
            point.z);

        _historicPoint = smoothedPoint;

        return smoothedPoint;
    }
}
}