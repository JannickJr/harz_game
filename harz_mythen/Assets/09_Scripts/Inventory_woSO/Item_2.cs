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



    //public ItemObject item;



    //private ItemSlot item;

    void Start()
    {
        // inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>(); // Es darf nicht in der Startmethode stehen, weil es da nicht gefunden wird, weil es in dem Moment noch deaktiviert ist.
        // muss am besten mit Eventmethode gelöst werden!
        //Debug.Log("IM_1: ");
        //Debug.Log("IM_1: " + inventoryManager);
        //item = FindObjectOfType<ItemSlot>();
        //item.OnItemMarked += HandleOnItemMarked;

        //item.OnItemMarked -= HandleOnItemMarked;
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
        if (Input.GetMouseButtonDown(0)) //&& Dialog.LevelStarted == false)
        {
            //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
            {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
                if (hit.transform.gameObject.CompareTag("Borki"))
                {
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    borki.SetActive(true);
                    StartCoroutine(FadeOut());
                    //Instantiate(borki, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
                }
                else
                {
                    return;
                }




            }
        }
    }

    IEnumerator FadeOut()
    {
        Debug.Log("Borki");
        yield return new WaitForSeconds(1f);
        borkiBox.CrossFadeAlpha(0, 1, false);
        borkiText.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1f);
        StopAllCoroutines();
        borki.SetActive(false);
    }

    /*public void OnItemMarked()
    {
        Debug.Log("Item markiert");
    }*/

    public void MouseClick2()    // Was beim Anklicken eines Items passiert.
        {
            if (Input.GetMouseButtonDown(0)) //&& Dialog.LevelStarted == false)
            {
                //inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                // funktioniert super (sogar für einzelnes Objekt)
                if (Physics.Raycast(ray, out RaycastHit hit)) // funktioniert super
                {                                               // funktioniert nur, wenn Script auf anzuklickendem Objekt liegt
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

    private void OnEnable()
    {
        Item_SO.OnPot += Test;
    }

    public void Test()
    {
        Debug.Log("Item-Test");
    }

    private void OnDestroy()
    {
        Item_SO.OnPot -= Test;
    }

    /*public void HandleOnItemMarked()
    {

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
    


