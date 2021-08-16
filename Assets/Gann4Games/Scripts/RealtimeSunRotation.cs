using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealtimeSunRotation : MonoBehaviour {
    public AnimationCurve ambientIntensityOverTime;

    public float RotationOffsetX = -90, RotationOffsetY = 163.33f;

    int MaxHours = 24;
    float FloatCurrentHours;
    int CurrentHours;

    float Angle()
    {
        CurrentHours = System.DateTime.Now.Hour;
        float H = MaxHours;
        FloatCurrentHours = CurrentHours / (H);
        return FloatCurrentHours * 360;
    }
    private void Start()
    {
        transform.rotation = Quaternion.Euler(Angle() + RotationOffsetX, RotationOffsetY, 0);
        RenderSettings.ambientIntensity = ambientIntensityOverTime.Evaluate(System.DateTime.Now.Hour);
    }
    private void Update()
    {
        float lerpTime = 0.001f;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(Angle() + RotationOffsetX, RotationOffsetY, 0), lerpTime);
        RenderSettings.ambientIntensity = Mathf.Lerp(RenderSettings.ambientIntensity, ambientIntensityOverTime.Evaluate(System.DateTime.Now.Hour), lerpTime);
    }
}
