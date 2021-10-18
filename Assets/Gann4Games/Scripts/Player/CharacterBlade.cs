using UnityEngine;
using Gann4Games.Thirdym.Interfaces;
using Gann4Games.Thirdym.Events;
public class CharacterBlade : MonoBehaviour {

    public CharacterCustomization character;
    public GameObject impactPrefab;

    [SerializeField] MeshRenderer blade_renderer;

    float _bladeDamage;
    private void Start()
    {
        blade_renderer.material.SetColor("_MainColor", character.preset.bladesColor);
        _bladeDamage = character.preset.bladeDamage;
    }
    private void OnTriggerEnter(Collider other)
    {
        var damageableObject = other.GetComponent<IDamageable>();
        CharacterBodypart otherBodypart = other.GetComponent<CharacterBodypart>();
        BreakableObject otherBreakable = other.GetComponent<BreakableObject>();
        HingeJointTarget otherJoint = other.GetComponent<HingeJointTarget>();
        Bullet otherBullet = other.GetComponent<Bullet>();
        Rigidbody otherRigidbody = other.GetComponent<Rigidbody>();

        bool canBeDamaged = otherBodypart?.character != character;

        if (canBeDamaged || !otherBodypart)
            damageableObject?.DealDamage(_bladeDamage, DamageType.Blade, character.transform.position);

        if (otherBreakable)
            character.preset.IndicateDamage(transform.position).Display(_bladeDamage.ToString("F0"), Color.white);
        else
            spawnParticle(impactPrefab, transform.position);

        if (otherJoint)
        {
            if (otherJoint.CanBeDismembered)
                otherJoint.hj.breakForce -= otherJoint.hj.breakForce * 1 / 4;
        }

        if(otherBullet)
        {
            Rigidbody otherBulletRigidbody = otherBullet.GetComponent<Rigidbody>();
            otherBulletRigidbody.velocity = -otherBulletRigidbody.velocity;
            character.preset.IndicateDamage(transform.position).Display("Deflect", Color.white);
        }

        if (otherRigidbody && !otherBullet)
            otherRigidbody.AddForce(character.transform.forward * 10000 * Time.deltaTime);
    }
    void spawnParticle(GameObject particle, Vector3 pos)
    {
        GameObject prefab = Instantiate(particle);
        prefab.transform.position = pos;
    }
}
