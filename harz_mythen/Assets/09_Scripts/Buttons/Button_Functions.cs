using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Functions : MonoBehaviour
{
    // Diese Methode ermöglicht das Laden einer Szene beim Anklicken eines Buttons
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Diese Methode ermöglicht das Beenden der Anwendung beim Anklicken eines Buttons
    public void ExitGame()
    {
        Application.Quit();
    }
}
