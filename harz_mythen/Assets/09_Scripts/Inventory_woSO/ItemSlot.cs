using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using _09_Scripts._Dialogsystem;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //==ITEM DATA==//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField] private int maxNumberOfItems; // definiert die Größe des Slots, im Moment nicht in Benutzung

    //==ITEM SLOT==//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //==ITEM Description SLOT==//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;


    public GameObject selectedShader;
    public GameObject itemDescriptionBar; 
    public bool thisItemSelected; // hiermit arbeiten
    
    private InventoryManager inventoryManager;

    public static event Action OnItemShutUp; // Eventmanagement für Deaktivierung des markierten Zustands

    public GameObject wall;

    private void OnEnable()
    {
        Item_2.OnDelete += OnDeleteYes;
        DialogActivation.OnInventoryWall += InventoryDeactivation;
        //Dialog.OnInteraction += Inventory; // gescheitertes Experiment
    }

    /*private void OnDisable()
    {
        Dialog.OnInteraction += Inventory; // gescheitertes Experiment
    }*/

    private void Update() // muss am besten mit Eventmethode gelöst werden statt Update
    {
        if (Dialog.LevelStarted == false) // Empfänger
        {
            inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>(); // Es darf nicht in der Startmethode stehen, weil es da nicht gefunden wird, weil es in dem Moment noch deaktiviert ist.
        }
    }

    public void Inventory() // gescheitertes Experiment
    {
        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
    }

    //==Variante ohne Stackable Items==// funktioniert // Hinzufügen eines Items in Itemslot
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        //this.quantity = quantity; // Anzahl fürs Erste entfernt
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        //quantityText.text = quantity.ToString(); // Anzahl fürs Erste entfernt
        //quantityText.enabled = true; // Anzahl fürs Erste entfernt
        itemImage.sprite = itemSprite;
    }

    public void OnPointerClick(PointerEventData eventData) // Weiterleitung zu den Methoden
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            //OnRightClick();
        }
    }
    
    public void OnLeftClick() // Itemslot auswählen, um Itembeschreibung zu (de-)aktivieren
    {
        if (!thisItemSelected) // wenn kein Slot markiert ist und er angeklickt wird
        {
            inventoryManager.DeselectAllSlots(); // einer aktiviert, alle anderen deaktiviert
            //inventoryManager.SelectTwoSlots(); // zwei können gleichzeitig aktiviert sein, alle anderen deaktiviert
            thisItemSelected = true;
            if (isFull == true) // Slots nur noch auswählabr, wenn etwas drinliegt, und auch nur dann Beschreibung sichtbar
            {
                selectedShader.SetActive(true);
                Debug.Log("Item markiert");
                itemDescriptionBar.SetActive(true); 
                Debug.Log("Item markiert_2");

                ItemDescriptionNameText.text = itemName;
                ItemDescriptionText.text = itemDescription;
                itemDescriptionImage.sprite = itemSprite;

                inventoryManager.UseItem(itemName); // Weiterleitung an Item_SO // neu
                Debug.Log("Item markiert_5");

                //wall.SetActive(true);
            }
            else if (isFull == false) // wenn nichts drinliegt
            {
                selectedShader.SetActive(false);
                itemDescriptionBar.SetActive(false);
                //wall.SetActive(false);
            }
            if (itemDescriptionImage.sprite == null) // wenn kein Sprite mehr drinliegt
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
        else if (thisItemSelected) // wenn Slot markiert ist und er ein weiteres mal angeklickt wird
        {
            selectedShader.SetActive(false);
            itemDescriptionBar.SetActive(false); 
            thisItemSelected = false;
            ItemDescriptionText.text = "";
            ItemDescriptionNameText.text = "";
            itemDescriptionImage.sprite = emptySprite;
            OnItemShutUp(); // Eventmanagement für Deaktivierung des markierten Zustands
        }
    }

    // Entfernen des Items aus Itemslot mit Rechtsklick, wenn das Item markiert war
    public void OnRightClick() // funktioniert // aktuell deaktiviert bei Methodenweiterleitung 
    {
        if (thisItemSelected)
        {
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }

    public void OnDeleteYes()
    {
        if (thisItemSelected)
        {
            this.quantity -= 1;
            quantityText.text = this.quantity.ToString();
            if (this.quantity <= 0)
            {
                EmptySlot();
            }
        }
    }

    public void EmptySlot() // Was passiert, wenn Itemslot leer ist.
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        isFull = false;
        selectedShader.SetActive(false);
        itemDescriptionBar.SetActive(false); 
        thisItemSelected = false;
        ItemDescriptionText.text = "";
        ItemDescriptionNameText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }

    public void InventoryDeactivation()
    {
        selectedShader.SetActive(false);
        itemDescriptionBar.SetActive(false);
        thisItemSelected = false;
        ItemDescriptionText.text = "";
        ItemDescriptionNameText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }

    private void OnDestroy()
    {
        Item_2.OnDelete -= OnDeleteYes;
        DialogActivation.OnInventoryWall -= InventoryDeactivation;
        //Dialog.OnInteraction -= Inventory; // gescheitertes Experiment
    }

    //==Variante mit Stackable Items==// funktioniert noch nicht
    /*public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check to see, if the slot is already full
        //isFull = true;
        if (isFull)
        {
            return quantity;
        }
        // Update Name
        this.itemName = itemName;

        // Update Image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        // Update Description
        this.itemDescription = itemDescription;

        // Update Quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;

            // Return LeftOverItems
            int extraItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;
            return extraItems;
        }

        // Update Quantity Text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }*/
}
