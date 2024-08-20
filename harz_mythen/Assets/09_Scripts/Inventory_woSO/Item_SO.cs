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
    public static event Action OnFishing;
    public static event Action OnOlm;


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
        if (statToChange == StatToChange.stick || statToChange == StatToChange.web) // jetzt muss was passieren
        {
            Debug.Log("Find");
            OnFishing();
            Debug.Log("Find_2");
        }
        if (statToChange == StatToChange.fishing) // jetzt muss was passieren
        {
            Debug.Log("Find43");
            OnOlm();
            Debug.Log("Find_34");
        }
    }

    public enum StatToChange 
    {
        none,
        pot,
        honey,
        stick,
        web,
        fishing
    };

    public enum AttributesToChange // brauche ich nicht 
    {
        none,
        pot,
        honey,
        stick,
        web,
        fishing
    };
}
