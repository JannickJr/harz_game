using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
 
    void Start()
    {
        Material myMaterial = GetComponent<Renderer>().material;
        //myMaterial.SetFloat("_OutlineThickness", 0.015f);
    }

    public void OnMouseEnter() // klappt
    {
        Material myMaterial = GetComponent<Renderer>().material;
        //myMaterial.SetFloat("_OutlineThickness", 0.015f); 

        //myMaterial.SetColor("_OutlineColor_3D", new Color32(255, 114, 0, 255)); // RGB-Color-Code, orange, Werte in default-Modus, nicht HDR (Shader)
        //myMaterial.SetColor("_OutlineColor_3D", new Color(1f, 0.4471f, 0f, 1f)); // Rechnung für Colorcode: 114/255=0,4471, orange; Werte in default-Modus, nicht HDR (Shader)
        //myMaterial.SetColor("_OutlineColor_3D", new Color32(255, 40, 0, 255)); // RGB-Color-Code, orange, Werte in HDR-Modus, nicht default (Shader)
        myMaterial.SetColor("_OutlineColor_3D", new Color(1f, 0.1569f, 0f, 1f)); // Rechnung für Colorcode: 114/255=0,4471, orange; Werte in HDR-Modus, nicht default (Shader)
    }

    public void OnMouseExit() // klappt
    {
        Material myMaterial = GetComponent<Renderer>().material;
        myMaterial.SetColor("_OutlineColor_3D", Color.black);
    }
}
