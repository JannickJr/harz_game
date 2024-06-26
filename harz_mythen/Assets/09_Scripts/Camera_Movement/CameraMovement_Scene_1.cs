using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement_Scene_1 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeedCamera;


    private void Update()
    {
        float movement = slider.value;
        mainCamera.transform.position += new Vector3(movement, 0, 0) * movementSpeedCamera * Time.deltaTime;
        //StopMovement();
    }
    // Wenn Slider negativ + zu nah am linken Empty, dann nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + zu nah am rechten Empty, dann nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    public void resetSlider()
    {
        slider.value = 0;
    }

    public void StopMovement()
    {
        mainCamera.transform.position = new Vector3(1.37f, 0, 0);
        
        //float movement = 0;
    }

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("Treffer");
        //movementSpeedCamera = 0;
    }
}

