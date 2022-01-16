using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Material fridgeColor;
    public MeshRenderer[] _meshRenderers;
    public void getMaterials(GameObject clone)
    {
        _meshRenderers = clone.GetComponentsInChildren<MeshRenderer>();
    }

    public void changeColor(Material material)
    {
        Debug.Log("Chagne Color");
        fridgeColor = material;
        for (int i = 0; i < _meshRenderers.Length; i++)
        {
            if (_meshRenderers[i].material.name == "Outside (Instance)")
            {
                _meshRenderers[i].material.SetColor("_Color", fridgeColor.color);
            }
        }

    }
}
