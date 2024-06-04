using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_and_Use : MonoBehaviour
{
    public Camera mainCamera;


    void Start()
    {
    }

    private void Update()
    {
        MouseClick();
    }

    //==Variante ohne Stackable Items==// funktioniert
    public void MouseClick()    // Klick
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // funktioniert super (sogar für einzelnes Objekt)
            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject == gameObject)
                {

                }
            }
        }
    } // 
}
