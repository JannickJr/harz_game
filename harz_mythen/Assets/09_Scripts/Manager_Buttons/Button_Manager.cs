using _09_Scripts._Dialogsystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class Button_Manager : MonoBehaviour
{
    public GameObject Buttons;
    private bool menuActivated;

    public void OnEnable()
    {
        Dialog.OnLoadScene += Activation;
        Dialog_2.OnLoadScene += Activation;
        Dialog_3.OnLoadScene += Activation;

        Change_Scene_CS.OnLoadScene += Activation;
    }

    public void ButtonBar() // (De-)Aktivierung der Menubuttons in der Spielszene
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

    public void Activation()
    {
        gameObject.SetActive(true);
    }

    public void OnDestroy()
    {
        Dialog.OnLoadScene -= Activation;
        Dialog_2.OnLoadScene -= Activation;
        Dialog_3.OnLoadScene -= Activation;

        Change_Scene_CS.OnLoadScene -= Activation;
    }

    public void LoadMainMenu() // Laden des Hauptmenüs
    {
        DialogActivation.characterNumber = 0;
        DialogActivation.dialogActivated = true;
        Dialog.LevelStarted = true;
        SceneManager.LoadScene("01_Main_Menu");
    }
}
