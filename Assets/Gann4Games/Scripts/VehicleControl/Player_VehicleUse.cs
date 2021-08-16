using UnityEngine;
using Gann4Games.Thirdym.Enums;

public class Player_VehicleUse : MonoBehaviour {

    bool isInside;

    ControllableVehicle vehicle;
    PlayerCameraController camSys;

    Collider[] playerCollisionComponents;

    private void Start()
    {
        playerCollisionComponents = GetComponentsInChildren<Collider>();
        camSys = GetComponent<PlayerCameraController>();
    }
    private void Update()
    {
        if(InputHandler.instance.use && vehicle != null)
        {
            isInside = !isInside;
            if(isInside) EnterVehicle();
            else LeaveVehicle();
        }
        if(isInside)
        {
            transform.eulerAngles = new Vector3(0, vehicle.transform.eulerAngles.y, 0);
            transform.position = vehicle.transform.position;
        }
    }
    public void EnableColliders(bool enable)
    {
        foreach (Collider col in playerCollisionComponents) col.enabled = enable;
    }
    void EnterVehicle()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        EnableColliders(false);
        camSys.vehicleConfig.mobileTransform = vehicle.transform;
        camSys.camMode = CameraMode.Vehicle;
        camSys.vehicleConfig.vType = VehicleType.Mobile;

        vehicle.Vehicle.canBeDriven = true;
    }
    void LeaveVehicle()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        EnableColliders(true);
        transform.position = vehicle.exitPoint();
        camSys.camMode = CameraMode.Player;
        vehicle.Vehicle.canBeDriven = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<ControllableVehicle>())
        {
            if(vehicle == null)
                vehicle = other.gameObject.GetComponent<ControllableVehicle>();
            vehicle.player = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<ControllableVehicle>() && !vehicle.isInside)
        {
            vehicle.player = null;
            vehicle = null;
        }
    }
}
