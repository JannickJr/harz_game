using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Manager : MonoBehaviour
{
    public GameObject Buttons;
    private bool menuActivated;

    private void Start()
    {
     
    }

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

    // Diese Methode ermöglicht das Laden einer Szene beim Anklicken eines Buttons
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadMainMenu()
    {
        Main_Menu.MainMenuIsActivated = false; // war für DontDestroy-Script gedacht
        Debug.Log(Main_Menu.MainMenuIsActivated);
        SceneManager.LoadScene("01_Main_Menu");
    }

    public void LoadCutScene_1()
    {
        SceneManager.LoadScene("02_CutScene_01");
        Main_Menu.MainMenuIsActivated = false; // war für DontDestroy-Script gedacht
        Debug.Log(Main_Menu.MainMenuIsActivated);// war für DontDestroy-Script gedacht
    }

    public void LoadScene_1()
    {
        SceneManager.LoadScene("03_Scene_1");
    }

    public void GoToMainCamera()
    {

    }

    public void GoToCam2()
    {

    }


    // Diese Methode ermöglicht das Beenden der Anwendung beim Anklicken eines Buttons
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
