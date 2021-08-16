using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabRigidbodies : MonoBehaviour {
    public KeyCode grabKey;
    public bool rbGrabbed;
    public Text rbIndicator;
    public string beforeIndicate;
    SpringJoint sj;
    [HideInInspector]
    public Rigidbody rb;
    AudioSource au;
    public AudioClip gripSound;
    private void Start()
    {
        au = gameObject.AddComponent<AudioSource>();
        au.spatialBlend = 1;
        sj = GetComponent<SpringJoint>();
        if (gameObject.name.Contains("Left"))
            grabKey = KeyCode.Q;
        else if (gameObject.name.Contains("Right"))
            grabKey = KeyCode.E;
    }
    void Update() {
        if (rb != null || rbGrabbed)
        {
            if (InputHandler.instance.use)
            {
                if (rbGrabbed == false)
                {
                    rbGrabbed = true;
                    sj.connectedBody = rb;
                }
                else
                {
                    rbGrabbed = false;
                    sj.connectedBody = null;
                    rb = null;
                }
                au.PlayOneShot(gripSound);
            }
        }
        if (rbGrabbed)
        {
            sj.tolerance = 0.025f;
            sj.spring = 12000;
        }
        else
        {
            sj.tolerance = 1;
            sj.spring = 0;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.GetComponent<Rigidbody>() || other.gameObject.GetComponent<Collider>().isTrigger)
            return;
        
        rb = other.GetComponent<Rigidbody>();

        if (rb.tag == "Map" && rb.isKinematic)
            rbIndicator.text = beforeIndicate + " [Map] " + rbGrabbed.ToString();
        else if (rb.tag == "Map" && rb.isKinematic == false)
            rbIndicator.text = beforeIndicate + " [Prop] " + rbGrabbed.ToString();
        else if (LayerMask.LayerToName(rb.gameObject.layer) == "CharacterParts" || LayerMask.LayerToName(rb.gameObject.layer) == "ControllerCollider" || LayerMask.LayerToName(rb.gameObject.layer) == "EnemyParts" || LayerMask.LayerToName(rb.gameObject.layer) == "EnemyCollider")
            rbIndicator.text = beforeIndicate + " [Ragdoll] " + rbGrabbed.ToString();
        else if (rb.GetComponent<PickupableGun>())
            rbIndicator.text = beforeIndicate + " [" + rb.GetComponent<PickupableGun>().GunType + "] " + rbGrabbed.ToString();
        else if (rb.gameObject.layer == LayerMask.NameToLayer("CharacterWeapons"))
            rbIndicator.text = beforeIndicate + " [Weapon] " + rbGrabbed.ToString();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<Rigidbody>())
            return;
        if (other.GetComponent<Rigidbody>())
        {
            rb = null;
        }
        rbIndicator.text = beforeIndicate + " [None]";
    }
}
