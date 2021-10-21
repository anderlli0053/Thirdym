using UnityEngine;
using Gann4Games.Thirdym.Interfaces;
using Gann4Games.Thirdym.Events;

[RequireComponent(typeof(ExplosiveObject))]
[RequireComponent(typeof(CollisionEvents))]
public class ExplosiveBarrel : MonoBehaviour
{
    CollisionEvents _collisionEvents;
    BreakableObject _breakableObject;

    private void Awake()
    {
        _breakableObject = GetComponent<BreakableObject>();
        _collisionEvents = GetComponent<CollisionEvents>();

        _collisionEvents.OnCollideHard += CollideHard;
        _collisionEvents.OnCollideMedium += CollideMedium;
        _collisionEvents.OnCollideSoft += CollideSoft;
    }
    private void OnDestroy()
    {
        _collisionEvents.OnCollideHard -= CollideHard;
        _collisionEvents.OnCollideMedium -= CollideMedium;
        _collisionEvents.OnCollideSoft -= CollideSoft;
    }
    void CollideHard(object sender, CollisionEvents.CollisionArgs args)
    {
        _breakableObject.DealDamage(25, DamageType.Collision, Vector3.zero);
    }
    void CollideMedium(object sender, CollisionEvents.CollisionArgs args)
    {
        _breakableObject.DealDamage(10, DamageType.Collision, Vector3.zero);
    }
    void CollideSoft(object sender, CollisionEvents.CollisionArgs args)
    {
        _breakableObject.DealDamage(1, DamageType.Collision, Vector3.zero);
    }
}
