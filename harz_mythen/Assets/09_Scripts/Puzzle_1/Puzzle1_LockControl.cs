using _09_Scripts._Dialogsystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_LockControl : MonoBehaviour
{
    public GameObject Dialogi;

    public static bool victory = false;

    private int[] result, correctCombination;
    private void Start()
    {
        result = new int[] { 0, 0, 0, 0 };
        correctCombination = new int[] { 7, 2, 5, 0 };
        Puzzle1_Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number)
    {
        switch (wheelName)
        {
            case "Wheel1":
                result[0] = number;
                break;

            case "Wheel2":
                result[1] = number;
                break;

            case "Wheel3":
                result[2] = number;
                break;

            case "Wheel4":
                result[3] = number;
                break;
        }
        if(result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3])
        {
            Debug.Log("Opened!");
            victory = true;
            Debug.Log("Victory: " + victory);
            Dialog.LevelStarted = false;
            Debug.Log("Dialog.LevelStarted: " + Dialog.LevelStarted);
            Dialogi.SetActive(true);
            Debug.Log("Dialogi.SetActive(true): " + Dialogi);
        }
    }
    private void OnDestroy()
    {
        Puzzle1_Rotate.Rotated -= CheckResults;
    }
}
