using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutlineSelection_Puzzle_2 : MonoBehaviour
{
    public static event Action OnHoverPuzzleON;
    public static event Action OnHoverPuzzleOFF;


    public void OnMouseEnter()
    {
        OnHoverPuzzleON();
    }

    public void OnMouseExit()
    {
        OnHoverPuzzleOFF();
    }
}
