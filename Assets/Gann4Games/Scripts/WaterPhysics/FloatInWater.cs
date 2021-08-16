using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInWater : MonoBehaviour {

    Rigidbody rb;
    LiquidObject water_object;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (water_object)
        {
            rb.useGravity = false;
            rb.drag = water_object.liquidDrag;
            rb.AddForce(water_object.buoyancyDirection*Time.deltaTime*100, ForceMode.Force);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
            water_object = other.GetComponent<LiquidObject>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            rb.useGravity = true;
            rb.drag = 0;
            water_object = null;
        }
    }
}
