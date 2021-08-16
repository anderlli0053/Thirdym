using UnityEngine;
using System;
using Gann4Games.Thirdym.Interfaces;

public class BreakableObject : MonoBehaviour, IDamageable
{

    public event EventHandler<BreakableObjectArgs> OnDeath;
    public class BreakableObjectArgs
    {
        public GameObject brokenModel;
    }

    [SerializeField] GameObject brokenEffect;

    public float health;

    public void DealDamage(float damage, DamageType damageType, Vector3 where) { 
        health -= damage;
        if (health <= 0)
            OnDeath.Invoke(this, new BreakableObjectArgs() { brokenModel = brokenEffect });
    }
}
