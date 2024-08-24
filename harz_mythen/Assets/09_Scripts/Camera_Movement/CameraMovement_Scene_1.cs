using _09_Scripts._Dialogsystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraMovement_Scene_1 : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private Slider slider;
    [SerializeField] private float movementSpeedCamera;

    public InputAction cameraControlls;

    Vector2 movement = Vector2.zero;

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;

    private void OnEnable()
    {
        cameraControlls.Enable();
    }

    private void OnDisable()
    {
        cameraControlls.Disable();
    }

    private void Update()
    {
        //MoveCamera_S1();
        if (slider.value != 0) // führe Methode aus, wenn Sliderwert nicht Null ist
        {
            MoveCamera_S1();
        }
        
    }
    // Wenn Slider negativ + Kamera zu nah am linken Empty, dann Slider nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + Kamera zu nah am rechten Empty, dann Slider nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    // wenn nicht gedrückt, dann nicht bewegen

    public void MoveCamera_S1() // Kamerabewegung durch Sliderverschiebung
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(movement, 0, 0) * movementSpeedCamera * Time.deltaTime;

        if (slider.value <= 0 && mainCamera.transform.position.x <= leftWall.position.x) // links
        {
            Debug.Log("Es ist soweit."); // wird erkannt
            mainCamera.transform.position = leftWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.x >= rightWall.position.x) // rechts
        {
            mainCamera.transform.position = rightWall.position;
        }
    }

    public void resetSlider()  // Slider wird auf Null gesetzt, wenn er losgelassen wird
    {
        slider.value = 0;
    }

    /*public void MoveCamera_S1() // Kamerabewegung durch Sliderverschiebung
    {
        //float movement = slider.value;
        movement = cameraControlls.ReadValue<Vector2>();

        mainCamera.transform.position = new Vector2(movement.x * movementSpeedCamera * Time.deltaTime, movement.y * movementSpeedCamera * Time.deltaTime);

        /*if (slider.value <= 0 && mainCamera.transform.position.x <= leftWall.position.x) // links
        {
            Debug.Log("Es ist soweit."); // wird erkannt
            mainCamera.transform.position = leftWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.x >= rightWall.position.x) // rechts
        {
            mainCamera.transform.position = rightWall.position;
        }
    }*/

    //public void resetSlider()  // Slider wird auf Null gesetzt, wenn er losgelassen wird
    //{
        //slider.value = 0;
    //}
}

