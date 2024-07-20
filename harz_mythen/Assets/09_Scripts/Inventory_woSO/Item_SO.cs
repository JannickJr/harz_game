using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[CreateAssetMenu]
public class Item_SO : ScriptableObject
{
    public string itemName;

    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public AttributesToChange attributesToChange = new AttributesToChange();
    public int amountToChangeAttributes;

    public static event Action OnPot;

    public void UseItem()
    {
        if (statToChange == StatToChange.pot) // jetzt muss was passieren
        {
            Debug.Log("Find");
            //GameObject.Find("Item").GetComponent<Item_2>().Test(); // hier geht es nicht weiter
            OnPot();
            Debug.Log("Find_2");
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
