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

    [Header("Object spawning")]
    [SerializeField] List<ObjectToSpawn> lootContent;

    Rigidbody[] _rigidbodies;
    BreakableObject _breakableObject;
    private void Awake()
    {
        _breakableObject = GetComponent<BreakableObject>();
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
    private void OnEnable()
    {
        _breakableObject.OnDeath += BreakCrate;
    }
    private void OnDisable()
    {
        _breakableObject.OnDeath -= BreakCrate;
    }
    public void BreakCrate(object sender, BreakableObject.BreakableObjectArgs args)
    {
        Instantiate(args.brokenModel, transform.position, transform.rotation);
        SpawnLoot();
        Destroy(gameObject);
    }
    void SpawnLoot()
    {
        for (int i = 0; i < lootContent.Count; i++)
        {
            if (lootContent[i].item == null) continue;

            for (int amount = 0; amount < lootContent[i].count; amount++)
                Instantiate(lootContent[i].item, transform.position, transform.rotation);
        }
    }
}
