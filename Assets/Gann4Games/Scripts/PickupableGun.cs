using UnityEngine;
using Gann4Games.Thirdym.Enums;
using Gann4Games.Thirdym.Localization; // Maybe another code smell ... ?
using Gann4Games.Thirdym.ScriptableObjects;
[RequireComponent(typeof(CollisionEvents))]
public class PickupableGun : MonoBehaviour {
    public SO_WeaponPreset weaponData;

    public Weapons GunType;

    public string gunName;

    [SerializeField] AudioClip pickupSFX;
    [SerializeField] AudioClip collisionClip2;
    [SerializeField] AudioClip collisionClip1;

    CharacterCustomization _character;
    AudioSource _auSource;

    CollisionEvents _collisionEvents;

    GameObject _weaponModel;
    private void OnEnable()
    {
        _collisionEvents.OnCollideSoft += OnCollideSoft;
        _collisionEvents.OnCollideMedium += OnCollideMedium;
    }
    private void OnDisable()
    {
        _collisionEvents.OnCollideSoft -= OnCollideSoft;
        _collisionEvents.OnCollideMedium -= OnCollideMedium;
    }
    private void Start()
    {
        AddVisuals();
        AddPhysics();
        _auSource = gameObject.AddComponent<AudioSource>();
        _auSource.spatialBlend = 1;
    }
    void AddVisuals()
    {
        
        if (_weaponModel == null)
        {
            _weaponModel = Instantiate(weaponData.rightWeaponModel, transform.position, transform.rotation);
            _weaponModel.transform.SetParent(transform);
        }
    }
    void AddPhysics()
    {
        MeshCollider mesh = gameObject.AddComponent<MeshCollider>();
        mesh.sharedMesh = _weaponModel.GetComponent<MeshFilter>().sharedMesh;
        mesh.convex = true;
    }
    void OnCollideSoft(object sender, CollisionEvents.CollisionArgs args)
    {
        _auSource.PlayOneShot(collisionClip1);
    }
    void OnCollideMedium(object sender, CollisionEvents.CollisionArgs args)
    {
        _auSource.PlayOneShot(collisionClip2);
    }
    private void OnTriggerEnter(Collider other)
    {
        CharacterCustomization character = other.GetComponent<CharacterCustomization>();
        if (character)
        {
            if (character.isNPC)
            {
                //character.NPC.lookingForGuns = false;
                //character.NPC.lookingForPlayer = true;
                throw new System.NotImplementedException(message: "NPCs can't pick weapons yet.");
            }
        }

        _character = other.GetComponent<CharacterCustomization>();
        if (_character)
        {
            
            #region Pistols
            if(_character.EquipmentController.pistol == null)
            {
                _character.EquipmentController.pistol = weaponData;
                Transform rightHand = _character.baseBody.rightHand;
                Instantiate(weaponData.rightWeaponModel, rightHand.position, rightHand.rotation);

            }
            if (_character.EquipmentController.HavePistol == false)
            {
                switch(GunType)
                {
                    case Weapons.PistolC01p:
                        SetPistol(1);
                        break;
                    case Weapons.PistolCSPro:
                        SetPistol(2);
                        break;
                }
            }
            #endregion
            #region Automatics
            if (_character.EquipmentController.HaveAutomatic == false)
            {
                switch(GunType)
                {
                    case Weapons.RifleC01r:
                        SetAutomatic(1);
                        break;
                    case Weapons.RifleCSRC:
                        SetAutomatic(2);
                        break;
                    case Weapons.RifleC02m:
                        SetAutomatic(3);
                        break;
                    case Weapons.RifleAlien:
                        SetAutomatic(4);
                        break;
                }
            }
            #endregion
            #region Shotguns
            if (_character.EquipmentController.HaveShotgun == false)
            {
                switch(GunType)
                {
                    case Weapons.ShotgunCSDAZ:
                        SetShotgun(1);
                        break;
                }
            }
            #endregion
            #region EnergyBased
            if (_character.EquipmentController.HaveEnergyBased == false)
            {
                switch(GunType)
                {
                    case Weapons.EnergyCSBNG:
                        SetEnergyBased(1);
                        break;
                    case Weapons.EnergyHeavyRailgun:
                        SetEnergyBased(2);
                        break;
                }
            }
            #endregion
            if (_character.EquipmentController.HaveDefibrilators == false)
            {
                switch(GunType)
                {
                    case Weapons.DefibrilatorElectroshock:
                        SetElectro();
                        break;
                }
            }
            _character.StartCoroutine(_character.EquipmentController.ShowOnBack(0));
        }
        
    }
    public void SetPistol(int Slot)
    {
        PlayerInventoryHUD.SetWeapon(WeaponCategory.Pistol, EquipMode.Pickup);
        _character.EquipmentController.PistolSlot = Slot;
        _character.EquipmentController.HavePistol = true;
        _character.SoundSource.PlayOneShot(pickupSFX);
        //equipment.DisableAll();
        Destroy(gameObject, 0.01f);
        OnPickedUp();
    }
    public void SetAutomatic(int Slot)
    {
        PlayerInventoryHUD.SetWeapon(WeaponCategory.Automatic, EquipMode.Pickup);
        _character.EquipmentController.AutomaticSlot = Slot;
        _character.EquipmentController.HaveAutomatic = true;
        _character.SoundSource.PlayOneShot(pickupSFX);
        //equipment.DisableAll();
        Destroy(gameObject, 0.01f);
        OnPickedUp();
    }
    public void SetShotgun(int Slot)
    {
        PlayerInventoryHUD.SetWeapon(WeaponCategory.Shotgun, EquipMode.Pickup);
        _character.EquipmentController.ShotgunSlot = Slot;
        _character.EquipmentController.HaveShotgun = true;
        _character.SoundSource.PlayOneShot(pickupSFX);
        //equipment.DisableAll();
        Destroy(gameObject, 0.01f);
        OnPickedUp();
    }
    public void SetEnergyBased(int Slot)
    {
        PlayerInventoryHUD.SetWeapon(WeaponCategory.EnergyBased, EquipMode.Pickup);
        _character.EquipmentController.EnergySlot = Slot;
        _character.EquipmentController.HaveEnergyBased = true;
        _character.SoundSource.PlayOneShot(pickupSFX);
        //equipment.DisableAll();
        Destroy(gameObject, 0.01f);
        OnPickedUp();
    }
    public void SetElectro()
    {
        PlayerInventoryHUD.SetWeapon(WeaponCategory.Defibrilator, EquipMode.Pickup);
        _character.EquipmentController.HaveDefibrilators = true;
        _character.SoundSource.PlayOneShot(pickupSFX);
        //equipment.DisableAll();
        Destroy(gameObject, 0.01f);
        OnPickedUp();
    }

    void OnPickedUp()
    {
        if (!_character.isNPC)
        {
            switch (LanguagePrefs.Language)
            {
                case AvailableLanguages.English:
                    NotificationHandler.Notify("Picked up " + gunName, 2, 2, false);
                    break;
                case AvailableLanguages.Español:
                    NotificationHandler.Notify("Agarraste " + gunName, 2, 2, false);
                    break;
            }
        }
    }
}
