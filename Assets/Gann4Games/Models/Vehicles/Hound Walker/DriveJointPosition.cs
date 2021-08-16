using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveJointPosition : MonoBehaviour {

	public static Quaternion ToQuaternion(Transform obj)
    {
        return new Quaternion(-obj.rotation.x, -obj.rotation.y, -obj.rotation.z, obj.rotation.w);
    }
}
