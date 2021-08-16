using UnityEngine;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Bullet Preset", menuName = "Scriptable Objects/Bullet Preset")]
    public class SO_BulletPreset : ScriptableObject
    {
        [Header("Main configuration")]
        public bool usesRicochet = true;
        [Tooltip("Value based on dot product.")] public float ricochetMinAngle = .5f;
        public LineTextureMode texMode;
        public PumpGunOptions PumpOptions;
        public GameObject bullet;
        public float bulletSpread = 0;
        public float bulletWidth = 0.25f;
        public float bulletLenght = 0.1f;
        public float damage = 20;
        public float repeatTime = 1;
        public float muzzleDisableTime = 0.05f;
        public int bulletCount = 1;

        [Header("Effects")]
        public GameObject muzzleFlash;
        public Material bulletMaterial;
        public Color bulletColor = Color.white;

        [Header("Sound effects")]
        public AudioClip sfxShoot;
        public AudioClip sfxPump;

        [Header("Hit Effects")]
        public GameObject solidImpact;
    }
}