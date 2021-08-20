using UnityEngine;
using UnityEngine.Events;

public class EventsByTrigger : MonoBehaviour
{
    public string detectTag;
    public string[] detectMultitag;
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerStay;
    public UnityEvent onTriggerExit;

#if UNITY_EDITOR
    BoxCollider _collider => GetComponent<BoxCollider>();

    private void OnDrawGizmos()
    {
        if (transform.localScale != Vector3.one) Debug.LogError($"[{gameObject.name}] Must have a scale of Vector3.one!");
        if (_collider)
        {
            Gizmos.color = Color.magenta * new Color(1, 1, 1, .1f);

            Vector3 cubePosition = transform.position + _collider.center;
            Vector3 cubeSize = _collider.size;
            Gizmos.DrawCube(cubePosition, cubeSize);
        }
    }
#endif

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
