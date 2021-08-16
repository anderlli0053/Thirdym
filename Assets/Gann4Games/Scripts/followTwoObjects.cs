using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followTwoObjects : MonoBehaviour {

    public Transform obj1;
    public Transform obj2;
     float distance;

    private void Update()
    {
        transform.position = (obj1.position + obj2.position) / 2;
    }
}
