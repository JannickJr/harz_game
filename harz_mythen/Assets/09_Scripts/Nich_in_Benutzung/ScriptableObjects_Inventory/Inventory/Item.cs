using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemObject item;

    public Camera mainCamera;
    public InventoryObject inventory;

    void Update()
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
                    Debug.Log("Treffer"); // funktioniert
                    var item = gameObject.GetComponent<Item>();
                    if (item)
                    {
                        inventory.AddItem(item.item, 1);
                        Debug.Log("Plus"); // funktioniert (sogar für einzelnes Objekt)
                        Destroy(gameObject);
                        Debug.Log("weg"); // funktioniert (sogar für einzelnes Objekt)
                    }
                }
            }
        }
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}

