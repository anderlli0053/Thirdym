using UnityEngine;
using Gann4Games.Thirdym.Events;

namespace Gann4Games.Thirdym.PhysicsTools
{
    [RequireComponent(typeof(CollisionEvents))]
    public class CollisionSoundEffects : MonoBehaviour
    {
        AudioSource _audioSource;

        [SerializeField] CollisionEvents collisionHandler;

        [SerializeField] AudioClip collisionSoftSFX;
        [SerializeField] AudioClip collisionMediumSFX;
        [SerializeField] AudioClip collisionHardSFX;

        private void Awake() => _audioSource = GetComponent<AudioSource>();
        private void OnEnable()
        {
            collisionHandler.OnCollideSoft += OnCollideSoft;
            collisionHandler.OnCollideMedium += OnCollideMedium;
            collisionHandler.OnCollideHard += OnCollideHard;
        }
        private void OnDisable()
        {
            collisionHandler.OnCollideSoft -= OnCollideSoft;
            collisionHandler.OnCollideMedium -= OnCollideMedium;
            collisionHandler.OnCollideHard -= OnCollideHard;
        }

        void OnCollideSoft(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionSoftSFX);
        void OnCollideMedium(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionMediumSFX);
        void OnCollideHard(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionHardSFX);
    }
}
