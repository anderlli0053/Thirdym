using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterArms : MonoBehaviour {
    [HideInInspector]
    public Animator anim;
    public float aimStatus; //Value 0 is not aiming, value 1 is aiming.
    public float aimType; //Value 0 for all, value 1 for pistols.
    //public HingeJoint[] armsMotion;
    public HingeJoint[] LeftShoulder, RightShoulder;
    public HingeJoint LeftBicep, RightBicep, LeftElbow, RightElbow;
    public HingeJoint[] Neck;
    CharacterCustomization _character;
    EquipmentSystem equipment;
    CharacterHealthSystem healthOp;

    public List<HingeJoint> GetUpperBodyParts()
    {
        List<HingeJoint> joints = new List<HingeJoint>
        {
            LeftShoulder[0],
            LeftShoulder[1],
            RightShoulder[0],
            RightShoulder[1],

            LeftBicep,
            RightBicep,

            LeftElbow,
            RightElbow,

            Neck[0],
            Neck[1]
        };

        return joints;
    }
    public void SetArmsSpring(bool useSpring)
    {
        foreach(HingeJoint bodypart in GetUpperBodyParts())
        {
            bodypart.useSpring = useSpring;
        }
    }
    private void Start()
    {
        _character = GetComponent<CharacterCustomization>();
        anim = _character.Animator;
        equipment = GetComponent<EquipmentSystem>();
        healthOp = GetComponent<CharacterHealthSystem>();
    }
    private void Update()
    {
        if (Neck[0] == null || Neck[1] == null)
        {
            Destroy(GetComponent<RagdollController>());
            Destroy(GetComponent<EquipmentSystem>());
            Destroy(GetComponent<ShootSystem>());
            Destroy(GetComponent<CharacterHealthSystem>());
            Destroy(GetComponent<PlayerCameraController>());
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            healthOp.DealDamage(healthOp.CurrentHealth, Vector3.zero);
            HingeJoint[] hj = GetComponentsInChildren<HingeJoint>();
            for(int i = 0; i < hj.Length; i++)
                hj[i].useSpring = false;
            Destroy(this, 0.1f);
        }
        if (anim)
        {
            if (!healthOp.IsDead)
            {
                foreach (HingeJoint neckJoint in Neck)
                {
                    if (!neckJoint) return;
                    neckJoint.useSpring = true;
                }
                #region Arms controll
                anim.SetBool("Disarmed", equipment.disarmed);
                anim.SetFloat("AimStatus", aimStatus);
                anim.SetFloat("AimType", aimType);
                if (!_character.isNPC)
                {
                    if (InputHandler.instance.aiming && !equipment.disarmed && !equipment.disarmed)
                    {
                        aimStatus = Mathf.Lerp(aimStatus, 1, Time.deltaTime * 10);
                        AimGun(true); // New aim system (improved aiming)
                    }
                    else
                    {
                        aimStatus = Mathf.Lerp(aimStatus, 0, Time.deltaTime * 10);
                        AimGun(false);
                    }

                    //
                    if (equipment.disarmed)
                    {
                        if (InputHandler.instance.firing || InputHandler.instance.aiming)
                            anim.SetBool("ArmsForward", true);
                        else
                            anim.SetBool("ArmsForward", false);

                        if (InputHandler.instance.firing && InputHandler.instance.aiming)
                            anim.SetFloat("Arm", 0);
                        else if (InputHandler.instance.firing)
                            anim.SetFloat("Arm", -1);
                        else if (InputHandler.instance.aiming)
                            anim.SetFloat("Arm", 1);
                        else
                        {
                            if(anim.GetFloat("Arm") != 0)
                                anim.SetFloat("Arm", 0);
                        }
                    }
                    else
                    {
                        if (InputHandler.instance.firing)
                            anim.SetFloat("Arm", -1);
                        else if (!InputHandler.instance.firing)
                            anim.SetFloat("Arm", 0);
                    }
                }
                else
                {
                    aimStatus = 1;
                }
                #endregion
            }
            else {
                if(anim.GetFloat("Arm") != 0) anim.SetFloat("Arm", 0); // Stop swords movements
                foreach (HingeJoint neckJoint in Neck)
                {
                    if (!neckJoint) return;
                    neckJoint.useSpring = false;
                }
            }
        }
    }

    public void AimGun(bool aim)
    {
        if (IngameMenuHandler.instance.paused) return;
        if (aim)
        {
            _character.baseBody.rightHand.LookAt(PlayerCameraController.instance.CameraCenterPoint);
            _character.baseBody.rightHand.Rotate(-90, -90, 0);
        }
        else
        {
            _character.baseBody.rightHand.localRotation = Quaternion.Lerp(_character.baseBody.rightHand.localRotation, Quaternion.identity, Time.deltaTime*10);
        }
    }
}
