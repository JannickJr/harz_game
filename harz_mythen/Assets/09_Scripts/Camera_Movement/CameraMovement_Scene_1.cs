using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMovement_Scene_1 : MonoBehaviour
{
    public Slider movementSlider;

    private float moveSliderNumber;


    private void Update()
    {
        moveSliderNumber = movementSlider.value * 10f;
        //this.transform.position = transform.Translate(Vector3.forward * Time.deltaTime * verticalInput);
    }

}

