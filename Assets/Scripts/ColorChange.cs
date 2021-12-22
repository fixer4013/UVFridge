using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{   
    void Update()
    {
       MeshRenderer[] mad = transform.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < mad.Length; i++)
        {
            if(mad[i].material.name == "Outside (Instance)")
            {
                mad[i].material.SetColor("_Color", Color.red);
            }
        }
    }
}
