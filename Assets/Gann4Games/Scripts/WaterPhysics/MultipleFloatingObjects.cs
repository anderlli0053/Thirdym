using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleFloatingObjects : MonoBehaviour {
    public FloatInWater[] loaded_scripts;


    private void Start()
    {
        Rigidbody[] rbs = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in rbs)
        {
            Collider rbcol = rb.GetComponent<Collider>();
            if (!rbcol) continue;
            if (!rb.isKinematic && !rbcol.isTrigger && rb.useGravity)
                rb.gameObject.AddComponent<FloatInWater>();
        }
        
        loaded_scripts = GetComponentsInChildren<FloatInWater>();
    }
}
