using UnityEngine;
using Gann4Games.Thirdym.Localization; // Maybe another code smell ... ?
using Gann4Games.Thirdym.ScriptableObjects;
using UnityEditor;
using UnityEngine.Serialization;

[RequireComponent(typeof(CollisionEvents))]
[RequireComponent(typeof(Rigidbody))]
public class PickupableWeapon : MonoBehaviour 
{
    public SO_WeaponPreset weaponData;

    public AudioClip onPickupSFX;
    public AudioClip collisionSoftSFX;
    public AudioClip collisionMediumSFX;

    CharacterCustomization _character;
    AudioSource _auSource;

    CollisionEvents _collisionEvents;

    private void Awake()
    {
        _collisionEvents = GetComponent<CollisionEvents>();
    }
    private void Start()
    {
        _auSource = gameObject.AddComponent<AudioSource>();
        _auSource.spatialBlend = 1;
    }

    private void OnDrawGizmos()
    {
        Vector3 shootPoint = transform.position + transform.TransformDirection(weaponData.shootPoint);

        Gizmos.color = Color.red * new Color(1, 1, 1, 0.5f);
        Gizmos.DrawSphere(shootPoint, 0.025f);
        Handles.Label(shootPoint, "Shoot source");

        Gizmos.color = Color.green * new Color(1, 1, 1, 0.5f);
        Gizmos.DrawSphere(transform.position, 0.025f);
        Handles.Label(transform.position, "Right Hand Position (origin)");
    }
    void OnCollideSoft(object sender, CollisionEvents.CollisionArgs args)
    {
        _auSource.PlayOneShot(collisionSoftSFX);
    }
    void OnCollideMedium(object sender, CollisionEvents.CollisionArgs args)
    {
        _auSource.PlayOneShot(collisionMediumSFX);
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
        if (_character.EquipmentController.HasWeapon(weapon.weaponType))
        {
            AlreadyEquippedAlert(weapon);
            return;
        }

        _character.EquipmentController.EquipWeapon(weapon);
        OnPickup();
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
    void OnPickup()
    {
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

        _character.PlaySFX(onPickupSFX);
        Destroy(gameObject);
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
