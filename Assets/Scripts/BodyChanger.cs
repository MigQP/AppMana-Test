using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyChanger : MonoBehaviour
{
    private Dictionary<Renderer, Material[]> originalMaterials = new Dictionary<Renderer, Material[]>();

    private Renderer[] children;


    private Material[] original;

    public string changingMaterialName;

    void Awake()
    {

        //children is a reference to the renderers
        children = GetComponentsInChildren<Renderer>();

        foreach (Renderer rend in children)
        {
            //make array of all materials in renderer
            Material[] materials = rend.materials;
            //add to dictionary renderer and material
            originalMaterials[rend] = materials;

            original = materials;
        }


    }


    public void ChangeToNewMaterial(Material newMaterial1)
    {


        foreach (Renderer rend in children)
        {
            var mats = new Material[rend.materials.Length];
            for (var j = 0; j < rend.materials.Length; j++)
            {
                if (rend.materials[j].name.Contains("body"))
                {
                    mats[j] = newMaterial1;
                }
                else
                {
                    mats[j] = original[j];
                }
            }
            rend.materials = mats;

            //Debug.Log(rend.materials[2].name);
        }


    }


    void Reset()
    {

        foreach (KeyValuePair<Renderer, Material[]> pair in originalMaterials)
        {

            pair.Key.materials = pair.Value;

        }
    }
}
