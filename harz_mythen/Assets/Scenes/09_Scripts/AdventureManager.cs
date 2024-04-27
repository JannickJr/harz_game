using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdventureManager : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera mainCamera;
    public Vector3 mousePosWorld;

    RaycastHit hit;

    

    void Update()
    {
        MouseClick();
        MouseRay();

    }

    public void MouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Linke Maustaste wurde gedrückt.");
            mousePos = Input.mousePosition;
            Debug.Log("Screen Space :" + mousePos);
            mousePosWorld = mainCamera.ScreenToWorldPoint(mousePos);
            Debug.Log("World Space :" + mousePosWorld);

            // Raycast --> Treffer abspeichern
            hit = Physics.Raycast(mousePosWorld, transform.TransformDirection(Vector3.forward), );
        }


        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Rechte Maustaste wurde gedrückt.");
        }
    }

    public void MouseRay()
    {

    }
}
