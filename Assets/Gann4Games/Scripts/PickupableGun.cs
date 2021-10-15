using UnityEngine;
using Gann4Games.Thirdym.Localization; // Maybe another code smell ... ?
using Gann4Games.Thirdym.ScriptableObjects;

[RequireComponent(typeof(CollisionEvents))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class PickupableGun : MonoBehaviour {
    public SO_WeaponPreset weaponData;

    [SerializeField] AudioClip pickupSFX;
    [SerializeField] AudioClip collisionClip2;
    [SerializeField] AudioClip collisionClip1;

    CharacterCustomization _character;
    AudioSource _auSource;

    CollisionEvents _collisionEvents;

    GameObject _weaponModel;

    private void Awake()
    {
        _collisionEvents = GetComponent<CollisionEvents>();
    }
    private void Start()
    {
        _auSource = gameObject.AddComponent<AudioSource>();
        _auSource.spatialBlend = 1;
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
        _character = other.GetComponent<CharacterCustomization>();

        if (_character)
        {
            if (_character.isNPC)
            {
                //character.NPC.lookingForGuns = false;
                //character.NPC.lookingForPlayer = true;
                throw new System.NotImplementedException(message: "NPCs can't pick weapons yet.");
            }
            EquipWeapon(weaponData);
        }
        
    }

    public void EquipWeapon(SO_WeaponPreset weapon)
    {
        if (_character.EquipmentController.HasWeapon(weapon))
        {
            AlreadyEquippedAlert(weapon);
            return;
        }

        _character.StartCoroutine(_character.EquipmentController.Equip(weapon));
        OnPickedUp();
    }
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
    void OnPickedUp()
    {
        Destroy(gameObject);
        if (!_character.isNPC)
        {
            switch (LanguagePrefs.Language)
            {
                case AvailableLanguages.English:
                    NotificationHandler.Notify("Picked up " + weaponData.weaponName, 2, 2, false);
                    break;
                case AvailableLanguages.Español:
                    NotificationHandler.Notify("Agarraste " + weaponData.weaponName, 2, 2, false);
                    break;
            }
        }
    }

    void AlreadyEquippedAlert(SO_WeaponPreset weapon)
    {
        if (!_character.isNPC)
        {
            switch (LanguagePrefs.Language)
            {
                case AvailableLanguages.English:
                    NotificationHandler.Notify("You already have a " + weaponData.weaponType.ToString(), 2, 2, false);
                    break;
                case AvailableLanguages.Español:
                    NotificationHandler.Notify("Ya tienes " + weaponData.weaponType.ToString(), 2, 2, false);
                    break;
            }
        }
    }
}
