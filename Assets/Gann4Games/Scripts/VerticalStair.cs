using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VerticalStair : MonoBehaviour {
    public bool Supports;
    public float StairSep;
    public int Stairs;
    public Vector3 StairSize = new Vector3(1, 1, 1);
    public List<GameObject> GameObjects;
    private void Start()
    {
        for(int i = 0; i < Stairs; i++)
        {
            GameObject prim = GameObject.CreatePrimitive(PrimitiveType.Cube);
            prim.transform.rotation = transform.rotation;
            prim.transform.position = transform.position + new Vector3(0, StairSep * i, 0);
            prim.transform.localScale = StairSize;
            prim.tag = transform.tag;
            prim.transform.SetParent(transform);
            GameObjects.Add(prim);
        }

        GameObject supp1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        supp1.transform.rotation = transform.rotation;
        supp1.transform.position = transform.position + new Vector3(StairSize.x / 2, (StairSep / 2) * Stairs, 0);
        supp1.transform.localScale = new Vector3(StairSize.z, StairSep * Stairs, StairSize.z);
        supp1.transform.SetParent(transform);
        GameObjects.Add(supp1);

        GameObject supp2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        supp2.transform.rotation = transform.rotation;
        supp2.transform.position = transform.position + new Vector3(-StairSize.x / 2, (StairSep / 2) * Stairs, 0);
        supp2.transform.localScale = new Vector3(StairSize.z, StairSep * Stairs, StairSize.z);
        supp2.transform.SetParent(transform);
        GameObjects.Add(supp2);

        BoxCollider boxcol = gameObject.AddComponent<BoxCollider>();
        float dist = Vector3.Distance(GameObjects[0].transform.position, GameObjects[Stairs].transform.position);
        boxcol.center = new Vector3(0, dist, 0);
        boxcol.size = new Vector3(StairSize.x, dist*2, StairSize.z);
        /*
        boxcol.center = new Vector3(0, GameObjects[Stairs].transform.localPosition.y / 2, 0);
        boxcol.size = new Vector3(StairSize.x, StairSep * Stairs, StairSize.z);*/
        gameObject.AddComponent<Rigidbody>().isKinematic = true;
        Debug.Break();

        if(!Supports)
        {
            Destroy(supp1);
            Destroy(supp2);
        }

        foreach (GameObject GOs in GameObjects)
        {
            Destroy(GOs.GetComponent<BoxCollider>());
        }
    }
    private void OnDrawGizmosSelected()
    {
        //Stairs
        for(int i = 0; i < Stairs; i++)
        {
            Gizmos.DrawCube(transform.position + new Vector3(0, StairSep * i, 0), StairSize);
        }

        //Supports
        Gizmos.DrawCube(transform.position + new Vector3(StairSize.x / 2, (StairSep / 2) * Stairs, 0), new Vector3(StairSize.z, StairSep * Stairs, StairSize.z));
        Gizmos.DrawCube(transform.position + new Vector3(-StairSize.x / 2, (StairSep / 2) * Stairs, 0), new Vector3(StairSize.z, StairSep * Stairs, StairSize.z));
    }
}
