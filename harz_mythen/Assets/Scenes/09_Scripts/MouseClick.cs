using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    
    public InventoryObject inventory;

    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObject);
        }
    }

    /*
    public void OnMouseEnter()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.transform.gameObject == gameObject)
            {
                Debug.Log("Treffer 3");
                var item = gameObject.GetComponent<Item>();
                if (item)
                {
                    inventory.AddItem(item.item, 1);
                    Destroy(this);
                }
            }
        }
    }*/

    /*
    public void OnMouseUpAsButton()
    {
        var item = other.GetComponent<Item>();
        if (item)
        {
            inventory.AddItem(item.item, 1);
            Destroy(other.gameObeject);
        }
    }
    */
}
