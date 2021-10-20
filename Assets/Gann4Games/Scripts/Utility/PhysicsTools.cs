using UnityEngine;

namespace Gann4Games.Thirdym.Utility
{
    public abstract class PhysicsTools
    {
        public static JointSpring SetHingeJointSpring(JointSpring joint, float value)
        {
            JointSpring newSpring = joint;
            newSpring.spring = value;
            return newSpring;
        }
        public static Collider[] GetCollidersAt(Vector3 position, float radius)
        {
            return Physics.OverlapSphere(position, radius);
        }
    }
}
