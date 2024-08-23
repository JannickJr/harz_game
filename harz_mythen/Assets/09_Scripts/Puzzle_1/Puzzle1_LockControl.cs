using _09_Scripts._Dialogsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_LockControl : MonoBehaviour
{
    public static bool victory = false;

    private int[] result, correctCombination;

    [SerializeField] private AudioClip openLockClip;

    [SerializeField] private AudioClip puzzleDoneClip;

    public AudioClip turnDialClip;

    public static event Action PuzzleVictory; // Eventmanagement fuer Raetsel

    private void Start()
    {
        result = new int[] { 0, 0, 0, 0 };
        correctCombination = new int[] { 1, 5, 4, 1 }; // L�sung
        Puzzle1_Rotate.Rotated += CheckResults;
    }

    private void CheckResults(string wheelName, int number) // Checken der L�sung
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
        // wenn richtig
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] && result[2] == correctCombination[2] && result[3] == correctCombination[3]) 
        {
            Debug.Log("Opened!");
            victory = true; // Sender siehe Z. 55 (puzzleVictory)
            Debug.Log("Victory: " + victory);
            //Dialog.LevelStarted = false;
            PuzzleVictory(); // Eventmanagement fuer Raetsel

            SoundFXManager.instance.PlaySoundFXClip(openLockClip, transform, 1f);
            SoundFXManager.instance.PlaySoundFXClip(puzzleDoneClip, transform, 1f);
        }
    }
    private void OnDestroy() // bei Zerst�rung Methode beenden
    {
        Puzzle1_Rotate.Rotated -= CheckResults;
    }
}
