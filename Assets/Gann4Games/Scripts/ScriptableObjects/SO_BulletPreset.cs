using UnityEngine;
using UnityEngine.Serialization;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Bullet Preset", menuName = "Scriptable Objects/Bullet Preset")]
    public class SO_BulletPreset : ScriptableObject
    {
        [Header("Spawn parameters")]
        public GameObject bullet;
        public GameObject onHitPrefab;

        [Header("Visual parameters")]
        public Color bulletColor = Color.white;
        public Material bulletMaterial;
        [FormerlySerializedAs("texMode")] public LineTextureMode textureMode;
        [Space]
        public float bulletWidth = 0.25f;
        public float bulletLenght = 0.1f;
    }
}