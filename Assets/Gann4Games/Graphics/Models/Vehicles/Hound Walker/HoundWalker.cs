using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoundWalker : MonoBehaviour {
    
    public Animator anim;
    public float jointForce = 100000;
    [HideInInspector] public ConfigurableJoint body;
    HingeJoint[] limbs;

    private void Start()
    {
        limbs = GetComponentsInChildren<HingeJoint>();
        body = GetComponentInChildren<ConfigurableJoint>();
    }
    private void Update()
    {
        foreach (HingeJoint hj in limbs)
        {
            JointSpring limbSpring = hj.spring;
            limbSpring.spring = jointForce;
            hj.spring = limbSpring;
        }
    }
}
