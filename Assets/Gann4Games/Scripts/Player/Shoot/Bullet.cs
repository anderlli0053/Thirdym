using UnityEngine;
using Gann4Games.Thirdym.ScriptableObjects;
using Gann4Games.Thirdym.Interfaces;

public class Bullet : MonoBehaviour {
    [HideInInspector] public Transform user; //Automatically set by actionShoot.cs

    public SO_WeaponPreset weapon;

    [SerializeField] GameObject energyImpact;
    [SerializeField] GameObject bulletHole;
    [SerializeField] float bulletSpeed = 10;

    Rigidbody _rigidbody;
    TrailRenderer _trailRenderer;
    Vector3 _fireDirection;
    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _rigidbody = GetComponent<Rigidbody>();

        ApplyVisuals();

        FireBullet(transform.right);
        Destroy(gameObject, 3);
    }
    void ApplyVisuals()
    {
        _trailRenderer.startColor = weapon.bulletType.bulletColor;
        _trailRenderer.endColor = weapon.bulletType.bulletColor;
        _trailRenderer.startWidth = weapon.bulletType.bulletWidth;
        _trailRenderer.endWidth = weapon.bulletType.bulletWidth;
        _trailRenderer.time = weapon.bulletType.bulletLenght;
        _trailRenderer.material = weapon.bulletType.bulletMaterial;
        _trailRenderer.textureMode = weapon.bulletType.texMode;
    }

    private void FireBullet(Vector3 direction)
    {
        _fireDirection = direction;
        direction.Normalize();
        transform.LookAt(transform.position + direction);
        _rigidbody.velocity = direction * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        var damageableObject = other.gameObject.GetComponent<IDamageable>();
        damageableObject?.DealDamage(weapon.damage, DamageType.Bullet, user.position);

        CharacterBodypart bodypart = other.gameObject.GetComponent<CharacterBodypart>();
        if(bodypart) Destroy(gameObject);

        HingeJointTarget ragdollJoint = other.gameObject.GetComponent<HingeJointTarget>();
        if (ragdollJoint)
        {
            if (ragdollJoint.CanBeDismembered) 
                ragdollJoint.hj.breakForce -= 100 * weapon.damage;
        }

        Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody)
        {
            if (other.transform.gameObject.HasTag("Breakable"))
                other.transform.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * (50 * weapon.damage));
        }
        else
            CreateParticle(weapon.bulletType.solidImpact, transform.position, transform.rotation, null);

        if (other.transform.gameObject.HasTag("Energy"))
        {
            CreateParticle(energyImpact, transform.position, transform.rotation, other.transform);
        }

        // Ricochet
        if (weapon.useRicochet) Ricochet();
        else Destroy(gameObject);
    }
    void Ricochet()
    {
        Vector3 incomingDirection = _fireDirection.normalized;
        float ricochetAngle = 0;
        if(Physics.Raycast(transform.position, incomingDirection, out RaycastHit hit))
        {
            //if(hit.transform.CompareTag("Map")) BulletHole(hit.point, hit.normal);
            
            Vector3 bounceDirection = Vector3.Reflect(incomingDirection, hit.normal).normalized;
            ricochetAngle = Vector3.Dot(incomingDirection, bounceDirection);
            if(ricochetAngle > weapon.ricochetMinAngle)
            {
                FireBullet(bounceDirection);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
    void BulletHole(Vector3 where, Vector3 surfaceNormal, float normalOffset = 0.01f)
    {
        GameObject newBulletHole = Instantiate(bulletHole, where+surfaceNormal*normalOffset, Quaternion.LookRotation(-surfaceNormal));
        MeshRenderer renderer = newBulletHole.GetComponent<MeshRenderer>();
        renderer.material.SetColor("_Color", weapon.bulletType.bulletColor);

        newBulletHole.transform.localScale = Vector3.one*(weapon.bulletType.bulletWidth/2);
    }
    public void CreateParticle(GameObject prefab, Vector3 startPos, Quaternion startRot, Transform parent)
    {
        GameObject particle = Instantiate(prefab, startPos, startRot, null);
        particle.transform.SetParent(parent);
        particle.GetComponent<ParticleSystem>().Play();
    }
    public void Deflect()
    {
        FireBullet(-_rigidbody.velocity);
    }
}
