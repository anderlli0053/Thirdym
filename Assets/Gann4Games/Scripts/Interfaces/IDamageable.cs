using UnityEngine;

namespace Gann4Games.Thirdym.Interfaces
{
    public enum DamageType
    {
        Bullet,
        Blade,
        Acid,
        Collision
    }
    public interface IDamageable
    {
        void DealDamage(float damage, DamageType damageType, Vector3 where);
    }
}
