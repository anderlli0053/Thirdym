using System.Collections.Generic;
using UnityEngine;
using Gann4Games.Thirdym.Events;

[RequireComponent(typeof(BreakableObject))]
[RequireComponent(typeof(CollisionEvents))]
[RequireComponent(typeof(AudioSource))]
public class LootCrate : MonoBehaviour {
    [System.Serializable]
    public class ObjectToSpawn
    {
        public GameObject item;
        public int count = 1;
    }

    [Header("Sound effects")]
    [SerializeField] AudioClip sfxCollideHard, sfxCollideMedium, sfxCollideSoft;

    [Header("Object spawning")]
    [SerializeField] List<ObjectToSpawn> lootContent;

    Rigidbody[] _rigidbodies;
    AudioSource _audio;
    CollisionEvents _colliderEvents;
    BreakableObject _breakableObject;
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _colliderEvents = GetComponent<CollisionEvents>();
        _breakableObject = GetComponent<BreakableObject>();

        _colliderEvents.OnCollideHard += CollideHard;
        _colliderEvents.OnCollideMedium += CollideMedium;
        _colliderEvents.OnCollideSoft += CollideSoft;
        _breakableObject.OnDeath += BreakCrate;
    }
    private void Start()
    {
        for (int index = 0; index < lootContent.Count; index++)
        {
            for (int count = 0; count < lootContent[index].count; count++)
            {
                _rigidbodies = lootContent[index].item.GetComponentsInChildren<Rigidbody>();
                for (int rbodies = 0; rbodies < _rigidbodies.Length; rbodies++)
                    GetComponent<Rigidbody>().mass += _rigidbodies[rbodies].mass;
            }
        }
    }
    private void OnDestroy()
    {
        _colliderEvents.OnCollideHard -= CollideHard;
        _colliderEvents.OnCollideMedium -= CollideMedium;
        _colliderEvents.OnCollideSoft -= CollideSoft;
        _breakableObject.OnDeath -= BreakCrate;
    }
    void CollideHard(object sender, CollisionEvents.CollisionArgs args) => _audio.PlayOneShot(sfxCollideHard);
    void CollideMedium(object sender, CollisionEvents.CollisionArgs args) => _audio.PlayOneShot(sfxCollideMedium);
    void CollideSoft(object sender, CollisionEvents.CollisionArgs args) => _audio.PlayOneShot(sfxCollideSoft);
    public void BreakCrate(object sender, BreakableObject.BreakableObjectArgs args)
    {
        Instantiate(args.brokenModel, transform.position, transform.rotation);
        for (int i = 0; i < lootContent.Count; i++)
        {
            if (lootContent[i].item == null) continue;

            for (int amount = 0; amount < lootContent[i].count; amount++)
                Instantiate(lootContent[i].item, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }
}
