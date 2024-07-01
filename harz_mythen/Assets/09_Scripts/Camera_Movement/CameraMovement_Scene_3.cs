using _09_Scripts._Dialogsystem; // im Moment nicht in Gebrauch
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement_Scene_3 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform topWall;
  
    private void Update()
    {
        //if ()
        {
            if (slider.value != 0)
            {
                MoveCamera_S3();
            }
        }
    }
    // Wenn Slider negativ + Kamera zu nah am unteren Empty, dann Slider nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + Kamera zu nah am oberen Empty, dann Slider nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    // wenn nicht gedrückt, dann nicht bewegen
    
    public void MoveCamera_S3()
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(0, movement, 0) * movementSpeedCamera * Time.deltaTime;

        if (slider.value <= 0 && mainCamera.transform.position.y <= bottomWall.position.y)
        {
            Debug.Log("Es ist soweit."); // wird erkannt
            mainCamera.transform.position = bottomWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.y >= topWall.position.y)
        {
            mainCamera.transform.position = topWall.position;
        }
    }

    public void resetSlider()
    {
        slider.value = 0;
    }
}

