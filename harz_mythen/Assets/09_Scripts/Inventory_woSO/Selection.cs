using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    // fuer das Wasser in Szene 2
    void Start()
    {
        Material myMaterial = GetComponent<Renderer>().material;
        myMaterial.color = new Color(0f, 0.7f, 1f, 1f);
    }

    public void OnMouseEnter()
    {
        Material myMaterial = GetComponent<Renderer>().material;
        myMaterial.color = new Color(0f, 0.1804f, 1f, 1f);
    }

    public void OnMouseExit() // klappt
    {
        Material myMaterial = GetComponent<Renderer>().material;
        myMaterial.color = new Color (0f, 0.7f, 1f, 1f);
    }
}
