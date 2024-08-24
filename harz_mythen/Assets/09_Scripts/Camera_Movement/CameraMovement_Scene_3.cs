using _09_Scripts._Dialogsystem; // im Moment nicht in Gebrauch
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class CameraMovement_Scene_3 : MonoBehaviour
{
    //---SLIDER-VARIANTE---//
    [SerializeField] private Slider slider;

    //---WASD-VARIANTE---//
    PlayerInput cameraInput;
    InputAction moveAction;

    //---BEIDE VARIANTEN---//
    [SerializeField] private GameObject mainCamera;

    [SerializeField] private float movementSpeedCamera;

    [SerializeField] private Transform bottomWall;
    [SerializeField] private Transform topWall;

    private void OnEnable()
    {
        Dialog_3.OnHUDActivation += OnHUDActivation;
        Dialog_3.OnHUDDeactivation += OnHUDDeactivation;
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
        moveAction = cameraInput.actions.FindAction("Move_S3");
        Debug.Log(cameraInput.actions.FindAction("Move_S3") + "ja");
    }

    private void Update()
    {
        //---WASD-VARIANTE---//
        MoveCamera_S3a();

        //---SLIDER-VARIANTE---//
        /*if (slider.value != 0) // führe Methode aus, wenn Sliderwert nicht Null ist
        {
            MoveCamera_S3b();
        }*/
    }

    //---WASD-VARIANTE---//
    private void MoveCamera_S3a()
    {
        Debug.Log(moveAction.ReadValue<Vector2>());
        Vector2 direction = moveAction.ReadValue<Vector2>();
        transform.position += new Vector3(direction.x, direction.y, 0) * movementSpeedCamera * Time.deltaTime;

        if (transform.position.y <= bottomWall.position.y) // unten
        {
            Debug.Log("Es ist soweit.");
            transform.position = bottomWall.position;
        }
        else if (transform.position.y >= topWall.position.y) // oben
        {
            transform.position = topWall.position;
        }
    }

    private void OnDestroy()
    {
        Dialog_3.OnHUDActivation -= OnHUDActivation;
        Dialog_3.OnHUDDeactivation -= OnHUDDeactivation;
    }

    //---SLIDER-VARIANTE---//

    // Wenn Slider negativ + Kamera zu nah am linken Empty, dann Slider nicht weiter in diese Richtung bewegen;
    // Wenn Slider positiv + Kamera zu nah am rechten Empty, dann Slider nicht weiter in diese Richtung bewegen; 
    // eine Koordinate angucken: Ist x-Koordinate größer oder kleiner als Ecken (= Sitz der Emptys), die ich gesetzt habe?
    // wenn nicht gedrückt, dann nicht bewegen


    /*public void MoveCamera_S3b() // Kamerabewegung durch Sliderverschiebung
    {
        float movement = slider.value;

        mainCamera.transform.position += new Vector3(0, movement, 0) * movementSpeedCamera * Time.deltaTime;

        if (slider.value <= 0 && mainCamera.transform.position.y <= bottomWall.position.y) // unten
        {
            Debug.Log("Es ist soweit."); 
            mainCamera.transform.position = bottomWall.position;

        }
        else if (slider.value >= 0 && mainCamera.transform.position.y >= topWall.position.y) // oben
        {
            mainCamera.transform.position = topWall.position;
        }
    }

    public void ResetSlider()  // Slider wird auf Null gesetzt, wenn er losgelassen wird
    {
        slider.value = 0;
    }*/
}

