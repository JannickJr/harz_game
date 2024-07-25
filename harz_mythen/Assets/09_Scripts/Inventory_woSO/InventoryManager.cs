using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    private bool menuActivated;
    public ItemSlot[] itemSlot; // Array

    public Item_SO[] itemSOs; // neu

    public void Inventory() // Aktivierung und Deaktivierung der Inventarleiste
    {
        if (menuActivated)
        {
            InventoryMenu.SetActive(false);
            menuActivated = false;
        }
        else if (!menuActivated)
        {
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    
    public void UseItem(string itemName) // wird aufgerufen, wenn Item in Inventar angeklickt wird
    { 
        for (int i = 0; i < itemSOs.Length; i++) // Suche in Liste der SCriptable Objects 
        {
            if (itemSOs[i].itemName == itemName) // wenn die Namen übereinstimmen 
            {
                Debug.Log("Itemname: " + itemSOs[i].itemName);
                itemSOs[i].UseItem();
                Debug.Log("Itemname_2: " + itemSOs[i].itemName);
            }
        }
    }

    //==Variante ohne Stackable Items==// funktioniert // Regulierung der Menge der Items in Inventarleiste
    public void AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("itemName = " + itemName + " quantity = " + quantity + " itemSprite = " + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                return; 
            }
        }
    }
    /*
    //==Variante mit Stackable Items==// funktioniert noch nicht
    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        Debug.Log("itemName = " + itemName + " quantity = " + quantity + " itemSprite = " + itemSprite);
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0) 
// If the ItemSlot is NOT full AND the slot has the same item as this one, OR if the slot is completely empty
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription);
                }  
                return leftOverItems;
            }
        }
        return quantity;
    }*/ //

    public void DeselectAllSlots() // ein Itemslot aktiviert, alle anderen deaktiviert; in Benutzung in ItemSlot-Script
    {
        Debug.Log("Item markiert_3");
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
            Debug.Log("Item markiert_4");
        }
    }

    public void SelectTwoSlots() // zwei Itemslots gleichzeitig aktivieren // aktuell nicht in Benutzung
    {
        for (int i = 1; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
