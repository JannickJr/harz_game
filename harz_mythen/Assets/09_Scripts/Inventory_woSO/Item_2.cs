using _09_Scripts._Dialogsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item_2 : MonoBehaviour
{
    //---Szene 1 und 2---//
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;
    [TextArea] [SerializeField] private string itemDescription;

    private InventoryManager inventoryManager;

    public Camera mainCamera;

    public static event Action OnDelete; // Eventmanagement für Löschung des Items in Itemslot

    public GameObject textBoxGO;
    [SerializeField] private Image textBoxI;
    [SerializeField] private TextMeshProUGUI text;

    //---Szene 1---//
    public GameObject bienePrefab;

    private bool potActive = false;
    private bool honeyActive = false;

    //---Szene 2---//
    public Sprite spriteChange;
    public GameObject waterPrefab;

    private bool stickActive = false;
    private bool webActive = false;
    private bool waterActive = false;
    public static bool stick = false;
    public static bool web = false;


    private void OnEnable()
    {
        Item_SO.OnPot += OnPotYes;
        Item_SO.OnHoney += OnHoneyYes;
        Item_SO.OnFishing += OnFishingYes;
        Item_SO.OnOlm += OnOlmYes;
        ItemSlot.OnItemShutUp += ShutUp; // Eventmanagement für Deaktivierung des markierten Zustands
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Pot"))
        {
            inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
            inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
            Destroy(gameObject);
        }
        if (gameObject.CompareTag("Biene"))
        {
            text.text = "Hier wird Honig produziert.";
            StartCoroutine(FadeOutText());
            if (potActive == true)
            {
                OnDelete();
                textBoxGO.SetActive(false);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
                Instantiate(bienePrefab, transform.position, Quaternion.Euler(new Vector3(-90F, 0F, 0F)));
            }
        }
        if (gameObject.CompareTag("Borki"))
        {
            text.text = "Der Borkenkäfer könnte noch benötigt werden.";
            StartCoroutine(FadeOutText());
            if (honeyActive == true)
            {
                OnDelete();
                textBoxGO.SetActive(false);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
                ItemSlot.OnItemShutUp -= ShutUp; // ShutUp unsubscriben
            }
        }
        if (gameObject.CompareTag("Stick"))
        {
            stick = true;
            Debug.Log("web = " + web);
            if (web == true)
            {
                Debug.Log("web = " + web);
                if (webActive == true)
                {
                    OnDelete();
                    Debug.Log("web = " + web);
                    itemName = "Kescher";
                    itemDescription = "Damit lässt sich etwas fangen.";
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    inventoryManager.AddItem(itemName, quantity, spriteChange, itemDescription);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("web = " + web);
                    text.text = "Er sieht sehr stabil aus.";
                    StartCoroutine(FadeOutText());
                }
            }
            if (web == false)
            {
                Debug.Log("web = " + web);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
            }
        }
        if (gameObject.CompareTag("Web"))
        {
            web = true;
            Debug.Log("stick = " + stick);
            if (stick == true)
            {
                Debug.Log("stick = " + stick);
                if (stickActive == true)
                {
                    OnDelete();
                    Debug.Log("stick = " + stick);
                    itemName = "Kescher";
                    itemDescription = "Damit lässt sich etwas fangen.";
                    inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                    inventoryManager.AddItem(itemName, quantity, spriteChange, itemDescription);
                    Destroy(gameObject);
                }
                else
                {
                    Debug.Log("stick = " + stick);
                    text.text = "Es fühlt sich sehr reißfest an.";
                    StartCoroutine(FadeOutText());
                }
            }
            if (stick == false)
            {
                Debug.Log("stick = " + stick);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
            }
        }
        if (gameObject.CompareTag("Water"))
        {
            text.text = "Hier unten ist bestimmt etwas zu finden.";
            StartCoroutine(FadeOutText());
            if (waterActive == true)
            {
                Debug.Log("waterActive = " + waterActive);
                OnDelete();
                textBoxGO.SetActive(false);
                inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
                inventoryManager.AddItem(itemName, quantity, sprite, itemDescription);
                Destroy(gameObject);
                Instantiate(waterPrefab, transform.position, Quaternion.Euler(new Vector3(0F, 0F, 0F)));
                ItemSlot.OnItemShutUp -= ShutUp; // ShutUp unsubscriben
            }
        }
    }

    IEnumerator FadeOutText()
    {
        Debug.Log("Text");
        textBoxGO.SetActive(true);
        yield return new WaitForSeconds(1f);
        textBoxI.CrossFadeAlpha(0, 1, false);
        text.CrossFadeAlpha(0, 1, false);
        yield return new WaitForSeconds(1f);
        textBoxGO.SetActive(false);
        textBoxI.CrossFadeAlpha(1, 0, false);
        text.CrossFadeAlpha(1, 1, false);
        StopCoroutine(FadeOutText());
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

    public void OnFishingYes()
    {
        Debug.Log("Item-Test2");
        stickActive = true;
        webActive = true;
        Debug.Log("webstickActive: " + stickActive);
    }

    public void OnOlmYes()
    {
        Debug.Log("Item-Test2");
        waterActive = true;
        Debug.Log("waterActive: " + waterActive);
    }

    public void ShutUp() // Eventmanagement für Deaktivierung des markierten Zustands
    {
        potActive = false;
        Debug.Log("potActive = " + potActive);
        honeyActive = false;
        Debug.Log("honeyActive = " + honeyActive);
        stickActive = false;
        webActive = false;
        waterActive = false;
    }

    private void OnDestroy()
    {
        Item_SO.OnPot -= OnPotYes;
        Item_SO.OnHoney -= OnHoneyYes;
        Item_SO.OnFishing -= OnFishingYes;
        Item_SO.OnOlm -= OnOlmYes;
    }

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




