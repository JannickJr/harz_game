using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _09_Scripts._Dialogsystem
{


public class DialogActivation : MonoBehaviour
{
    public GameObject Dialogi;
    public static bool dialogActivated;
    public static int characterNumber = 0;

    public Camera mainCamera;

    //---Dialog Start vor Interaktion---//
    private void Start() 
    {
        Dialogi.SetActive(true);
        dialogActivated = true;
    }

    //---Dialog Start nach Interaktion---//
    private void Update()
    {
        MouseClick();
    }
    //---Dialog Start nach Interaktion---//
    public void MouseClick()    // Klick
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            // funktioniert super (sogar für einzelnes Objekt)
            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                /*if (hit.transform.gameObject == gameObject)
                {
                    Debug.Log("Treffer XXX"); // funktioniert
                    /*if (dialogActivated)
                    {
                        Dialogi.SetActive(false);
                        dialogActivated = false;
                    }*/
                    //else if (!dialogActivated)
                   /* {
                        Dialogi.SetActive(true);
                        dialogActivated = true;
                    }
                }
                if (Dialog.isdriving) // Quatsch-Test
                    {
                        Debug.Log("isDriving");
                    }
                if (!Dialog.isdriving) 
                    {
                        Debug.Log("isNotDriving"); // wird angegeben
                    }
                if (Dialog.valueText == 1)
                    {

                    }*/

                if (hit.transform.gameObject.CompareTag("Ruma"))
                    {
                        Debug.Log("Treffer XXX Ruma"); // funktioniert
                        characterNumber = 1;
                        Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                        if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                            }
                        if (!dialogActivated)
                            {
                                //Debug.Log("valueText = " + valueText);
                                //valueText = 1;
                                //Debug.Log("valueText = " + valueText);
                                Debug.Log("Dialog-Ruma_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                            }
                    }
                if (hit.transform.gameObject.CompareTag("Romar"))
                    {
                        Debug.Log("Treffer XXX Romar"); // funktioniert
                        characterNumber = 2;
                        Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                        if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                            }
                        if (!dialogActivated)
                            {
                                //Debug.Log("valueText = " + valueText);
                                //valueText = 2;
                                //Debug.Log("valueText = " + valueText);
                                Debug.Log("Dialog-Romar_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                            }
                    }
            }
        }
    }
}
}
