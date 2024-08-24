using _09_Scripts._Dialogsystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Camera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cam2;
    public Camera cam3;
    public Camera cam4;
    public bool Cam2On;
    public GameObject Box;
    public GameObject Button;
    //public GameObject Slider;
    public GameObject Lock;

    private GameObject character;

    public GameObject Dialogi;

    public static event Action animationVictory; // Eventmanagement fuer Animation
    //public static event Action OnMarkedItems;
    //public static event Action OnDemarkedItems;
    //public static event Action OnDialog_2_Continue; // Eventmanagement fuer Dialog 2 // noch nicht in Benutzung

    void Start() // Kameraanweisung bei Szenenstart
    {
        mainCamera.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        cam4.enabled = false;
    }

    private void Update()
    {
        MouseClick(); // Klick
    }

    private void OnEnable()
    {
        Puzzle1_LockControl.PuzzleVictory += Victory; // Eventmanagement fuer Kameras
        Ring_Animation.VictoryToDialog += VictoryToDialog; // Eventmanagement fuer Dialog 2
        //Dialog.OnInteraction += GetCollider; // unnötig
    }

    /*public void GetCollider() // unnötig
    {
        Box.GetComponent<BoxCollider>().enabled = true;
    }*/

    public void MouseClick()    // Was beim Anklicken eines Items passiert.
    {
        if (Input.GetMouseButtonDown(0)) // Achtung, hier mit mainCamera
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit)) 
            {                                               
                Debug.Log("Ray");
                if (hit.transform.gameObject.CompareTag("Box"))
                {
                    Debug.Log("Treffer Box");                    
                    mainCamera.enabled = false;
                    cam2.enabled = true;
                    cam3.enabled = false;
                    Cam2On = true;
                    Button.SetActive(true);
                    //Slider.SetActive(false);
                    character = GameObject.Find("Character_Romar");
                    character.GetComponent<DialogActivation>().enabled = false;
                    character = GameObject.Find("Character_Ruma");
                    character.GetComponent<DialogActivation>().enabled = false;
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0) && cam2.enabled == true) // Achtung, hier mit Cam2
        {
            Ray ray = cam2.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(ray, out RaycastHit hit)) 
            {                                               
                Debug.Log("Ray");
                if (hit.transform.gameObject.layer == 3)
                {
                    Debug.Log("Treffer Lock"); 
                    mainCamera.enabled = false;
                    cam2.enabled = false;
                    cam3.enabled = true;
                    Cam2On = false;
                    Box.GetComponent<BoxCollider>().enabled = false;
                } 
            }
        }
    }

    public void GoToCamera() // "Zurück"-Button-Methode
    {
        if (Cam2On == true)
        {
            mainCamera.enabled = true;
            Debug.Log("Kamera: " + mainCamera.enabled);
            cam2.enabled = false;
            cam3.enabled = false;
            Button.SetActive(false);
            //Slider.SetActive(true);
            character = GameObject.Find("Character_Romar");
            character.GetComponent<DialogActivation>().enabled = true;
            character = GameObject.Find("Character_Ruma");
            character.GetComponent<DialogActivation>().enabled = true;
            Box.GetComponent<BoxCollider>().enabled = true;
        }
        if (Cam2On == false) 
        {
            mainCamera.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            Cam2On = true;
        }
    }

    /*public void OnMouseEnter()
    {
        OnMarkedItems();
    }

    public void OnMouseExit()
    {
        OnDemarkedItems();
    }*/

    public void Victory()
    {
        cam2.enabled = true;
        cam3.enabled = false;
        Lock.SetActive(false);
        Button.SetActive(false);
        Box.GetComponent<BoxCollider>().enabled = false;
        animationVictory(); // Eventmanagement fuer Animation
        //StartCoroutine(Victory_Camera());
    }

    public void VictoryToDialog() // Eventmanagement fuer Dialog 2
    {
        cam2.enabled = false;
        cam4.enabled = true;
        Debug.Log("Dialog.LevelStarted: " + Dialog.LevelStarted);
        Dialogi.SetActive(true);
        //Debug.Log("Dialogi.SetActive(true): " + Dialogi);
        //Dialog.LevelStarted = true; // --> evtl.zu Methode ändern
        //OnDialog_2_Continue(); // neu Sender // nicht in Benutzung
    }

    private void OnDestroy()
    {
        Puzzle1_LockControl.PuzzleVictory -= Victory; 
        Ring_Animation.VictoryToDialog -= VictoryToDialog;
        //Dialog.OnInteraction -= GetCollider; // // gescheitertes Experiment
    }
}

