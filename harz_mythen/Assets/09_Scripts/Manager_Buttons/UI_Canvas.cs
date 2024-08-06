using _09_Scripts._Dialogsystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Canvas : MonoBehaviour
{
    public GameObject Buttons;

    private void OnEnable()
    {
        Dialog.OnHUDActivation += OnHUDActivation;
        Dialog.OnHUDDeactivation += OnHUDDeactivation;
    }

    public void OnHUDActivation()
    {
        Buttons.SetActive(true);
    }

    public void OnHUDDeactivation()
    {
        Buttons.SetActive(false);
    }

    private void OnDestroy()
    {
        Dialog.OnHUDActivation -= OnHUDActivation;
        Dialog.OnHUDDeactivation -= OnHUDDeactivation;
    }
}
