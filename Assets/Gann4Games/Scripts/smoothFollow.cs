using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Axis
{
    public bool X = true;
    public bool Y = true;
    public bool Z = true;
}
public class smoothFollow : MonoBehaviour {
    public bool commonUpdate = true;
    public bool useRotation = true;
    //public Axis axis;
    public bool usePosition = true;
    public Vector3 positionOffset;
    public Transform target;
    public float smoothPosition = 0.5F;
    public float smoothRotation = 0.1f;
    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (!commonUpdate)
            Translate();
    }
    void Update()
    {
        if (commonUpdate)
            Translate();
    }
    public void Translate()
    {
        if (!IngameMenuHandler.instance.paused)
        {
            if (usePosition)
            {
                Vector3 targetPosition = target.TransformPoint(positionOffset);
                transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothPosition);
            }
            if (useRotation)
                transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, smoothRotation);
        }
    }
}
