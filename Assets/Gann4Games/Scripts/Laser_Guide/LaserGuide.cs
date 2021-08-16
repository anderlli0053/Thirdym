using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGuide : MonoBehaviour {

    LineRenderer LR;
    public Transform hitPoint;
    Vector3 LinePos;
    public float rayLenght;
    void Start() {
        LR = GetComponent<LineRenderer>();
    }
    void Update()
    {
        RaycastHit hit;
        rayLenght = Vector3.Distance(transform.position, hitPoint.position);
        LinePos.z = rayLenght;
        if(LR != null)
            LR.SetPosition(1, LinePos);
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            hitPoint.position = hit.point;
            hitPoint.gameObject.active = true;
        }else
            hitPoint.gameObject.active = false;
    }
}
