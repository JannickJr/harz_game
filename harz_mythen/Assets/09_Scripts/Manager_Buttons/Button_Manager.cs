using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public GameObject Buttons;
    private bool menuActivated;


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

    // Diese Methode ermöglicht das Laden einer Szene beim Anklicken eines Buttons
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu() // Laden des Hauptmenüs
    {
        //Main_Menu.MainMenuIsActivated = false; // war für DontDestroy-Script gedacht
        //Debug.Log(Main_Menu.MainMenuIsActivated);
        SceneManager.LoadScene("01_Main_Menu");
    }

    public void LoadNextScene() // Lader der nächsten Szene im Build
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadCutScene_1() // Lader der ersten Cutscene --- gerade nicht mehr aktiv
    {
        SceneManager.LoadScene("02_CutScene_01");
        //Main_Menu.MainMenuIsActivated = false; // war für DontDestroy-Script gedacht
        //Debug.Log(Main_Menu.MainMenuIsActivated);// war für DontDestroy-Script gedacht
    }

    public void LoadScene_1() // Laden der ersten Szene --- gerade nicht mehr aktiv
    {
        SceneManager.LoadScene("03_Scene_1");
    }

    // Die folgenden Methoden ermöglichen das Beenden der Anwendung beim Anklicken eines Buttons
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        Exit();
    }

    public void Exit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Beenden");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }
    }
}
