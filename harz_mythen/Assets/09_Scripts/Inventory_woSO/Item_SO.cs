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

    public AttributesToChange attributesToChange = new AttributesToChange(); // brauche ich nicht 
    public int amountToChangeAttributes; // brauche ich nicht 

    public static event Action OnPot;
    public static event Action OnHoney;


    public void UseItem()
    {
        if (statToChange == StatToChange.pot) // jetzt muss was passieren
        {
            Debug.Log("Find");
            OnPot();
            Debug.Log("Find_2");
        }
        // das für jeden Stat schreiben
        if (statToChange == StatToChange.honey) // jetzt muss was passieren
        {
            Debug.Log("Find43");
            OnHoney();
            Debug.Log("Find_34");
        }
    }

    public enum StatToChange 
    {
        none,
        pot,
        honey,
    };

    public enum AttributesToChange // brauche ich nicht 
    {
        none,
        pot,
        honey
    };
}
