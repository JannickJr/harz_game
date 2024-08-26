using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalClick : MonoBehaviour
{
    public AudioClip clickSound;
    public AudioClip successMelody;
    public Color highlightColor = Color.yellow;
    public int objectID;

    private AudioSource audioSource;
    private Renderer objectRenderer;
    private Color originalColor;

    private static readonly int[] correctSequence = new int[] { 1, 2, 3, 1, 2, 4 };
    private static int currentSequenceIndex = 0;
    private static bool puzzleCompleted = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        objectRenderer = GetComponent<Renderer>();

        if (objectRenderer != null)
        {
            originalColor = objectRenderer.material.color;
        }
    }

    void OnMouseDown()
    {
        if (puzzleCompleted)
        {
            return; // Wenn das Puzzle abgeschlossen ist, reagiert das Objekt nicht mehr auf Klicks
        }

        PlayClickSound();

        if (objectID == correctSequence[currentSequenceIndex])
        {
            currentSequenceIndex++;
            if (objectRenderer != null)
            {
                HighlightObject();
            }

            if (currentSequenceIndex == correctSequence.Length)
            {
                puzzleCompleted = true; // Setzt das Puzzle als abgeschlossen
                HighlightAllObjects();
                Invoke("PlaySuccessMelody", 2f); // Verzögert das Abspielen der Erfolgsmelodie um 2 Sekunden
            }
        }
        else
        {
            currentSequenceIndex = 0; // Setzt die Sequenz zurück, wenn die falsche Reihenfolge geklickt wurde
        }
    }

    void PlayClickSound()
    {
        audioSource.clip = clickSound;
        audioSource.Play();
    }

    void PlaySuccessMelody()
    {
        audioSource.clip = successMelody;
        audioSource.Play();
    }

    void HighlightObject()
    {
        objectRenderer.material.color = highlightColor;
        Invoke("ResetColor", 0.5f);
    }

    void HighlightAllObjects()
    {
        var objects = FindObjectsOfType<CrystalClick>();
        foreach (var obj in objects)
        {
            if (obj.objectRenderer != null)
            {
                obj.objectRenderer.material.color = highlightColor;
                obj.Invoke("ResetColor", 0.5f);
            }
        }
    }

    void ResetColor()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}