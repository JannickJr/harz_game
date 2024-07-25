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
    private bool honeyActive = false;


    private void OnEnable()
    {
        Item_SO.OnPot += OnPotYes;
        Item_SO.OnHoney += OnHoneyYes;
        ItemSlot.OnItemShutUp += ShutUp; // Eventmanagement für Deaktivierung des markierten Zustands
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Borki"))
        {
            borki.SetActive(true);
            StartCoroutine(FadeOut());
            if (honeyActive == true)
            {
                borki.SetActive(false);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
            }
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

    public void OnPotYes()
    {
        Debug.Log("Item-Test"); 
        potActive = true;
        Debug.Log("potActive: " + potActive);
    }

    public void OnHoneyYes()
    {
        Debug.Log("Item-Test2");
        honeyActive = true;
        Debug.Log("honeyActive: " + honeyActive);
    }

    public void ShutUp() // Eventmanagement für Deaktivierung des markierten Zustands
    {
        potActive = false;
        Debug.Log("potActive = " + potActive);
        honeyActive = false;
        Debug.Log("honeyActive = " + honeyActive);
    }


    /*private void OnDisable() // OnDestroy()
    {
        Item_SO.OnPot -= Test;
        Item_SO.OnHoney -= Test2;
        ItemSlot.OnItemShutUp -= ShutUp;
    }*/


    //==Variante mit Stackable Items==// funktioniert noch nicht
    /*public void MouseClick()    // Klick
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




