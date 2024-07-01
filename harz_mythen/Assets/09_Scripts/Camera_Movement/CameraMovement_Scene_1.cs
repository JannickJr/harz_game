using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement_Scene_1 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;
  
    private void Update()
    {
        if (slider.value != 0)
        {
            MoveCamera();
        }
    }
    // Wenn Slider negativ + Kamera zu nah am linken Empty, dann Slider nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + Kamera zu nah am rechten Empty, dann Slider nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    // wenn nicht gedrückt, dann nicht bewegen

    public void MoveCamera()
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(movement, 0, 0) * movementSpeedCamera * Time.deltaTime;

        if (slider.value <= 0 && mainCamera.transform.position.x <= leftWall.position.x)
        {
            Debug.Log("Es ist soweit."); // wird erkannt
            mainCamera.transform.position = leftWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.x >= rightWall.position.x)
        {
            mainCamera.transform.position = rightWall.position;
        }
    }

    public void resetSlider()
    {
        slider.value = 0;
    }
}

