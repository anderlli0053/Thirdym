using System.Collections;
using UnityEngine;
using Gann4Games.Thirdym.Enums;
using Gann4Games.Thirdym.ScriptableObjects;

public class EquipmentSystem : MonoBehaviour {
    
    CharacterCustomization _character;

    GameObject _leftHandWeapon;
    GameObject _rightHandWeapon;

    bool UsePlayerPrefs => _character.usePlayerPrefs;
    bool _bladesEnabled;

    bool haveMelee => melee != null;
    bool havePistol => pistol != null;
    bool haveRifle => rifle != null;
    bool haveShotgun => shotgun != null;
    bool haveHeavy => heavy != null;
    bool haveTool => tool != null;

    [Header("Configuration")]
    public Transform dropPosition;

    [Header("Status")]
    public SO_WeaponPreset currentWeapon;
    public bool disarmed => currentWeapon == null;

    [Header("Weapons")]
    public SO_WeaponPreset startWeapon;
    [Space]
    [Tooltip("Self descriptive")]
    public SO_WeaponPreset melee;

    [Tooltip("Self descriptive")]
    public SO_WeaponPreset pistol;

    [Tooltip("Any type of rifle")]
    public SO_WeaponPreset rifle;

    [Tooltip("Self descriptive")]
    public SO_WeaponPreset shotgun;

    [Tooltip("Weapons that are heavy")]
    public SO_WeaponPreset heavy;

    [Tooltip("Tools include the following: Defibrilator, electroshock, more coming soon")]
    public SO_WeaponPreset tool;

    public GameObject[] PSIBlades;
    

    private void Start()
    {
        _character = GetComponent<CharacterCustomization>();
    }

    private void Update()
    {
        if(InputHandler.instance.dropWeapon && !disarmed)
        {
            DropWeapon();
        }
    }

    public bool HasWeapon(SO_WeaponPreset weapon)
    {
        switch(weapon.weaponType)
        {
            case WeaponType.Melee:
                return haveMelee;

            case WeaponType.Pistol:
                return havePistol;

            case WeaponType.Rifle:
                return haveRifle;

            case WeaponType.Shotgun:
                return haveShotgun;

            case WeaponType.Heavy:
                return haveHeavy;

            case WeaponType.Tool:
                return haveTool;
            default:
                return false;
        }
    }
    public IEnumerator Equip(SO_WeaponPreset weapon)
    {
        yield return null;
        _character.Animator.SetBool("ChangingGun", true);
        _character.ArmController.SetArmsSpring(true);

        yield return new WaitForSeconds(0.5f);

        _character.ArmController.aimType = weapon.aimType;
        _character.ArmController.LeftShoulder[0].useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftShoulder[1].useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftBicep.useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftElbow.useSpring = weapon.leftElbowSpring;
        _character.ArmController.RightShoulder[0].useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightShoulder[1].useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightBicep.useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightElbow.useSpring = weapon.rightElbowSpring;

        #region Weapon spawning (hands)
        ClearHands();
        _leftHandWeapon = CreateObjectAt(weapon.leftWeaponModel, _character.baseBody.leftHand, weapon.leftPositionOffset, weapon.leftRotationOffset);
        _rightHandWeapon = CreateObjectAt(weapon.rightWeaponModel, _character.baseBody.rightHand, weapon.rightPositionOffset, weapon.rightRotationOffset);
        #endregion

        _character.Animator.SetBool("ChangingGun", false);

        //StartCoroutine(ShowOnBack(weapon));
        //StartCoroutine(SaveGuns());
        currentWeapon = weapon;
        switch(weapon.weaponType)
        {
            case WeaponType.Melee:

                //CreateObjectAt(weapon.leftWeaponModel, _character.baseBody.leftHand);
                //CreateObjectAt(weapon.rightWeaponModel, _character.baseBody.rightHand);

                _bladesEnabled = true;
                //leftHandIK.GetComponent<SphereCollider>().isTrigger = true;

                foreach (GameObject blade in PSIBlades)
                    blade.SetActive(_bladesEnabled);

                break;

            case WeaponType.Pistol:
                print("Using pistol");
                pistol = weapon;
                break;

            case WeaponType.Rifle:
                rifle = weapon;
                break;

            case WeaponType.Shotgun:
                shotgun = weapon;
                break;

            case WeaponType.Heavy:
                heavy = weapon;
                break;

            case WeaponType.Tool:
                tool = weapon;
                break;

        }
    }

    GameObject CreateObjectAt(GameObject prefab, Transform placeTransform, Vector3 positionOffset, Vector3 rotationOffset)
    {
        if (prefab == null) return null;
        return Instantiate(prefab, placeTransform.position + positionOffset, placeTransform.rotation * Quaternion.Euler(rotationOffset), placeTransform);
    }
    public void ClearHands()
    {
        if (_leftHandWeapon != null)
        {
            Destroy(_leftHandWeapon);
            _leftHandWeapon = null;
        }
        if (_rightHandWeapon != null)
        {
            Destroy(_rightHandWeapon);
            _rightHandWeapon = null;
        }

        currentWeapon = null;
    }
    public void DropWeapon()
    {
        _character.ArmController.SetArmsSpring(true);
        switch (currentWeapon.weaponType)
        {
            case WeaponType.Pistol:
                pistol = null;
                break;

            case WeaponType.Rifle:
                rifle = null;
                break;

            case WeaponType.Shotgun:
                shotgun = null;
                break;

            case WeaponType.Heavy:
                heavy = null;
                break;

            case WeaponType.Tool:
                tool = null;
                break;
        }

        GameObject prefab = Instantiate(currentWeapon.dropPrefab);
        prefab.transform.position = dropPosition.position;
        prefab.transform.rotation = dropPosition.rotation;

        if (_character.isNPC)
            prefab.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        else
            prefab.GetComponent<Rigidbody>().AddForce(GetComponent<PlayerCameraController>().activeCamera.transform.forward * 500);

        ClearHands();
    }
    public void DisableBlades()
    {
        _bladesEnabled = false;
        foreach(GameObject blade in PSIBlades)
            blade.SetActive(_bladesEnabled);
    }
}