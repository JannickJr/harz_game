using _09_Scripts._Dialogsystem; // im Moment nicht in Gebrauch
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraMovement_Scene_3 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform topWall;
  
    private void Update()
    {
        
        if (slider.value != 0) // führe Methode aus, wenn Sliderwert nicht Null ist
        {
            MoveCamera_S3();
        }
        
    }
    
    public void MoveCamera_S3() // Kamerabewegung durch Sliderverschiebung
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(0, movement, 0) * movementSpeedCamera * Time.deltaTime; 

        if (slider.value <= 0 && mainCamera.transform.position.y <= bottomWall.position.y) // unten
        {
            Debug.Log("Es ist soweit."); // wird erkannt
            mainCamera.transform.position = bottomWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.y >= topWall.position.y) // oben
        {
            mainCamera.transform.position = topWall.position;
        }
    }

    public void resetSlider() // Slider wird auf Null gesetzt, wenn er losgelassen wird
    {
        slider.value = 0;
    }
}

