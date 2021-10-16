using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class SmartTurret : MonoBehaviour {

    public enum TurretStatus
    {
        Searching,
        Identifying,
        Attacking,
    }

    ShootSystem shootSystem;
    CharacterShootHandler shootScript;
    public TurretStatus Status;
    public ConfigurableJoint horizontalJoint, verticalJoint;
    RagdollController[] ragdolls;

    Vector3 GetClosestRagdollPos()
    {
        float smallestDistance = Mathf.Infinity;
        Vector3 smallest = Vector3.zero;
        for (int i = 0; i < ragdolls.Length; i++)
        {
            if (ragdolls[i] == null)
                continue;
            float dist = Vector3.Distance(shootScript.transform.position, ragdolls[i].transform.position);
            if (dist < smallestDistance)
            {
                smallestDistance = dist;
                smallest = ragdolls[i].transform.position;
            }
        }
        return smallest;
    }
    Vector3 DirectionToClosest()
    {
        return GetClosestRagdollPos() - shootScript.transform.position;
    }
    Quaternion JLookAtClosest()
    {
        Quaternion lookDir = Quaternion.LookRotation(DirectionToClosest());
        return new Quaternion(lookDir.x, -lookDir.y, lookDir.z, -lookDir.w);
    }
    Quaternion JLookAtRaycast(RaycastHit hit, bool invert = false)
    {
        Quaternion lookDir = Quaternion.LookRotation(hit.point - shootScript.transform.position);
        if (invert)
            lookDir = Quaternion.LookRotation(shootScript.transform.position - hit.point);
        return new Quaternion(lookDir.x, lookDir.y, lookDir.z, -lookDir.w);
    }
    private void Start()
    {
        ragdolls = FindObjectsOfType<RagdollController>();
        shootSystem = GetComponent<ShootSystem>();
        shootScript = GetComponentInChildren<CharacterShootHandler>();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(shootScript.transform.position, DirectionToClosest(), out hit))
        {
            horizontalJoint.targetRotation = JLookAtRaycast(hit);
            verticalJoint.targetRotation = JLookAtRaycast(hit);
            if (hit.transform.GetComponent<CharacterBodypart>())
                shootSystem.Shoot();
            Debug.DrawLine(shootScript.transform.position, hit.point);
        }
    }
}
