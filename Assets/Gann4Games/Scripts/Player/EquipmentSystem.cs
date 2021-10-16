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
        RefreshInventoryHUD();
    }

    private void Update()
    {
        if(InputHandler.instance.dropWeapon && !disarmed)
            DropEquippedWeapon();

        if (InputHandler.instance.gameplayControls.Player.gun_blades.triggered && haveMelee)
            EquipWeapon(melee);
        else if (InputHandler.instance.gameplayControls.Player.gun_pistol.triggered && havePistol)
            EquipWeapon(pistol);
        else if (InputHandler.instance.gameplayControls.Player.gun_rifle.triggered && haveRifle)
            EquipWeapon(rifle);
        else if (InputHandler.instance.gameplayControls.Player.gun_shotgun.triggered && haveShotgun)
            EquipWeapon(shotgun);
        else if (InputHandler.instance.gameplayControls.Player.gun_energy.triggered && haveHeavy)
            EquipWeapon(heavy);
        else if (InputHandler.instance.gameplayControls.Player.gun_explosive.triggered && haveTool)
            EquipWeapon(tool);
    }
    void RefreshInventoryHUD()
    {
        if (_character.isNPC) return;

        if (haveMelee) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Melee, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Melee, EquipMode.None);

        if (havePistol) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Pistol, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Pistol, EquipMode.None);

        if (haveRifle) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Rifle, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Rifle, EquipMode.None);

        if (haveShotgun) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Shotgun, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Shotgun, EquipMode.None);

        if (haveHeavy) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Heavy, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Heavy, EquipMode.None);

        if (haveTool) PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Tool, EquipMode.Stored);
        else PlayerInventoryHUD.DisplayWeaponAs(WeaponType.Tool, EquipMode.None);

        if (!disarmed) PlayerInventoryHUD.DisplayWeaponAs(currentWeapon.weaponType, EquipMode.Equipped);
    }
    public bool HasWeapon(WeaponType weapon)
    {
        switch(weapon)
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
    public void EquipWeapon(SO_WeaponPreset weapon)
    {
        StartCoroutine(Equip(weapon));
    }
    public void DropAllWeapons()
    {
        DropEquippedWeapon();
        DropWeapon(melee);
        DropWeapon(pistol);
        DropWeapon(rifle);
        DropWeapon(shotgun);
        DropWeapon(heavy);
        DropWeapon(tool);
    }
    public void DropEquippedWeapon()
    {
        _character.ArmController.SetArmsSpring(true);

        DropWeapon(currentWeapon);
        ClearHands();
    }
    void StoreWeaponOnInventory(SO_WeaponPreset weapon)
    {
        RefreshInventoryHUD();
        switch (weapon.weaponType)
        {
            case WeaponType.Melee:

                //CreateObjectAt(weapon.leftWeaponModel, _character.baseBody.leftHand);
                //CreateObjectAt(weapon.rightWeaponModel, _character.baseBody.rightHand);

                _bladesEnabled = true;

                foreach (GameObject blade in PSIBlades)
                    blade.SetActive(_bladesEnabled);

                break;

            case WeaponType.Pistol:
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
    IEnumerator Equip(SO_WeaponPreset weapon)
    {
        yield return null;
        #region Arm parameters
        _character.ArmController.aimType = weapon.aimType;
        _character.ArmController.LeftShoulder[0].useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftShoulder[1].useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftBicep.useSpring = weapon.leftShoulderSpring;
        _character.ArmController.LeftElbow.useSpring = weapon.leftElbowSpring;
        _character.ArmController.RightShoulder[0].useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightShoulder[1].useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightBicep.useSpring = weapon.rightShoulderSpring;
        _character.ArmController.RightElbow.useSpring = weapon.rightElbowSpring;
        #endregion

        _character.Animator.SetBool("ChangingGun", true);
        yield return new WaitForSeconds(0.5f);
        _character.Animator.SetBool("ChangingGun", false);

        // Spawn new items
        StoreWeaponOnInventory(weapon);
        DisplayWeaponOnHands(weapon);
        RefreshInventoryHUD();
        currentWeapon = weapon;

    }
    void DropWeapon(SO_WeaponPreset weapon)
    {
        if (weapon == null) return;

        RefreshInventoryHUD();

        switch (weapon.weaponType)
        {
            case WeaponType.Melee:
                melee = null;
                break;
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

        GameObject prefab = Instantiate(weapon.dropPrefab);
        prefab.transform.position = dropPosition.position;
        prefab.transform.rotation = dropPosition.rotation;

        if (_character.isNPC)
            prefab.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        else
            prefab.GetComponent<Rigidbody>().AddForce(GetComponent<PlayerCameraController>().activeCamera.transform.forward * 500);
    }
    void ClearHands()
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
    void DisplayWeaponOnHands(SO_WeaponPreset weapon)
    {
        ClearHands();
        _leftHandWeapon = CreateObjectAt(weapon.leftWeaponModel, _character.baseBody.leftHand, weapon.leftPositionOffset, weapon.leftRotationOffset);
        _rightHandWeapon = CreateObjectAt(weapon.rightWeaponModel, _character.baseBody.rightHand, weapon.rightPositionOffset, weapon.rightRotationOffset);
    }
    void DisableBlades()
    {
        _bladesEnabled = false;
        foreach(GameObject blade in PSIBlades)
            blade.SetActive(_bladesEnabled);
    }
    GameObject CreateObjectAt(GameObject prefab, Transform placeTransform, Vector3 positionOffset, Vector3 rotationOffset)
    {
        if (prefab == null) return null;
        return Instantiate(prefab, placeTransform.position + positionOffset, placeTransform.rotation * Quaternion.Euler(rotationOffset), placeTransform);
    }
}