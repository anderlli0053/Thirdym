using System.Collections;
using UnityEngine;
using Gann4Games.Thirdym.Enums;

[System.Serializable]
public class WeaOnBack
{
    [Header("Pistols")]
    public GameObject C01p;
    public GameObject CsPro;

    [Header("Automatics")]
    public GameObject C01r;
    public GameObject CsRc;
    public GameObject C02m;
    public GameObject AlienRifle;

    [Header("Shotguns")]
    public GameObject CSDAZ;

    [Header("Energy Based")]
    public GameObject CSBNG;
    public GameObject HeavyRailgun;

    [Header("Melee")]
    public GameObject Electroshock;
}
[System.Serializable]
public class WeaPrefabs
{
    public Transform dropPosition;
    [Header("Pistols")]
    public GameObject C01p;
    public GameObject CSPro;
    [Header("Automatics")]
    public GameObject C01r;
    public GameObject CSRC;
    public GameObject C02m;
    public GameObject AlienRifle;
    [Header("Shotguns")]
    public GameObject CSDAZ;
    [Header("Energy Based")]
    public GameObject CSBNG;
    public GameObject HeavyRailgun;
    [Header("Melee")]
    public GameObject Electroshock;
}
public class EquipmentSystem : MonoBehaviour {
    bool UsePlayerPrefs => _character.usePlayerPrefs;

    public SpringJoint IK;
    [HideInInspector] public int currentWeapon;
    public int StartWeapon;
    public bool useStartWeapon = false;
    public WeaOnBack VisibleWeapons;
    public WeaPrefabs Prefabs;
    
    public bool disarmed;

    [Header("Pistols")]
    public bool HavePistol;
    public int PistolSlot;
    public GameObject C01p;
    public GameObject CSPro;

    [Header("Automatics")]
    public bool HaveAutomatic;
    public int AutomaticSlot;
	public GameObject C01r;
    public GameObject CSRC;
    public GameObject C02m;
    public GameObject AlienRifle;

    [Header("Shotguns")]
    public bool HaveShotgun;
    public int ShotgunSlot;
    public GameObject CSDAZ;

    [Header("Energy Based")]
    public bool HaveEnergyBased;
    public int EnergySlot;
    public GameObject CSBNG;
    public GameObject HeavyRailgun;
    [Header("Explosives")]
    public bool HaveExplosives;

    [Header("Melee")]
    public bool HaveDefibrilators;
    public GameObject Electroshock;

    public GameObject[] PSIBlades;
    
    bool _bladesEnabled;
    CharacterCustomization _character;

