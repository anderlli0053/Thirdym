using UnityEngine;
using Gann4Games.Thirdym.Enums;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New weapon preset", menuName = "Scriptable Objects/Weapon Preset")]
    public class SO_WeaponPreset : ScriptableObject
    {
        // FIND ALL OF THESE PARAMETERS IN 'SO_Bullet Preset' AND REMOVE THEM

        [Header("Visuals")]
        [Tooltip("The model that will be placed in the left hand.")]
        public GameObject leftWeaponModel;
        [Tooltip("The model that will be placed in the right hand.")]
        public GameObject rightWeaponModel;
        [Tooltip("Spring to be assigned in the left hand, for extra weapon support, and also visuals.")]
        public float leftHandSpring = 12000;
        [Tooltip("Position in which the hand will be placed relative to the gun")]
        public Vector3 leftHandAnchor;
        [Space]
        public bool leftShoulderSpring;
        public bool leftElbowSpring;
        public bool rightShoulderSpring = true;
        public bool rightElbowSpring = true;


        [Header("Stats")]
        public WeaponCategory weaponType;
        public float damage;
        [Header("Configuration")]
        public bool ricochet;
        public float ricochetMinAngle = .75f;
        public float repeatTime;
        [Space]
        public float bulletSpread;
        public float bulletCount;

        [Header("Effects")]
        public SO_BulletPreset bulletType;
        [Space]
        public GameObject muzzleFlash;
        public float muzzleFlashDisableTime;

        [Header("Sound Effects")]
        public AudioClip sfxShoot;
        public AudioClip sfxReload;
    }
}
