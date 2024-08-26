using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using _09_Scripts._Dialogsystem;

public class SceneManagement : MonoBehaviour
{
    private void OnEnable()
    {
        Dialog.OnLoadScene += LoadNextScene;
        Change_Scene_CS.OnLoadScene += LoadNextScene;
    }

    public void Start()
    {
        SceneActivation();
    }

    // Diese Methode ermöglicht das Laden einer Szene beim Anklicken eines Buttons || nicht in Benutzung
    public void LoadSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadNextScene() // Laden der nächsten Szene im Build
    {
        if (GameObject.Find("01_Main_Menu"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (GameObject.Find("02_CutScene_01"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
        if (GameObject.Find("03_Scene_01"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            //GameObject.Find("03_Scene_01").SetActive(false);
            SceneManager.UnloadSceneAsync("03_Scene_01");
        }
        if (GameObject.Find("04_CutScene_02"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("04_CutScene_02");
            //GameObject.Find("Inventory_Button").SetActive(true);
            //GameObject.Find("Menu_Buttons").SetActive(true);
            //GameObject.Find("Task").SetActive(true);
            GameObject.Find("Buttons").SetActive(true);
        }
        if (GameObject.Find("05_Scene_02"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("05_Scene_02");
        }
        if (GameObject.Find("06_CutScene_03"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync("06_CutScene_03");
            //GameObject.Find("Inventory_Button").SetActive(true);
            //GameObject.Find("Menu_Buttons").SetActive(true);
            //GameObject.Find("Task").SetActive(true);
            GameObject.Find("Buttons").SetActive(true);
        }
        if (GameObject.Find("07_Scene_03"))
        {
            SceneManager.LoadScene("08_CutScene_04");
            SceneManager.UnloadSceneAsync("07_Scene_03");
        }
        if (GameObject.Find("08_CutScene_04"))
        {
            DialogActivation.characterNumber = 0;
            DialogActivation.dialogActivated = true;
            Dialog.LevelStarted = true;
            Item_2.stick = false;
            Item_2.web = false;
            SceneManager.LoadScene("01_Main_Menu");
        }
    }

    public void SceneActivation()
    {
        if (GameObject.Find("03_Scene_01"))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("03_Scene_01"));
        }
        if (GameObject.Find("04_CutScene_02"))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("04_CutScene_02"));
        }
        if (GameObject.Find("05_Scene_02"))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("05_Scene_02"));
        }
        if (GameObject.Find("06_CutScene_03"))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("06_CutScene_03"));
        }
        if (GameObject.Find("07_Scene_03"))
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("07_Scene_03"));
        }
    }

    private void OnDisable()
    {
        Dialog.OnLoadScene -= LoadNextScene;
        Change_Scene_CS.OnLoadScene -= LoadNextScene;
    }
}
