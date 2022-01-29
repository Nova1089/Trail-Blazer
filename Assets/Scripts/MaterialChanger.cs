using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    // cache
    [SerializeField] Material[] possibleMaterials;

    // cache
    MeshRenderer[] meshRenderers;

    // Unity messages
    void Awake()
    {
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    void Start()
    { 
        foreach (var meshRenderer in meshRenderers)
        {
            int diceRoll = Random.Range(0, possibleMaterials.Length);
            meshRenderer.material = possibleMaterials[diceRoll];
        }
    }
}
