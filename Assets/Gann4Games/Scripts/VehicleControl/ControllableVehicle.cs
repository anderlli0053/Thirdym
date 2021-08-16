using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllableVehicle : MonoBehaviour {
    public Player_VehicleUse player;
    public RearWheelDrive Vehicle;
    public bool passenger;
    [HideInInspector]
    public bool isInside;

    BoxCollider collider;
    public Vector3 exitPoint()
    {
        return transform.position + transform.TransformDirection(collider.center);
    }
    private void Start()
    {
        collider = GetComponent<BoxCollider>();
    }
}
