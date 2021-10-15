using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class BattleSuitVisuals : MonoBehaviour
{
    public bool findAutomatically;
    public Bodyparts limbs;

    Transform[] getChildTransforms(Transform item)
    {
        // Create a list
        List<Transform> elementList = new List<Transform>();

        // Add each child object to the list
        for (int i = 0; i < item.childCount; i++) elementList.Add(item.GetChild(i));

        // Return list as array
        return elementList.ToArray();
    }
    private void Update()
    {
        if (findAutomatically)
        {
            AutoSetLimbs();
            findAutomatically = false;
        }
    }
    void AutoSetLimbs()
    {
        foreach(Transform t in getChildTransforms(transform))
        {
            string bodypart = t.name.ToLower();
            if (bodypart.Contains("head")) limbs.head = t;
            if (bodypart.Contains("body")) limbs.body = t;
            if (bodypart.Contains("left"))
            {
                if (bodypart.Contains("leg") || bodypart.Contains("hip") || bodypart.Contains("thigh")) limbs.leftLeg = t;
                if (bodypart.Contains("knee") || bodypart.Contains("foreleg") || bodypart.Contains("shin")) limbs.leftKnee = t;
                if (bodypart.Contains("foot")) limbs.leftFoot = t;

                if (bodypart.Contains("shoulder") || bodypart.Contains("arm")) limbs.leftShoulder = t;
                if (bodypart.Contains("elbow") || bodypart.Contains("forearm")) limbs.leftElbow = t;
                if (bodypart.Contains("hand")) limbs.leftHand = t;
            }
            else if (bodypart.Contains("right"))
            {
                if (bodypart.Contains("leg") || bodypart.Contains("hip") || bodypart.Contains("thigh")) limbs.rightLeg = t;
                if (bodypart.Contains("knee") || bodypart.Contains("foreleg") || bodypart.Contains("shin")) limbs.rightKnee = t;
                if (bodypart.Contains("foot")) limbs.rightFoot = t;

                if (bodypart.Contains("shoulder") || bodypart.Contains("arm")) limbs.rightShoulder = t;
                if (bodypart.Contains("elbow") || bodypart.Contains("forearm")) limbs.rightElbow = t;
                if (bodypart.Contains("hand")) limbs.rightHand = t;
            }
        }
    }
}
