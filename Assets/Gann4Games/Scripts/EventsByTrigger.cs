using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsByTrigger : MonoBehaviour
{
    public string detectTag;
    public string[] detectMultitag;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == detectTag)
            onTriggerEnter.Invoke();
        foreach(string tag in detectMultitag)
        {
            if(other.tag == tag)
            {
                onTriggerEnter.Invoke();
                return;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == detectTag)
            onTriggerStay.Invoke();
        foreach (string tag in detectMultitag)
        {
            if (other.tag == tag)
            {
                onTriggerStay.Invoke();
                return;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == detectTag)
            onTriggerExit.Invoke();
        foreach (string tag in detectMultitag)
        {
            if (other.tag == tag)
            {
                onTriggerExit.Invoke();
                return;
            }
        }
    }
}
