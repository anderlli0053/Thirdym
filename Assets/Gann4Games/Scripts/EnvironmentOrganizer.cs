using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class EnvironmentOrganizer : MonoBehaviour {

    string[] categories = {
        "Interactable",
        "Props",
        "Movable Objects",
        "Statics",
        "Lighting",
        "Reflections",
        "Reverb Zones",
        "Ambient SFX",
    };
    public bool createCategories;

    private void Update()
    {
        if (createCategories)
            CreateCategories();
    }

    public void CreateCategories()
    {
        createCategories = false;

        if (transform.name != "Enviroment")
        {
            Transform envTrans = new GameObject("Enviroment").transform;
            envTrans.position = Vector3.zero;
            envTrans.rotation = Quaternion.Euler(Vector3.zero);
            envTrans.localScale = Vector3.one;

            newCategories(envTrans);
        }
        else
            newCategories(transform);

        DestroyImmediate(this);
    }
    void newCategories(Transform transform)
    {
        for (int i = 0; i < categories.Length; i++)
        {
            Debug.Log(categories[i]);
            Transform newCat = new GameObject(categories[i]).transform;
            newCat.SetParent(transform);
            newCat.position = transform.position;
            newCat.rotation = transform.rotation;
            newCat.localScale = Vector3.one;
        }
    }
}
