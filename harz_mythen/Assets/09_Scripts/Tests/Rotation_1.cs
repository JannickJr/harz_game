using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_1 : MonoBehaviour
{
    public Camera mainCamera;
    public Vector3 rotation;


    void Update()
    {
        MouseClick();
    }

    public void MouseClick()    // Klick
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // funktioniert super (sogar für einzelnes Objekt)
            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("Treffer XXX"); // funktioniert
                    transform.localRotation = Quaternion.Euler(rotation);
                }
            }
        }
    } // 
}
