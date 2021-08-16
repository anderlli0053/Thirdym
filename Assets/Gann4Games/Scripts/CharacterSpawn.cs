using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawn : MonoBehaviour {

    public GameObject Character;

    private void Start()
    {
        GameObject spawnedObj = Instantiate(Character);
        spawnedObj.transform.position = transform.position;
        spawnedObj.transform.rotation = transform.rotation;
    }
}
