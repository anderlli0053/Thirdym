using UnityEngine;

namespace Gann4Games.Thirdym.ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Explosion Preset", menuName = "Scriptable Objects/Explosion Preset")]
    public class SO_ExplosionPreset : ScriptableObject
    {
        public float health = 100;
        public float explosionRadius = 10;
        public float explosionDamage = 250;
        public float explosionForce = 200;
        public Vector3 explosionOriginOffset;
        public GameObject brokenObject;
    }
}