    private void Start()
    {
        _character = GetComponent<CharacterCustomization>();
        if (!_character.isNPC)
        {
            #region Load Guns
            if (UsePlayerPrefs)
            {
                PistolSlot = PlayerPreferences.instance.GetJsonData().weapons_pistolSlot;
                HavePistol = PlayerPreferences.instance.GetJsonData().weapons_havePistol;

                AutomaticSlot = PlayerPreferences.instance.GetJsonData().weapons_automaticSlot;
                HaveAutomatic = PlayerPreferences.instance.GetJsonData().weapons_haveAutomatic;

                ShotgunSlot = PlayerPreferences.instance.GetJsonData().weapons_shotgunSlot;
                HaveShotgun = PlayerPreferences.instance.GetJsonData().weapons_haveShotgun;

                EnergySlot = PlayerPreferences.instance.GetJsonData().weapons_energySlot;
                HaveEnergyBased = PlayerPreferences.instance.GetJsonData().weapons_haveEnergyBased;

                HaveDefibrilators = PlayerPreferences.instance.GetJsonData().weapons_haveDefibrilators;
            }
            StartCoroutine(ShowOnBack(0));
            ReloadHUD();
            StartCoroutine(Equip(0));
            #endregion
        }
        if (useStartWeapon)
            StartCoroutine(Equip(StartWeapon));
    }
    private void FixedUpdate()
    {
        if (!_character.HealthController.IsDead)
        {
            if (InputHandler.instance.gameplayControls.Player.DropItem.triggered && !_character.isNPC)
            {
                DropAction();
                if (!_character.RagdollController.enviroment.IsDraggingBody) StartCoroutine(Equip(0));
            }
        }
    }
    private void Update()
    {
        if (!_character.HealthController.IsDead && _character.isNPC == false)
        {
            if (InputHandler.instance.gameplayControls.Player.gun_pistol.triggered && HavePistol)
                StartCoroutine(Equip(1));
            if (InputHandler.instance.gameplayControls.Player.gun_rifle.triggered && HaveAutomatic)
                StartCoroutine(Equip(2));
            if (InputHandler.instance.gameplayControls.Player.gun_shotgun.triggered && HaveShotgun)
                StartCoroutine(Equip(3));
            if (InputHandler.instance.gameplayControls.Player.gun_energy.triggered && HaveEnergyBased)
                StartCoroutine(Equip(4));
            if (InputHandler.instance.gameplayControls.Player.gun_explosive.triggered && HaveExplosives)
            {
                StartCoroutine(Equip(5));
                _character.ArmController.aimType = 0;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (InputHandler.instance.gameplayControls.Player.gun_defibrilator.triggered && HaveDefibrilators)
                StartCoroutine(Equip(6));
            if (InputHandler.instance.gameplayControls.Player.gun_blades.triggered)
                StartCoroutine(Equip(0));

            #region Gamepad logic

            if(InputHandler.instance.gameplayControls.Player.gun_next.triggered)
            {
                EquipFromScroll(1);
            }
            else if(InputHandler.instance.gameplayControls.Player.gun_previous.triggered)
            {
                EquipFromScroll(-1);
            }

            #endregion
        }

    }
    void EquipFromScroll(int choosenWeapon)
    {
        currentWeapon += choosenWeapon;
        bool hasWeapon = false;
        switch (currentWeapon)
        {
            case 0:
                hasWeapon = true;
                break;
            case 1:
                if (HavePistol) hasWeapon = true;
                break;
            case 2:
                if (HaveAutomatic) hasWeapon = true;
                break;
            case 3:
                if (HaveShotgun) hasWeapon = true;
                break;
            case 4:
                if (HaveEnergyBased) hasWeapon = true;
                break;
            case 5:
                if (HaveExplosives) hasWeapon = true;
                break;
            case 6:
                if (HaveDefibrilators) hasWeapon = true;
                break;
        }
        if (currentWeapon > 6) currentWeapon = 0;
        else if (currentWeapon < 0) currentWeapon = 6;
        if(hasWeapon) StartCoroutine(Equip(currentWeapon));
        Debug.Log(currentWeapon);
    }
    void ReloadHUD()
    {
        if (_character.isNPC) return;
        if (HavePistol) PlayerInventoryHUD.SetWeapon(WeaponCategory.Pistol, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.Pistol, EquipMode.Drop);

        if (HaveAutomatic) PlayerInventoryHUD.SetWeapon(WeaponCategory.Automatic, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.Automatic, EquipMode.Drop);

        if (HaveShotgun) PlayerInventoryHUD.SetWeapon(WeaponCategory.Shotgun, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.Shotgun, EquipMode.Drop);

        if (HaveEnergyBased) PlayerInventoryHUD.SetWeapon(WeaponCategory.EnergyBased, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.EnergyBased, EquipMode.Drop);

        if (HaveExplosives) PlayerInventoryHUD.SetWeapon(WeaponCategory.Explosives, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.Explosives, EquipMode.Drop);

        if (HaveDefibrilators) PlayerInventoryHUD.SetWeapon(WeaponCategory.Defibrilator, EquipMode.Pickup);
        else PlayerInventoryHUD.SetWeapon(WeaponCategory.Defibrilator, EquipMode.Drop);

        PlayerInventoryHUD.SetWeapon(WeaponCategory.Melee, EquipMode.Pickup);
    }
    public IEnumerator ShowOnBack(int Category)
    {
        yield return new WaitForSeconds(0.1f);
        if (HavePistol)
        {
            if (Category != 1)
            {
                if (PistolSlot == 1)
                    VisibleWeapons.C01p.SetActive(true);
                else if (PistolSlot == 2)
                    VisibleWeapons.CsPro.SetActive(true);
            }
        }
        else
        {
            VisibleWeapons.C01p.SetActive(false);
            VisibleWeapons.CsPro.SetActive(false);
        }

        if (HaveAutomatic)
        {
            if (Category != 2)
            {
                if (AutomaticSlot == 1)
                    VisibleWeapons.C01r.SetActive(true);
                else if (AutomaticSlot == 2)
                    VisibleWeapons.CsRc.SetActive(true);
                else if (AutomaticSlot == 3)
                    VisibleWeapons.C02m.SetActive(true);
                else if (AutomaticSlot == 4)
                    VisibleWeapons.AlienRifle.SetActive(true);
            }
        }
        else
        {
            VisibleWeapons.C01r.SetActive(false);
            VisibleWeapons.CsRc.SetActive(false);
            VisibleWeapons.C02m.SetActive(false);
            VisibleWeapons.AlienRifle.SetActive(false);
        }

        if (HaveShotgun)
        {
            if(Category != 3)
            {
                if (ShotgunSlot == 1)
                    VisibleWeapons.CSDAZ.SetActive(true);
            }
        }
        else
        {
            VisibleWeapons.CSDAZ.SetActive(false);
        }

        if (HaveEnergyBased)
        {
            if (Category != 4)
            {
                if (EnergySlot == 1)
                    VisibleWeapons.CSBNG.SetActive(true);
                else if (EnergySlot == 2)
                    VisibleWeapons.HeavyRailgun.SetActive(true);
            }
        }
        else
        {
            VisibleWeapons.CSBNG.SetActive(false);
            VisibleWeapons.HeavyRailgun.SetActive(false);
        }

        if (HaveDefibrilators)
        {
            if (Category != 6)
                VisibleWeapons.Electroshock.SetActive(true);
        }
        else
            VisibleWeapons.Electroshock.SetActive(false);
    }
    public IEnumerator Equip(int Category)
    {
        yield return null;
        _character.Animator.SetBool("ChangingGun", true);
        ReloadHUD();

        _character.ArmController.LeftShoulder[0].useSpring = true;
        _character.ArmController.LeftShoulder[1].useSpring = true;
        _character.ArmController.LeftBicep.useSpring = true;
        _character.ArmController.LeftElbow.useSpring = true;
        _character.ArmController.RightShoulder[0].useSpring = true;
        _character.ArmController.RightShoulder[1].useSpring = true;
        _character.ArmController.RightBicep.useSpring = true;
        _character.ArmController.RightElbow.useSpring = true;

        yield return new WaitForSeconds(0.5f);

        _character.Animator.SetBool("ChangingGun", false);
        DisableAll();
        disarmed = false;
        StartCoroutine(ShowOnBack(Category));
        StartCoroutine(SaveGuns());
        
        if (Category == 0)
        {
            _character.ArmController.aimType = 2;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            _bladesEnabled = true;
            disarmed = false;
            IK.spring = 0;
            IK.GetComponent<SphereCollider>().isTrigger = true;

            foreach (GameObject blade in PSIBlades)
                blade.SetActive(_bladesEnabled);
        }

        #region Pistols
        if (Category == 1 && HavePistol)
        {

            _character.ArmController.aimType = 1;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            if (PistolSlot == 1)
            {
                C01p.SetActive(true);
                VisibleWeapons.C01p.SetActive(false);

                IK.anchor = new Vector3(0, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (PistolSlot == 2)
            {
                CSPro.SetActive(true);
                VisibleWeapons.CsPro.SetActive(false);

                IK.anchor = new Vector3(0, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
        }
        #endregion
        #region Automatics
        if (Category == 2 && HaveAutomatic)
        {
            _character.ArmController.aimType = 0;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            if (AutomaticSlot == 1)
            {
                C01r.SetActive(true);
                VisibleWeapons.C01r.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (AutomaticSlot == 2)
            {
                CSRC.SetActive(true);
                VisibleWeapons.CsRc.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (AutomaticSlot == 3)
            {
                C02m.SetActive(true);
                VisibleWeapons.C02m.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (AutomaticSlot == 4)
            {
                AlienRifle.SetActive(true);
                VisibleWeapons.AlienRifle.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
        }
        #endregion
        #region Shotguns
        if (Category == 3 && HaveShotgun)
        {
            _character.ArmController.aimType = 0;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            if (ShotgunSlot == 1)
            {
                CSDAZ.SetActive(true);
                VisibleWeapons.CSDAZ.SetActive(false);

                IK.anchor = new Vector3(225, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
        }
        #endregion
        #region Energy Based
        if (Category == 4 && HaveEnergyBased)
        {
            _character.ArmController.aimType = 0;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            if (EnergySlot == 1)
            {
                CSBNG.SetActive(true);
                VisibleWeapons.CSBNG.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
            if (EnergySlot == 2)
            {
                HeavyRailgun.SetActive(true);
                VisibleWeapons.HeavyRailgun.SetActive(false);

                IK.anchor = new Vector3(200, 0, 0);
                IK.spring = 12000;
                IK.GetComponent<SphereCollider>().isTrigger = false;
            }
        }
        #endregion
        #region Defibrilator
        if (Category == 6 && HaveDefibrilators)
        {
            _character.ArmController.aimType = 1;

            _character.ArmController.RightShoulder[0].useSpring = true;
            _character.ArmController.RightShoulder[1].useSpring = true;
            _character.ArmController.RightBicep.useSpring = true;
            _character.ArmController.RightElbow.useSpring = true;

            _character.ArmController.LeftShoulder[0].useSpring = true;
            _character.ArmController.LeftShoulder[1].useSpring = true;
            _character.ArmController.LeftBicep.useSpring = true;
            _character.ArmController.LeftElbow.useSpring = true;

            Electroshock.SetActive(true);
            VisibleWeapons.Electroshock.SetActive(false);

            IK.anchor = new Vector3(0, 0, 0);
            IK.spring = 12000;
            IK.GetComponent<SphereCollider>().isTrigger = false;
        }
        #endregion

        currentWeapon = Category;
        if (!_character.isNPC)
        {
            switch (currentWeapon)
            {
                case 0:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.Melee, EquipMode.Equip);
                    break;
                case 1:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.Pistol, EquipMode.Equip);
                    break;
                case 2:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.Automatic, EquipMode.Equip);
                    break;
                case 3:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.Shotgun, EquipMode.Equip);
                    break;
                case 4:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.EnergyBased, EquipMode.Equip);
                    break;
                case 6:
                    PlayerInventoryHUD.SetWeapon(WeaponCategory.Defibrilator, EquipMode.Equip);
                    break;
            }
        }
    }
    public IEnumerator SaveGuns()
    {
        yield return new WaitForSeconds(0.25f);
        if (UsePlayerPrefs)
        {
            PlayerPreferences.PlayerPreferencesJson json_data = PlayerPreferences.instance.json_structure;
            json_data.weapons_pistolSlot = PistolSlot;
            json_data.weapons_automaticSlot = AutomaticSlot;
            json_data.weapons_shotgunSlot = ShotgunSlot;
            json_data.weapons_energySlot = EnergySlot;
            json_data.weapons_havePistol = HavePistol;
            json_data.weapons_haveAutomatic = HaveAutomatic;
            json_data.weapons_haveShotgun = HaveShotgun;
            json_data.weapons_haveEnergyBased = HaveEnergyBased;
            json_data.weapons_haveDefibrilators = HaveDefibrilators;
            PlayerPreferences.instance.RefreshJsonFile();
        }
    }
    public void DropAction()
    {
        #region Pistols
        if (C01p.activeInHierarchy)
        {
            DropGun(Prefabs.C01p, C01p);
            HavePistol = false;
        }
        if (CSPro.activeInHierarchy)
        {
            DropGun(Prefabs.CSPro, CSPro);
            HavePistol = false;
        }
        #endregion
        #region Automatics
        if (C01r.activeInHierarchy)
        {
            DropGun(Prefabs.C01r, C01r);
            HaveAutomatic = false;
        }
        if (CSRC.activeInHierarchy)
        {
            DropGun(Prefabs.CSRC, CSRC);
            HaveAutomatic = false;
        }
        if (C02m.activeInHierarchy)
        {
            DropGun(Prefabs.C02m, C02m);
            HaveAutomatic = false;
        }
        if (AlienRifle.activeInHierarchy)
        {
            DropGun(Prefabs.AlienRifle, AlienRifle);
            HaveAutomatic = false;
        }
        #endregion
        #region Shotguns
        if(CSDAZ.activeInHierarchy)
        {
            DropGun(Prefabs.CSDAZ, CSDAZ);
            HaveShotgun = false;
        }
        #endregion
        #region Energy Based
        if (CSBNG.activeInHierarchy)
        {
            DropGun(Prefabs.CSBNG, CSBNG);
            HaveEnergyBased = false;
        }
        if (HeavyRailgun.activeInHierarchy)
        {
            DropGun(Prefabs.HeavyRailgun, HeavyRailgun);
            HaveEnergyBased = false;
        }
        #endregion
        #region Melee
        if (Electroshock.activeInHierarchy)
        {
            DropGun(Prefabs.Electroshock, Electroshock);
            HaveDefibrilators = false;
        }
        if (_bladesEnabled)
        {
            _bladesEnabled = false;
            disarmed = true;
            foreach (GameObject blade in PSIBlades)
                blade.SetActive(_bladesEnabled);
        }
        #endregion

        if (_character.isNPC) return;
        if (!HavePistol) PlayerInventoryHUD.SetWeapon(WeaponCategory.Pistol, EquipMode.Drop);
        if (!HaveAutomatic) PlayerInventoryHUD.SetWeapon(WeaponCategory.Automatic, EquipMode.Drop);
        if (!HaveShotgun) PlayerInventoryHUD.SetWeapon(WeaponCategory.Shotgun, EquipMode.Drop);
        if (!HaveEnergyBased) PlayerInventoryHUD.SetWeapon(WeaponCategory.EnergyBased, EquipMode.Drop);
        if (!HaveExplosives) PlayerInventoryHUD.SetWeapon(WeaponCategory.Explosives, EquipMode.Drop);
        if (!HaveDefibrilators) PlayerInventoryHUD.SetWeapon(WeaponCategory.Defibrilator, EquipMode.Drop);
    }
    public void DropGun(GameObject gunPrefab, GameObject equippedObj)
    {
        IK.anchor = new Vector3(0, 0, 0);
        IK.spring = 0;
        IK.GetComponent<SphereCollider>().isTrigger = true;

        GameObject prefab = Instantiate(gunPrefab);
        prefab.transform.position = Prefabs.dropPosition.position;
        prefab.transform.rotation = Prefabs.dropPosition.rotation;
        equippedObj.SetActive(false);
        disarmed = true;
        if (_character.isNPC)
            prefab.GetComponent<Rigidbody>().AddForce(transform.forward * 500);
        else
            prefab.GetComponent<Rigidbody>().AddForce(GetComponent<PlayerCameraController>().activeCamera.transform.forward * 500);
    }
    public void DisableAll()
    {
        DisablePistols();
        DisableAutomatics();
        DisableShotguns();
        DisableEnergyBased();
        DisableDefibrilators();
        DisableBlades();
    }
    public void DisablePistols()
    {
        if (C01p.activeInHierarchy) //1
            C01p.SetActive(false);
        if (CSPro.activeInHierarchy) //2
            CSPro.SetActive(false);
    }
    public void DisableAutomatics()
    {
        if (C01r.activeInHierarchy) //1
            C01r.SetActive(false);
        if (CSRC.activeInHierarchy) //2
            CSRC.SetActive(false);
        if (C02m.activeInHierarchy) //3
            C02m.SetActive(false);
        if (AlienRifle.activeInHierarchy) //4
            AlienRifle.SetActive(false);
    }
    public void DisableShotguns()
    {
        if (CSDAZ.activeInHierarchy) //1
            CSDAZ.SetActive(false);
    }
    public void DisableEnergyBased()
    {
        if (CSBNG.activeInHierarchy) //1
            CSBNG.SetActive(false);
        if (HeavyRailgun.activeInHierarchy) //2
            HeavyRailgun.SetActive(false);
    }
    public void DisableDefibrilators()
    {
        if (Electroshock.activeInHierarchy)
            Electroshock.SetActive(false);
    }
    public void DisableBlades()
    {
        _bladesEnabled = false;
        foreach(GameObject blade in PSIBlades)
            blade.SetActive(_bladesEnabled);
    }
}