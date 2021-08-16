using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioLowPassFilter))]
public class UnderwaterFX : MonoBehaviour {

    public float Radius = 0.5f;
    AudioLowPassFilter lowpassFilter;
    Rigidbody rb;

    private void Start()
    {
        gameObject.AddComponent<SphereCollider>().radius = Radius;
        GetComponent<SphereCollider>().isTrigger = true;
        lowpassFilter = GetComponent<AudioLowPassFilter>();

        rb = gameObject.AddComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position, Radius);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water" && other.GetComponent<LiquidObject>().blocksSound)
            lowpassFilter.enabled = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Water" && other.GetComponent<LiquidObject>().blocksSound)
            lowpassFilter.enabled = false;
    }
}
