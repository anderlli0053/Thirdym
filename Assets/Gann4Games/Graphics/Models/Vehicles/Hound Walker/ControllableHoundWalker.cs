using UnityEngine;
using Gann4Games.Thirdym.Enums;

public class ControllableHoundWalker : MonoBehaviour {
    public CharacterCustomization ragdollIn;

    HoundWalker _walker;
    BoxCollider _collider;
    bool _controlling = false;

    public Vector3 exitPoint()
    {
        return transform.position + transform.TransformDirection(_collider.center);
    }
    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
        _walker = GetComponentInParent<HoundWalker>();
    }
    private void Update()
    {
        if (ragdollIn)
        {
            if (_controlling)
            {
                PlayerCameraController cam = ragdollIn.GetComponent<PlayerCameraController>();
                if (InputHandler.instance.use)
                {
                    ragdollIn.GetComponent<Rigidbody>().isKinematic = false;
                    ragdollIn.transform.position = exitPoint();
                    ragdollIn.GetComponent<Player_VehicleUse>().EnableColliders(true);
                    cam.camMode = CameraMode.Player;
                    _controlling = false;
                    ragdollIn = null;
                }
                if (!ragdollIn.GetComponent<Rigidbody>().isKinematic)
                    ragdollIn.GetComponent<Rigidbody>().isKinematic = true;
                ragdollIn.GetComponent<Player_VehicleUse>().EnableColliders(false);
                ragdollIn.transform.position = transform.position;
                cam.vehicleConfig.walkerTransform = transform;
                cam.camMode = CameraMode.Vehicle;
                cam.vehicleConfig.vType = VehicleType.Walker;
                WalkerControl();
            }
            else
            {
                if (InputHandler.instance.use)
                {
                    _controlling = true;
                }
            }
        }
    }
    void WalkerControl()
    {
        _walker.body.GetComponent<Rigidbody>().AddRelativeTorque(new Vector3(0, 0, InputHandler.instance.movementAxis.x* 50), ForceMode.Acceleration);
        _walker.anim.SetBool("walk", InputHandler.instance.movementAxis.y>0);
        if (InputHandler.instance.jumping)
            _walker.anim.SetTrigger("jump");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<CharacterCustomization>())
        {
            CharacterCustomization _ragdoll = other.GetComponent<CharacterCustomization>();
            if (!_ragdoll.isNPC)
            {
                ragdollIn = _ragdoll;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(!_controlling)
            ragdollIn = null;
    }
}
