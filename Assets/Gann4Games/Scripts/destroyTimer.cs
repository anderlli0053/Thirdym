using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyTimer : MonoBehaviour {

    public float Time;
    private void Start()
    {
        Destroy(gameObject, Time);
    }
}
