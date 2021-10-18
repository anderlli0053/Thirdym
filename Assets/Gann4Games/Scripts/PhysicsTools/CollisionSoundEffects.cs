using UnityEngine;
using Gann4Games.Thirdym.Events;

namespace Gann4Games.Thirdym.PhysicsTools
{
    [RequireComponent(typeof(CollisionEvents))]
    public class CollisionSoundEffects : MonoBehaviour
    {
        AudioSource _audioSource;
        CollisionEvents _collisionHandler;

        [SerializeField] AudioClip collisionSoftSFX;
        [SerializeField] AudioClip collisionMediumSFX;
        [SerializeField] AudioClip collisionHardSFX;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _collisionHandler = GetComponent<CollisionEvents>();
        }
        private void OnEnable()
        {
            _collisionHandler.OnCollideSoft += OnCollideSoft;
            _collisionHandler.OnCollideMedium += OnCollideMedium;
            _collisionHandler.OnCollideHard += OnCollideHard;
        }
        private void OnDisable()
        {
            _collisionHandler.OnCollideSoft -= OnCollideSoft;
            _collisionHandler.OnCollideMedium -= OnCollideMedium;
            _collisionHandler.OnCollideHard -= OnCollideHard;
        }

        void OnCollideSoft(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionSoftSFX);
        void OnCollideMedium(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionMediumSFX);
        void OnCollideHard(object sender, CollisionEvents.CollisionArgs args) => _audioSource.PlayOneShot(collisionHardSFX);
    }
}
