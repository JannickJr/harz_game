using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    private void Start()
    {
        result = new int[] { 0, 0, 0, 0 };
        correctCombination = new int[] { 7, 2, 7, 0 };
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
        }
    }
    private void OnDestroy()
    {
        Puzzle1_Rotate.Rotated -= CheckResults;
    }
}
