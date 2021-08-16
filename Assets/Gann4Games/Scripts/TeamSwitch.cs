using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class TeamSwitch : MonoBehaviour {

    public bool Switch;
    public GameObject coloredObject;
    public Material BlueTeam;
    public Material RedTeam;
    public string SelectedTeam;

    private void Update()
    {
        if (!Switch)
        {
            coloredObject.GetComponent<Renderer>().material = BlueTeam;
            SelectedTeam = "Blue";
        }
        else
        {
            coloredObject.GetComponent<Renderer>().material = RedTeam;
            SelectedTeam = "Red";
        }
    }
}
