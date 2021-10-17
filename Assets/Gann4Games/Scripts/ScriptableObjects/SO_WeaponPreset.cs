using UnityEngine;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New weapon preset", menuName = "Scriptable Objects/Weapon Preset")]
    public class SO_WeaponPreset : ScriptableObject
    {
        // FIND ALL OF THESE PARAMETERS IN 'SO_Bullet Preset' AND REMOVE THEM

        [Header("Visuals")]
        [Tooltip("The object that the player will drop.")]
        public GameObject dropPrefab;
        public AnimatorOverrideController animationOverride;
        [Space]
        [Tooltip("The model that will be placed in the left hand.")]
        public GameObject leftWeaponModel;
        public Vector3 leftPositionOffset;
        public Vector3 leftRotationOffset;
        [Space]
        [Tooltip("The model that will be placed in the right hand.")]
        public GameObject rightWeaponModel;
        public Vector3 rightPositionOffset;
        public Vector3 rightRotationOffset;
        [Space]
        public bool leftShoulderSpring = true;
        public bool leftElbowSpring = true;
        public bool rightShoulderSpring = true;
        public bool rightElbowSpring = true;


        [Header("Stats")]
        public WeaponType weaponType;
        public float damage;
        [Header("Configuration")]
        public string weaponName = "unnamed_weapon";
        public bool useRicochet = true;
        public float ricochetMinAngle = .75f;
        public Vector3 shootPoint;
        [Space]
        [Tooltip("Bullet spawning in seconds.")]
        public float repeatTime = 1;
        public float bulletCount = 1;
        public float bulletSpread;
        [Space]
        public bool useReload;
        public float reloadStartDelay;
        public float reloadDuration;

        [Header("Effects")]
        public SO_BulletPreset bulletType;
        [Space]
        public GameObject muzzleFlash;
        public float muzzleFlashDisableTime = 0.05f;

        [Header("Sound Effects")]
        public AudioClip sfxShoot;
        public AudioClip sfxReload;
    }
}
