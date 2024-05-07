using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayInventory : MonoBehaviour
{
    public InventoryObject inventory;

    public GameObject inventorySlotPrefab; // neuer Versuch

    // Verlinkung zu Inventar in Editor
    public int X_START;
    public int Y_START;
    public int X_SPACE_BEETWEEN_ITEM; 
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEMS;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();

    void Start()
    {
       CreateDisplay();
    }

    
    void Update()
    {
        UpdateDisplay();
    }

     // neuer Versuch:
    public void UpdateDisplay()
    {
        // Schleife über jedes Element im Inventar
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            // Überprüfe, ob bereits ein visuelles Element für diesen Inventarslot vorhanden ist
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                // Aktualisiere das vorhandene visuelle Element mit den aktuellen Informationen aus dem Inventar
                UpdateVisualElement(itemsDisplayed[inventory.Container[i]], inventory.Container[i]);
            }
            else
            {
                // Erzeuge ein neues visuelles Element für diesen Inventarslot
                CreateVisualElement(inventory.Container[i]);
            }
            // Berechne die Position des visuellen Elements basierend auf dem Index
            itemsDisplayed[inventory.Container[i]].GetComponent<RectTransform>().localPosition = GetPosition(i);
        }
    }

    // Methode zum Erstellen eines visuellen Elements für einen Inventarslot
    private void CreateVisualElement(InventorySlot slot)
    {
        // Instanziiere das Prefab und setze es als Kindobjekt des aktuellen GameObjects
        GameObject visualElement = Instantiate(inventorySlotPrefab, transform);
        // Konfiguriere das visuelle Element basierend auf den Informationen aus dem Inventarslot
        ConfigureVisualElement(visualElement, slot);
        // Füge das visuelle Element der Liste hinzu
        itemsDisplayed.Add(slot, visualElement);
    }

    // Methode zum Aktualisieren eines vorhandenen visuellen Elements
    private void UpdateVisualElement(GameObject visualElement, InventorySlot slot)
    {
        // Konfiguriere das visuelle Element basierend auf den aktuellen Informationen aus dem Inventarslot
        ConfigureVisualElement(visualElement, slot);
    }

    // Methode zum Konfigurieren eines visuellen Elements basierend auf den Informationen aus dem Inventarslot
    private void ConfigureVisualElement(GameObject visualElement, InventorySlot slot)
    {
        // Holen Sie sich hier die notwendigen Komponenten des visuellen Elements und aktualisieren Sie diese mit den Informationen aus dem Inventarslot
        // Zum Beispiel Text, Bild, usw.
        visualElement.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        // Weitere Konfiguration je nach Bedarf
    }

    // Methode zur Berechnung der Position des visuellen Elements basierend auf dem Index
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BEETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
    }

    public void CreateDisplay()
    {
        // Schleife über jedes Element im Inventar und erstelle ein visuelles Element
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            CreateVisualElement(inventory.Container[i]);
            // Berechne die Position des visuellen Elements basierend auf dem Index
            itemsDisplayed[inventory.Container[i]].GetComponent<RectTransform>().localPosition = GetPosition(i);
        }
    }


    /* //alt
    public void UpdateDisplay()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            if (itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                var obj = Instantiate(inventory.Container[i], Vector3.zero, Quaternion.identity, transform);
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
            }
        }
    }

    public void CreateDisplay()
{
for (int i = 0; i < inventory.Container.Count; i++)
{
    var obj = Instantiate(inventory.Container[i], Vector3.zero, Quaternion.identity, transform);
    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
    obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
}
}

public Vector3 GetPosition(int i)
{
return new Vector3(X_START + (X_SPACE_BEETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + (-Y_SPACE_BETWEEN_ITEMS * (i / NUMBER_OF_COLUMN)), 0f);
}
*/


}
