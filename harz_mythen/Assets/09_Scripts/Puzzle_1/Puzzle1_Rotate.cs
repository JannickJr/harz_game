using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Puzzle1_Rotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };

    private bool coroutineAllowed;

    private int numberShown;

    //private AudioClip turnDialClip;

    private void Start()
    {
        coroutineAllowed = true;
        numberShown = 0;
        //turnDialClip = Puzzle1_LockControl.turnDialClip,
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed)
        {
            StartCoroutine("RotateWheel");
        }
    }

    private IEnumerator RotateWheel()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(-3f, 0f, 0f);
            yield return new WaitForSeconds(0.01f);
        }

        coroutineAllowed = true;

        numberShown += 1;

        if (numberShown > 9)
        {
            numberShown = 0;
        }

        //SoundFXManager.instance.PlaySoundFXClip(turnDialClip, transform, 1f);

        Rotated(name, numberShown);
    }
}

