using _09_Scripts._Dialogsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    [SerializeField] private Image borkiBox;
    [SerializeField] private TextMeshProUGUI borkiText;

    private bool potActive = false;

    //public ItemObject item;



    //private ItemSlot item;

    void Start()
    {
        // inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>(); // Es darf nicht in der Startmethode stehen, weil es da nicht gefunden wird, weil es in dem Moment noch deaktiviert ist.
        // muss am besten mit Eventmethode gelöst werden!
        //Debug.Log("IM_1: ");
        //Debug.Log("IM_1: " + inventoryManager);
        //item = FindObjectOfType<ItemSlot>();
    }

    private void Update()
    {
        //MouseClick();
        //MouseClick2();
        /*if (potActive == true) // funktioniert, aber dann kriegt man von Bienen wieder alle Items
        {
            FollowTest();
        }*/
    }

    // Text: "Das funktioniert leider nicht."
    // Text: "Der Honig ist süß und klebrig."

    //==Variante ohne Stackable Items==// funktioniert

    public void MouseClick()    // Was beim Anklicken eines Items passiert.
    {
        if (Input.GetMouseButtonDown(0)) //&& Dialog.LevelStarted == false)
        {
            //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject.CompareTag("Borki"))
                {
                    borki.SetActive(true);
                    StartCoroutine(FadeOut());
                }
                if (hit.transform.gameObject.CompareTag("Biene") && potActive == true)
                {
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                    Destroy(gameObject);
                    Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                }
                if (hit.transform.gameObject.CompareTag("Pot"))
                {
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                    Destroy(gameObject);
                }




                /*if (hit.transform.gameObject != gameObject.CompareTag("Borki") && hit.transform.gameObject != gameObject.CompareTag("Biene") && hit.transform.gameObject != gameObject.CompareTag("weg")) //(hit.transform.gameObject.CompareTag("Pot"))
                {
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                    Destroy(gameObject);
                }*/
            }
        }
    }

    IEnumerator FadeOut() // Borki-Text blendet aus
    {
        Debug.Log("Borki");
        yield return new WaitForSeconds(1f);
        borkiBox.CrossFadeAlpha(0, 1, false);
        borkiText.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1f);
        borki.SetActive(false);
        borkiBox.CrossFadeAlpha(1, 0, false);
        borkiText.CrossFadeAlpha(1, 1, false);
        StopAllCoroutines();
    }


    public void MouseClick2()    // Was beim Anklicken eines Items passiert.
        {
            if (Input.GetMouseButtonDown(0)) //&& Dialog.LevelStarted == false)
            {
                //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                // funktioniert super (sogar für einzelnes Objekt)
                if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
                {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                    //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    if (hit.transform.gameObject == gameObject)
                    {
                        Debug.Log("Treffer XXX"); // funktioniert
                                                  //var item = gameObject.GetComponent<Item_2>();
                                                  //if (item)
                        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                        {
                            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                            Debug.Log("Plus XXX"); // funktioniert (sogar für einzelnes Objekt)
                            //if (gameObject.CompareTag("weg"))
                            {
                                Destroy(gameObject); // muss wieder hin
                                Debug.Log("weg XXX"); // funktioniert (sogar für einzelnes Objekt)
                                if (gameObject.CompareTag("Biene")) // notwendig, da Bienenstock erhalten bleiben soll.
                                {
                                    Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                                }
                            }
                        }
                    }
                    else
                {
                    return;
                }
                }
            }
        } // 

    private void OnEnable()
    {
        Item_SO.OnPot += Test;
        Item_SO.OnHoney += Test2;
        Item_SO.OnBorki += Test3;
        ItemSlot.OnItemShutUp += ShutUp; // Eventmanagement für Deaktivierung des markierten Zustands
    }

    public void Test()
    {
        Debug.Log("Item-Test"); // wird erkannt
        potActive = true;
        Debug.Log("potActive: "+ potActive);
        if (potActive == true)
        {
            FollowTest();
        }
        //OnMouseDown();
    }
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Borki"))
        {
            borki.SetActive(true);
            StartCoroutine(FadeOut());
        }
        if (gameObject.CompareTag("Biene") && potActive == true)
        {
            inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
            Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
        }
        if (gameObject.CompareTag("Pot"))
        {
            inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
        /*Debug.Log("OnMouseDown");
        if (gameObject.CompareTag("Biene") && potActive == true)
        {
            Debug.Log("OnMouseDown2");
        }*/
    }
    public void FollowTest()
    {
        Debug.Log("Hallo???");
        if (Input.GetMouseButtonDown(0))  // ab hier wird es nicht mehr erkannt
        {
            //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
            Debug.Log("Warum_1");
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Warum_2");
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Warum_3");
                if (hit.transform.gameObject.CompareTag("Biene"))
                {
                    Debug.Log("Warum_4");

                    {
                        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                        Debug.Log("Warum_5");
                        inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                        Destroy(gameObject);
                        Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                    }
                }
            }
        }
    }

    public void Test2()
    {
        Debug.Log("Item-Test2");
    }
    public void Test3()
    {
        Debug.Log("Item-Test3");
    }

    public void ShutUp() // Eventmanagement für Deaktivierung des markierten Zustands
    {
        potActive = false;
        Debug.Log("potActive = " + potActive);
    }

    /*private void OnDestroy()
    {
        Item_SO.OnPot -= Test;
        Item_SO.OnHoney -= Test2;
        Item_SO.OnBorki -= Test3;
    }*/



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
    


