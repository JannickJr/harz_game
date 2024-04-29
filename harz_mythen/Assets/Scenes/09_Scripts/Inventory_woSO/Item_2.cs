using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_2 : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite sprite;

    private InventoryManager inventoryManager;

    public Camera mainCamera;

    //public ItemObject item;

    void Start()
    {
        inventoryManager = GameObject.Find("Inventory_Button").GetComponent<InventoryManager>();
    }

    private void Update()
    {
        MouseClick();
    }

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
                        inventoryManager.AddItem(itemName, quantity, sprite);
                        Debug.Log("Plus XXX"); // funktioniert (sogar für einzelnes Objekt)
                        Destroy(gameObject);
                        Debug.Log("weg XXX"); // funktioniert (sogar für einzelnes Objekt)
                    }
                }
            }
        }
    }
}

