using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogActivation : MonoBehaviour
{
    public GameObject Dialog;
    private bool dialogActivated;

    public Camera mainCamera;

    public float valueText { get; private set; }

    private void Update()
    {
        MouseClick();
    }

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
                    Debug.Log("Treffer XXX"); // funktioniert
                    /*if (dialogActivated)
                    {
                        Dialog.SetActive(false);
                        dialogActivated = false;
                    }*/
                    //else if (!dialogActivated)
                    {
                        Dialog.SetActive(true);
                        dialogActivated = true;
                    }
                }
                
                /*if (hit.transform.gameObject == gameObject.CompareTag("Ruma"))
                {
                    Debug.Log("Treffer XXX"); // funktioniert
                    /*if (dialogActivated)
                    {
                        Dialog.SetActive(false);
                        dialogActivated = false;
                    }*/
                    //else if (!dialogActivated)
                    /*{
                        Debug.Log("valueText = " + valueText);
                        valueText = 1;
                        Debug.Log("valueText = " + valueText);
                        Dialog.SetActive(true);
                        dialogActivated = true;
                    }
                }
                if (hit.transform.gameObject == gameObject.CompareTag("Romar"))
                {
                    Debug.Log("Treffer XXX"); // funktioniert
                    /*if (dialogActivated)
                    {
                        Dialog.SetActive(false);
                        dialogActivated = false;
                    }*/
                    //else if (!dialogActivated)
                    /*{
                        Debug.Log("valueText = " + valueText);
                        valueText = 2;
                        Debug.Log("valueText = " + valueText);
                        Dialog.SetActive(true);
                        dialogActivated = true;
                    }
                }*/
            }
        }
    }
}
