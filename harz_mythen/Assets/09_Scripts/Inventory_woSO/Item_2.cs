using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_2 : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [TextArea] [SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    public Camera mainCamera;

    public GameObject bienePrefab; 
    public GameObject borki;

    //public ItemObject item;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        MouseClick();
        MouseClick2();
    }

    // Text: "Das funktioniert leider nicht."
    // Text: "Der Honig ist süß und klebrig."

    //==Variante ohne Stackable Items==// funktioniert

    public void MouseClick()    // Was beim Anklicken eines Items passiert.
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject.CompareTag("Borki"))
                {
                    borki.SetActive(true);
                    //Instantiate(borki, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                }

                else
                {
                    return;
                }




            }
        }
    }
            
            
        public void MouseClick2()    // Was beim Anklicken eines Items passiert.
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
                        //var item = gameObject.GetComponent<Item_2>();
                        //if (item)
                        {
                            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                            Debug.Log("Plus XXX"); // funktioniert (sogar für einzelnes Objekt)
                            //if (gameObject.CompareTag("weg"))
                            {
                                Destroy(gameObject);
                                Debug.Log("weg XXX"); // funktioniert (sogar für einzelnes Objekt)
                                if (gameObject.CompareTag("Biene")) // notwendig, da Bienenstock erhalten bleiben soll.
                                {
                                    Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                                }
                            }

                        }
                    }
                }
            }
        } // 

       




        /*
        //==Variante mit Stackable Items==// funktioniert noch nicht
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
                        //var item = gameObject.GetComponent<Item_2>();
                        //if (item)
                        {
                            int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                            Debug.Log("Plus XXX"); // funktioniert (sogar für einzelnes Objekt)
                            if (leftOverItems <= 0)
                            {
                                Destroy(gameObject);
                                Debug.Log("weg XXX"); // funktioniert (sogar für einzelnes Objekt)
                            }
                            else
                            {
                                quantity = leftOverItems;
                            }
                        }
                    }
                }
            }
        }*/ //
        }
    


