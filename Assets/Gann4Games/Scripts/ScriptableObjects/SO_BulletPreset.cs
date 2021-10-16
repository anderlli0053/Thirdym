using UnityEngine;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Bullet Preset", menuName = "Scriptable Objects/Bullet Preset")]
    public class SO_BulletPreset : ScriptableObject
    {
        [Header("Spawn parameters")]
        public GameObject bullet;
        public GameObject solidImpact;

        [Header("Visual parameters")]
        public Color bulletColor = Color.white;
        public Material bulletMaterial;
        public LineTextureMode texMode;
        [Space]
        public float bulletWidth = 0.25f;
        public float bulletLenght = 0.1f;
    }
}