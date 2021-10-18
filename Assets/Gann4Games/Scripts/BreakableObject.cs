using UnityEngine;
using System;
using Gann4Games.Thirdym.Interfaces;

namespace Gann4Games.Thirdym.Events
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {

        public event EventHandler<BreakableObjectArgs> OnDeath;
        public class BreakableObjectArgs
        {
            public GameObject brokenModel;
        }

        [SerializeField] GameObject brokenEffect;

        [Tooltip("Assign it to a value lower than zero to enable immortal mode.")]
        public float health;

        bool immortal;

        private void Start()
        {
            if(health <= 0)
            {
                immortal = true;
            }
        }
        public void DealDamage(float damage, DamageType damageType, Vector3 where) {
            if (immortal) return;

            health -= damage;
            if (health <= 0)
                OnDeath.Invoke(this, new BreakableObjectArgs() { brokenModel = brokenEffect });
        }
    }
}
