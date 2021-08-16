using UnityEngine;
using Gann4Games.Thirdym.ScriptableObjects;
using Gann4Games.Thirdym.Interfaces;

public class Bullet : MonoBehaviour {
    [HideInInspector] public Transform user; //Automatically set by actionShoot.cs

    public SO_BulletPreset preset;

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

        _trailRenderer.startColor = preset.bulletColor;
        _trailRenderer.endColor = preset.bulletColor;
        _trailRenderer.startWidth = preset.bulletWidth;
        _trailRenderer.endWidth = preset.bulletWidth;
        _trailRenderer.time = preset.bulletLenght;
        _trailRenderer.material = preset.bulletMaterial;
        _trailRenderer.textureMode = preset.texMode;

        FireBullet(transform.forward);
        Destroy(gameObject, 3);
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
        Ricochet();

        var damageableObject = other.gameObject.GetComponent<IDamageable>();
        damageableObject?.DealDamage(preset.damage, DamageType.Bullet, user.position);

        CharacterBodypart bodypart = other.gameObject.GetComponent<CharacterBodypart>();
        if(bodypart) Destroy(gameObject);

        HingeJointTarget ragdollJoint = other.gameObject.GetComponent<HingeJointTarget>();
        if (ragdollJoint)
        {
            if (ragdollJoint.CanBeDismembered) 
                ragdollJoint.hj.breakForce -= 100 * preset.damage;
        }

        Rigidbody otherRigidbody = other.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody)
        {
            if (other.transform.gameObject.HasTag("Breakable"))
                other.transform.GetComponent<Rigidbody>().isKinematic = false;
            other.transform.GetComponent<Rigidbody>().AddForce(transform.forward * (50 * preset.damage));
        }
        else
            CreateParticle(preset.solidImpact, transform.position, transform.rotation, null);

        if (other.transform.gameObject.HasTag("Energy"))
        {
            CreateParticle(energyImpact, transform.position, transform.rotation, other.transform);
        }
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
            if(ricochetAngle > preset.ricochetMinAngle)
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
        renderer.material.SetColor("_Color", preset.bulletColor);

        newBulletHole.transform.localScale = Vector3.one*(preset.bulletWidth/2);
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
