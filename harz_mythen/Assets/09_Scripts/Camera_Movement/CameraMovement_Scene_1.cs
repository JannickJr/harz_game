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

