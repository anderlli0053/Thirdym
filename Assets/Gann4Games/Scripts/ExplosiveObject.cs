using UnityEngine;
using UnityEditor;
using Gann4Games.Thirdym.ScriptableObjects;
using Gann4Games.Thirdym.Utility;

[RequireComponent(typeof(BreakableObject))]
public class ExplosiveObject : MonoBehaviour
{
    public SO_ExplosionPreset preset;

    [Tooltip("The object that will be replaced by the broken model. Usually is the object the script is attached to.")]
    public GameObject defaultObject;

    BreakableObject _breakableObject;
    private void Awake()
    {
        _breakableObject = GetComponent<BreakableObject>();
        _breakableObject.health = preset.health;
        _breakableObject.OnDeath += StartExplosion;
    }
    private void OnDestroy() => _breakableObject.OnDeath -= StartExplosion;
    public void StartExplosion(object sender, BreakableObject.BreakableObjectArgs args)
    {
        Instantiate(args.brokenModel, transform.position, transform.rotation);
        defaultObject.SetActive(false);

        Explode();
    }
    public void Explode()
    {
        Vector3 explosionCenter = transform.position + preset.explosionOriginOffset;
        Collider[] colliders = PhysicsTools.GetCollidersAt(explosionCenter, preset.explosionRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody otherRigidbody = hit.GetComponent<Rigidbody>();
            CharacterBodypart otherBodypart = hit.GetComponent<CharacterBodypart>();

            if (otherRigidbody == null) continue;

            float distance = Vector3.Distance(otherRigidbody.transform.position, transform.position);
            float explosionForce = ((preset.explosionDamage * preset.explosionForce * Time.deltaTime) / distance) / Time.timeScale;
            otherRigidbody.AddExplosionForce(explosionForce, explosionCenter, preset.explosionRadius, 0, ForceMode.Impulse);

            if (distance > preset.explosionRadius) return;

            if (otherBodypart)
            {
                otherBodypart.character.HealthController.DealDamage(preset.explosionDamage / distance, Vector3.zero);

                GameObject blood = otherBodypart.character.preset.BloodSplatFX();
                blood.transform.position = hit.transform.position;
            }
        }
        Destroy(gameObject);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        float intensity = preset.explosionDamage / preset.explosionRadius;
        Gizmos.color = new Color(intensity, 0, 0);
        Gizmos.DrawWireSphere(transform.position + preset.explosionOriginOffset, preset.explosionRadius);

        Handles.Label(transform.position, $"Intensity: {preset.explosionForce}");
    }

#endif
}
