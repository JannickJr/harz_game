using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    // Die folgenden Methoden ermöglichen das Beenden der Anwendung beim Anklicken eines Buttons
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        Exit();
    }

    private void OnMouseDown()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
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
