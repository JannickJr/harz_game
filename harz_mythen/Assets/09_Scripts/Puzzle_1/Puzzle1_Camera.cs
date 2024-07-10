using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle1_Camera : MonoBehaviour
{
    public Camera mainCamera;
    public Camera cam2;
    public Camera cam3;
    public bool Cam2On;
    //[SerializeField] private GameObject locki;
    public GameObject Box;
    public GameObject Button;
    public GameObject Slider;

    void Start()
    {
        mainCamera.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
    }

    private void Update()
    {
        MouseClick();
        if (Puzzle1_LockControl.victory == true)
        {
            Victory();
        }
    }

    public void MouseClick()    // Was beim Anklicken eines Items passiert.
    {
        if (Input.GetMouseButtonDown(0)) // Achtung, hier mit mainCamera
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            Ray ray2 = cam2.ScreenPointToRay(Input.mousePosition);
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
                    Slider.SetActive(false);
                    //locki.SetActive(true);
                }
            }
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam2.ScreenPointToRay(Input.mousePosition); // Achtung, hier mit Cam2
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
                } 
            }
        }
    }

    public void GoToCamera()
    {
        if (Cam2On == true)
        {
            mainCamera.enabled = true;
            Debug.Log("Kamera: " + mainCamera.enabled);
            cam2.enabled = false;
            cam3.enabled = false;
            Button.SetActive(false);
            Slider.SetActive(true);
            //Cam2On = false;
        }
        if (Cam2On == false)
        {
            mainCamera.enabled = false;
            cam2.enabled = true;
            cam3.enabled = false;
            Cam2On = true;
        }
    }

    public void Victory()
    {
        mainCamera.enabled = true;
        cam2.enabled = false;
        cam3.enabled = false;
        Button.SetActive(false);
        Box.GetComponent<BoxCollider>().enabled = false;
    }
}
