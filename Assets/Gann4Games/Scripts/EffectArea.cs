using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovePhysics
{
    public List<Rigidbody> Rigidbodies;
    public Vector3 direction;
}
[RequireComponent(typeof(BoxCollider))]
public class EffectArea : MonoBehaviour {

    public MovePhysics PhysicsParams;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(transform.position, transform.position + (PhysicsParams.direction / 100));
    }
    private void Update()
    {
        if(PhysicsParams.Rigidbodies.Count != 0)
        {
            foreach (Rigidbody rb in PhysicsParams.Rigidbodies)
                rb.AddForce(PhysicsParams.direction);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            PhysicsParams.Rigidbodies.Add(rb);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            PhysicsParams.Rigidbodies.Remove(rb);
        }
    }
}
