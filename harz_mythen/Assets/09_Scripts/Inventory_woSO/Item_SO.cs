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
    public static event Action OnHoney;
    public static event Action OnPotOfHoney;
    public static event Action OnBorki;

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
        if (statToChange == StatToChange.honey) // jetzt muss was passieren
        {
            Debug.Log("Find43");
            //GameObject.Find("Item").GetComponent<Item_2>().Test(); // hier geht es nicht weiter
            OnHoney();
            Debug.Log("Find_34");
        }
        if (statToChange == StatToChange.pot_of_honey) // jetzt muss was passieren
        {
            Debug.Log("Find001");
            //GameObject.Find("Item").GetComponent<Item_2>().Test(); // hier geht es nicht weiter
            OnPotOfHoney();
            Debug.Log("Find_002");
        }
        if (statToChange == StatToChange.Borki) // jetzt muss was passieren
        {
            Debug.Log("Finder");
            //GameObject.Find("Item").GetComponent<Item_2>().Test(); // hier geht es nicht weiter
            OnBorki();
            Debug.Log("Finderin");
        }
    }

    public enum StatToChange 
    {
        none,
        riddle,
        Borki,
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
