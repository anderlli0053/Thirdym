using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollowTarget : MonoBehaviour {
    public Transform Target;
    public Vector3 positionOffset;
    public Vector3 lookatOffset;

    Transform lookatPoint;

    public bool Unparent;
    [Range(0, 1)]
    public float PositionDamp, RotationDamp, lookatDamp;
    public bool localPosition = true;
    public bool Position, Rotation, LookAt;
    private void Start()
    {
        if (Unparent)
            transform.SetParent(null);
        if (LookAt)
            lookatPoint = new GameObject(transform.gameObject.name + " lookat point").transform;
    }
    private void FixedUpdate()
    {
        if(Position || Rotation || LookAt)
            Move(Position, Rotation, LookAt);
    }
    public void Move(bool position, bool rotation, bool lookat)
    {
        if (position)
        {
            transform.position = Vector3.Lerp(transform.position, Target.position + (localPosition == true ? Target.TransformVector(positionOffset) : positionOffset), PositionDamp);
            Debug.DrawLine(transform.position, Target.position + Target.TransformVector(positionOffset), Color.red);
        }
        if (rotation)
            transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, RotationDamp);
        if (lookat)
        {
            lookatPoint.position = Vector3.Lerp(lookatPoint.position, Target.position + (localPosition == true ? Target.TransformVector(lookatOffset) : lookatOffset), lookatDamp);
            transform.LookAt(lookatPoint);
            Debug.DrawLine(transform.position, lookatPoint.position, Color.blue);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawCube(Target.position + (localPosition == true ? Target.TransformVector(positionOffset) : positionOffset), Vector3.one * 0.1f);
    }
}
