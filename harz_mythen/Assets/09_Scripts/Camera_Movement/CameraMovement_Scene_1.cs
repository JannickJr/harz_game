using _09_Scripts._Dialogsystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraMovement_Scene_1 : MonoBehaviour
{
    //---SLIDER-VARIANTE---//
    [SerializeField] private Slider slider;

    //---WASD-VARIANTE---//
    PlayerInput cameraInput;
    InputAction moveAction;

    //---BEIDE VARIANTEN---//
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform leftWall;
    [SerializeField] private Transform rightWall;

    private void OnEnable()
    {
        Dialog.OnHUDActivation += OnHUDActivation;
        Dialog.OnHUDDeactivation += OnHUDDeactivation;
    }
    public void OnHUDActivation()
    {
        mainCamera.GetComponent<PlayerInput>().enabled = true;
    }

    public void OnHUDDeactivation()
    {
        mainCamera.GetComponent<PlayerInput>().enabled = false;
    }

    private void Start()
    {
        //---WASD-VARIANTE---//
        cameraInput = GetComponent<PlayerInput>();
        moveAction = cameraInput.actions.FindAction("Move_S1");
    }

    private void Update()
    {
        //---WASD-VARIANTE---//
        MoveCamera_S1a();

        //---SLIDER-VARIANTE---//
        /*if (slider.value != 0) // führe Methode aus, wenn Sliderwert nicht Null ist
        {
            MoveCamera_S1b();
        }*/
    }

    //---WASD-VARIANTE---//
    private void MoveCamera_S1a()
    {
        //Debug.Log(moveAction.ReadValue<Vector2>());
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, 0, direction.y) * movementSpeedCamera * Time.deltaTime;

        if (transform.position.x <= leftWall.position.x) // links
        {
            Debug.Log("Es ist soweit."); 
            transform.position = leftWall.position;
        }
        else if (transform.position.x >= rightWall.position.x) // rechts
        {
            transform.position = rightWall.position;
        }
    }

    private void OnDestroy()
    {
        Dialog.OnHUDActivation -= OnHUDActivation;
        Dialog.OnHUDDeactivation -= OnHUDDeactivation;
    }

    //---SLIDER-VARIANTE---//

    // Wenn Slider negativ + Kamera zu nah am linken Empty, dann Slider nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + Kamera zu nah am rechten Empty, dann Slider nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    // wenn nicht gedrückt, dann nicht bewegen


    /*public void MoveCamera_S1b() // Kamerabewegung durch Sliderverschiebung
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(movement, 0, 0) * movementSpeedCamera * Time.deltaTime;

        if (slider.value <= 0 && mainCamera.transform.position.x <= leftWall.position.x) // links
        {
            Debug.Log("Es ist soweit."); 
            mainCamera.transform.position = leftWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.x >= rightWall.position.x) // rechts
        {
            mainCamera.transform.position = rightWall.position;
        }
    }

    public void ResetSlider()  // Slider wird auf Null gesetzt, wenn er losgelassen wird
    {
        slider.value = 0;
    }*/
}

