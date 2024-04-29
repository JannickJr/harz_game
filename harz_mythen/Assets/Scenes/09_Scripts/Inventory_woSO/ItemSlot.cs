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

    //==ITEM SLOT==//
    [SerializeField] private TMP_Text quantityText;
    [SerializeField] private Image itemImage;


    public GameObject selectedShader;
    public bool thisItemSelected;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
    }

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

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
            selectedShader.SetActive(true);
            thisItemSelected = true; 
        }
        else if (thisItemSelected)
        {
            selectedShader.SetActive(false);
            thisItemSelected = false;
        }
        
    }
    public void OnRightClick()
    {

    }
}
