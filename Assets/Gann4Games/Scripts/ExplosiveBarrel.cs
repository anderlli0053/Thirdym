using UnityEngine;
using Gann4Games.Thirdym.Interfaces;
using Gann4Games.Thirdym.Events;

[RequireComponent(typeof(CollisionEvents))]
[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(ExplosiveObject))]
public class ExplosiveBarrel : MonoBehaviour
{
    [Header("Sound effects")]
    [SerializeField] AudioClip sfxCollideHard;
    [SerializeField] AudioClip sfxCollideMedium; 
    [SerializeField] AudioClip sfxCollideSoft;

    CollisionEvents _collisionEvents;
    BreakableObject _breakableObject;
    AudioSource _soundSource;

    private void Awake()
    {
        _soundSource = GetComponent<AudioSource>();
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
        _soundSource.PlayOneShot(sfxCollideHard);
    }
    void CollideMedium(object sender, CollisionEvents.CollisionArgs args)
    {
        _breakableObject.DealDamage(10, DamageType.Collision, Vector3.zero);
        _soundSource.PlayOneShot(sfxCollideMedium);
    }
    void CollideSoft(object sender, CollisionEvents.CollisionArgs args)
    {
        _breakableObject.DealDamage(1, DamageType.Collision, Vector3.zero);
        _soundSource.PlayOneShot(sfxCollideSoft);
    }
}
