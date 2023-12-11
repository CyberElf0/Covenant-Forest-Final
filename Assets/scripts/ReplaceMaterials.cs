using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MaterialChange
{
    public Renderer visual;
    public Material lastMaterial;
    public Material newMaterial;
}


public class ReplaceMaterials : MonoBehaviour
{
    [SerializeField] float timeInDGM = 0.5f;

    public List<MaterialChange> materialChange;

    public void ChangeMaterialsDMG()
    {
        for (int i = 0; i < materialChange.Count; i++)
        {
            materialChange[i].lastMaterial = materialChange[i].visual.material;
            materialChange[i].visual.material = materialChange[i].newMaterial;
        }

        Invoke("ChangeMaterialsBack", timeInDGM);
    }

    public void ChangeMaterialsBack()
    {
        for (int i = 0; i < materialChange.Count; i++)
        {
            materialChange[i].visual.material = materialChange[i].lastMaterial;
        }
    }
}
