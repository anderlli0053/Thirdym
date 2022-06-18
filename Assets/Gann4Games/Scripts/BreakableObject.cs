using UnityEngine;
using UnityEngine.Events;
using Gann4Games.Thirdym.Interfaces;

namespace Gann4Games.Thirdym.Events
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        [Tooltip("The object that will be enabled on death.")]
        [SerializeField] GameObject brokenEffect;

        [Tooltip("The object that will be disabled on death.")]
        [SerializeField] GameObject defaultObject;

        [Tooltip("Use zero or less to define an unbreakable object.")]
        public float startHealth = 100;
        [Space]
        public UnityEvent onDeath;

        bool _unbreakable => startHealth <= 0;
        float _currentHealth;

        public float Health => _currentHealth;

        private void Start() => Initialize();

        public virtual void Initialize()
        {
            _currentHealth = startHealth;
        }

        public void DealDamage(float damage, DamageType damageType, Vector3 where) {
            if (_unbreakable) return;

            _currentHealth -= damage;
            if (_currentHealth <= 0)
                OnDeath();
        }

        public virtual void OnDeath() {
            onDeath.Invoke();
            brokenEffect.SetActive(true);
            defaultObject.SetActive(false);
        }
    }
}
