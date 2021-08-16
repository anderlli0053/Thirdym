using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultipleAxisHingeJoint : MonoBehaviour {
    public Rigidbody connectedBody;
    HingeJoint HingeX, HingeY, HingeZ;
    void Start () {
        Vector3 X = new Vector3(1, 0, 0);
        Vector3 Y = new Vector3(0, 1, 0);
        Vector3 Z = new Vector3(0, 0, 1);
        HingeX = new GameObject("HingeXAxis").AddComponent<HingeJoint>();
        HingeX.axis = X;
        HingeY = new GameObject("HingeYAxis").AddComponent<HingeJoint>();
        HingeY.axis = Y;
        HingeZ = connectedBody.gameObject.AddComponent<HingeJoint>();
        HingeZ.axis = Z;

        HingeX.transform.position = connectedBody.transform.position + HingeZ.anchor;
        HingeY.transform.position = connectedBody.transform.position + HingeZ.anchor;

        HingeY.connectedBody = HingeX.GetComponent<Rigidbody>();
        HingeZ.connectedBody = HingeY.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
