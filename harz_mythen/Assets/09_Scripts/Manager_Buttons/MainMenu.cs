using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Camera camInnen;
    [SerializeField] private Camera camAussen;

    private void Start()
    {
        camAussen.enabled = true;
        camInnen.enabled = false;
    }

    private void OnMouseDown()
    {
        camInnen.enabled = true;
        camAussen.enabled = false;
    }
}
