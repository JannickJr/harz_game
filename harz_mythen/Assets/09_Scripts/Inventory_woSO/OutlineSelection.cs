using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
    public Camera mainCamera;
    public void MyOutlines()
    {
        Material myMaterial = GetComponent<Material>();
        myMaterial.SetFloat("_OutlineThickness", 0.015f);
    }
    
    void Start()
    {
        Material myMaterial = GetComponent<Material>();
        myMaterial.SetFloat("_OutlineThickness", 0f);
    }

    
    void Update()
    {
        OutlineStart();
    }

    public void OutlineStart()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // funktioniert super (sogar für einzelnes Objekt)
            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject == gameObject)
                {
                    MyOutlines();
                }
            }
        }
    }
}
