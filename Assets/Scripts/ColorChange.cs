using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{   
    void Update()
    {
        transform.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }
}
