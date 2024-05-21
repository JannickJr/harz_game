using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //==ITEM DATA==//
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;
    public Sprite emptySprite;

    [SerializeField] private int maxNumberOfItems; // efiniert die Größe des Slots

    //==ITEM SLOT==//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;

    //==ITEM Description SLOT==//
    public Image itemDescriptionImage;
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;


    public GameObject selectedShader;
    public GameObject itemDescriptionBar; //neu
    public bool thisItemSelected; // hiermit arbeiten
    

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
    }
    
    //==Variante ohne Stackable Items==// funktioniert
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.itemDescription = itemDescription;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }
    /*
    //==Variante mit Stackable Items==// funktioniert noch nicht
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
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
    }*/ //

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void OnLeftClick()
    {
        if (!thisItemSelected)
        {
            inventoryManager.DeselectAllSlots(); // einer aktiviert, alle anderen deaktiviert
            //inventoryManager.SelectTwoSlots(); // zwei können gleichzeitig aktiviert sein, alle anderen deaktiviert
            if (isFull == true) // Slots nur noch auswählabr, wenn etwas drinliegt, und auch nur dann Beschreibung sichtbar
            {
                selectedShader.SetActive(true);
                itemDescriptionBar.SetActive(true); //neu
            }
            else if (isFull == false)
            {
                selectedShader.SetActive(false);
                itemDescriptionBar.SetActive(false); //neu
            }
            thisItemSelected = true;
            ItemDescriptionNameText.text = itemName;
            ItemDescriptionText.text = itemDescription;
            itemDescriptionImage.sprite = itemSprite;
            if (itemDescriptionImage.sprite == null)
            {
                itemDescriptionImage.sprite = emptySprite;
            }
        }
        else if (thisItemSelected)
        {
            selectedShader.SetActive(false);
            itemDescriptionBar.SetActive(false); //neu
            thisItemSelected = false;
            ItemDescriptionText.text = "";
            ItemDescriptionNameText.text = "";
            itemDescriptionImage.sprite = emptySprite;
        }
    }
    public void OnRightClick()
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

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        isFull = false;
        selectedShader.SetActive(false);
        itemDescriptionBar.SetActive(false); //neu
        thisItemSelected = false;
        ItemDescriptionText.text = "";
        ItemDescriptionNameText.text = "";
        itemDescriptionImage.sprite = emptySprite;
    }
}
