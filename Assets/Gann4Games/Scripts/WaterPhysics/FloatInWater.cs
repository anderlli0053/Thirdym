using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatInWater : MonoBehaviour {

    Rigidbody _rigidbody;
    LiquidObject _waterObject;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (_waterObject)
        {
            Vector3 force = _waterObject.buoyancyDirection * Time.deltaTime * 100;

            _rigidbody.AddForce(force, ForceMode.Force);
            _rigidbody.drag = _waterObject.liquidDrag;
            _rigidbody.useGravity = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Water")
            _waterObject = other.GetComponent<LiquidObject>();
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            _rigidbody.useGravity = true;
            _rigidbody.drag = 0;
            _waterObject = null;
        }
    }
}
