using System.Collections.Generic;
using UnityEngine;

namespace Gann4Games.Thirdym.Utility
{
    public class GeneralTools
    {
        public static Vector3 GetClosestVector(Vector3 from, Vector3[] toVectorList)
        {
            float distance = Vector3.Distance(from, toVectorList[0]);
            int closestIndex = 0;
            for (int i = 0; i < toVectorList.Length; i++)
            {
                float newDistance = Vector3.Distance(from, toVectorList[i]);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestIndex = i;
                }
            }
            return toVectorList[closestIndex];
        }
        public static Transform GetClosestTransform(Vector3 from, Transform[] toTransformList)
        {
            if(toTransformList.Length == 1) return toTransformList[0];
            if (toTransformList.Length <= 1) return null;
            
            float distance = Vector3.Distance(from, toTransformList[0].position);

            int closestIndex = 0;
            for (int i = 0; i < toTransformList.Length; i++)
            {
                float newDistance = Vector3.Distance(from, toTransformList[i].position);
                if (newDistance < distance)
                {
                    distance = newDistance;
                    closestIndex = i;
                }
            }
            return toTransformList[closestIndex];
        }
        public static GameObject[] GetGameObjectsOfArray(Component[] components)
        {
            List<GameObject> objList = new List<GameObject>();
            foreach (Component component in components)
                objList.Add(component.gameObject);
            return objList.ToArray();
        }
        public static Transform[] GetTransformsOfArray(Component[] components)
        {
            List<Transform> objList = new List<Transform>();
            foreach (Component component in components)
                objList.Add(component.transform);
            return 
                objList.ToArray();
        }
    }
}
