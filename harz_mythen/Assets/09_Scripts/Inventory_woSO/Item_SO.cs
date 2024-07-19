using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class Item_SO : ScriptableObject
{
    public string itemName;

    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributesToChange attributesToChange = new AttributesToChange();
    public int amountToChangeAttributes;

    public void UseItem()
    {
        if (statToChange == StatToChange.bee) // jetzt muss was passieren
        {
            GameObject.Find("Box").GetComponent<Item_2>().Test();
        }
        // das für jeden Stat schreiben
    }

    public enum StatToChange 
    {
        none,
        riddle,
        Borki_1,
        bee,
        pot,
        honey,
        pot_of_honey,
        Borki_2

    };

    public enum AttributesToChange
    {
        none,
        riddle,
        Borki,
        bee,
        box,
        honey
    };
}
