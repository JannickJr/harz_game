using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace _09_Scripts._Dialogsystem
{
    public class DialogActivation_2 : MonoBehaviour
    {
        public GameObject Dialogi;
        public static bool dialogActivated; // evtl. in Methode umwandeln
        public static int characterNumber = 0; // evtl. in Methode umwandeln

        public Camera mainCamera;

        public static event Action OnInventoryWall; // sendet in InventoryManager


        //---Sprechblasen - Start nach Interaktion---//
        private void Update()
        {
            MouseClick();
        }
        //---Sprechblasen - Start nach Interaktion---//
        public void MouseClick()    // Klick
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                // funktioniert super (sogar für einzelnes Objekt)
                if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
                {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                    if (GameObject.Find("03_Scene_01") || GameObject.Find("07_Scene_03"))
                    {
                        if (hit.transform.gameObject.CompareTag("Ruma")) // wenn Ruma angeklickt wird
                        {
                            Debug.Log("Treffer XXX Ruma"); // funktioniert
                            if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                                characterNumber = 0;
                            }
                            if (!dialogActivated && characterNumber != 2)
                            {
                                characterNumber = 1;
                                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                                Debug.Log("Dialog-Ruma_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                                OnInventoryWall(); // Nachricht schreiben, dass Inventar geschlossen und deaktiviert wird | // sendet in InventoryManager
                            }
                        }
                        if (hit.transform.gameObject.CompareTag("Romar")) // wenn Romar angeklickt wird
                        {
                            Debug.Log("Treffer XXX Romar"); // funktioniert
                            if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                                characterNumber = 0;
                            }
                            if (!dialogActivated && characterNumber != 1)
                            {
                                characterNumber = 2;
                                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                                Debug.Log("Dialog-Romar_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                                OnInventoryWall(); // Nachricht schreiben, dass Inventar geschlossen und deaktiviert wird | // sendet in InventoryManager
                            }
                        }
                    }

                    if (GameObject.Find("05_Scene_02"))
                    {
                        if (hit.transform.gameObject.CompareTag("Ruma")) // wenn Ruma angeklickt wird
                        {
                            Debug.Log("Treffer XXX Ruma"); // funktioniert
                            if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                                characterNumber = 0;
                            }
                            if (!dialogActivated && characterNumber != 2 && characterNumber != 3) 
                            {
                                characterNumber = 1;
                                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                                Debug.Log("Dialog-Ruma_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                                OnInventoryWall(); // Nachricht schreiben, dass Inventar geschlossen und deaktiviert wird
                            }
                        }
                        if (hit.transform.gameObject.CompareTag("Kobold_1")) // wenn Romar angeklickt wird
                        {
                            Debug.Log("Treffer XXX Kobold_1"); // funktioniert
                            if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                                characterNumber = 0;
                            }
                            if (!dialogActivated && characterNumber != 1 && characterNumber != 3)
                            {
                                characterNumber = 2;
                                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                                Debug.Log("Dialog-Kobold_1_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                                OnInventoryWall(); // Nachricht schreiben, dass Inventar geschlossen und deaktiviert wird
                            }
                        }
                        if (hit.transform.gameObject.CompareTag("Kobold_2")) // wenn Romar angeklickt wird
                        {
                            Debug.Log("Treffer XXX Kobold_2"); // funktioniert
                            if (dialogActivated)
                            {
                                Dialogi.SetActive(false);
                                dialogActivated = false;
                                characterNumber = 0;
                            }
                            if (!dialogActivated && characterNumber != 1 && characterNumber != 2)
                            {
                                characterNumber = 3;
                                Debug.Log("CharacterNumber = " + DialogActivation.characterNumber);
                                Debug.Log("Dialog-Kobold_2_on");
                                Dialogi.SetActive(true);
                                dialogActivated = true;
                                OnInventoryWall(); // Nachricht schreiben, dass Inventar geschlossen und deaktiviert wird
                            }
                        }
                    }
                }
            }
        }
    }
}
