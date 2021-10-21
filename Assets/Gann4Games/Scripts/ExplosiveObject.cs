using UnityEngine;
using Gann4Games.Thirdym.Core;
using Gann4Games.Thirdym.Events;

[RequireComponent(typeof(BreakableObject))]
[RequireComponent(typeof(ExplosionHandler))]
public class ExplosiveObject : MonoBehaviour
{
    [Tooltip("The object that will be replaced by the broken model. Usually is the object the script is attached to.")]
    public GameObject defaultObject;

    BreakableObject _breakableObject;
    ExplosionHandler _explosionHandler;
    private void Awake()
    {
        _explosionHandler = GetComponent<ExplosionHandler>();

        _breakableObject = GetComponent<BreakableObject>();
        _breakableObject.health = _explosionHandler.explosiveData.health;

    }
    private void OnEnable() => _breakableObject.OnDeath += StartExplosion;
    private void OnDisable() => _breakableObject.OnDeath -= StartExplosion;
    public void StartExplosion(object sender, BreakableObject.BreakableObjectArgs args)
    {
        _explosionHandler.Explode();
        
        defaultObject.SetActive(false);

        Instantiate(args.brokenModel, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
