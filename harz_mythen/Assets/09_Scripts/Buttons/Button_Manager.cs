using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Manager : MonoBehaviour
{
    public GameObject Buttons;
    private bool menuActivated;

    public void ButtonBar()
    {
        if (menuActivated)
        {
            Buttons.SetActive(false);
            menuActivated = false;
        }
        else if (!menuActivated)
        {
            Buttons.SetActive(true);
            menuActivated = true;
        }
    }
}
