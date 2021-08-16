using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Zone : MonoBehaviour {

	public enum triggers
    {
        triggerEnter,
        triggerExit,
        both,
    }
    public enum mode
    {
        enableNPCS,
        disableNPCS,
        none,
    }

    public bool enableOnStart;
    public triggers Mode;
    [Space]
    public mode triggerEnter;
    public mode triggerExit;
    [Space]
    public List<RagdollController> Npcs;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        for (int i = 0; i < Npcs.Count; i++) {
            Gizmos.DrawLine(transform.position, Npcs[i].transform.position);
        }
    }
    private void Start()
    {
        SetActiveNPCS(enableOnStart);
        if(GetComponent<MeshRenderer>())
        {
            Destroy(GetComponent<MeshRenderer>());
            Destroy(GetComponent<MeshFilter>());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (Mode == triggers.both || Mode == triggers.triggerEnter)
        {
            if (other.GetComponent<CharacterCustomization>().isNPC)
            {
                Npcs.Add(other.GetComponent<RagdollController>());
            }
            else
            {
                if (triggerEnter == mode.enableNPCS)
                    SetActiveNPCS(true);
                else if (triggerEnter == mode.disableNPCS)
                    SetActiveNPCS(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Mode == triggers.both || Mode == triggers.triggerExit)
        {
            if (other.GetComponent<CharacterCustomization>().isNPC)
            {
                Npcs.Remove(other.GetComponent<RagdollController>());
            }
            else
            {
                if (triggerExit == mode.enableNPCS)
                    SetActiveNPCS(true);
                else if (triggerExit == mode.disableNPCS)
                    SetActiveNPCS(false);
            }
        }
    }
    public void SetActiveNPCS(bool enable)
    {
        foreach (RagdollController local in Npcs)
            local.gameObject.SetActive(enable);
    }
}
